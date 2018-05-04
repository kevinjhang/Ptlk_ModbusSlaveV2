#define Release
using Ptlk_ModbusSlaveV2.View;
using Ptlk_ModbusSlaveV2.Model;
using Ptlk_ModbusSlaveV2.Properties;
using NModbus;
using Google.Protobuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ptlk_ModbusSlaveV2
{
    public partial class Form1 : Form
    {
        private string appName = Settings.Default.AppName;
        private string userConfigPath
        {
            get { return Environment.ExpandEnvironmentVariables(Settings.Default.UserConfigPath); }
            set { Settings.Default.UserConfigPath = value; }
        }
        private Devices devices;
        private Device currentDevice { get => listBox1.SelectedIndex < 0 ? null : devices.Device[listBox1.SelectedIndex]; }
        private ModbusFactory modbusFactory = new ModbusFactory();
        private List<Tuple<IModbusSlaveNetwork, int>> modbusSlaveNetworkList = new List<Tuple<IModbusSlaveNetwork, int>>();
        private List<Tuple<DataStore, Device>> modbusSlaveDataStoreList = new List<Tuple<DataStore, Device>>();

        #region Devices

        #region LOAD/SAVE
        private void LoadDevices()
        {
            if (!File.Exists(userConfigPath))
            {
                File.Create(userConfigPath).Close();
            }
            using (Stream stream = File.OpenRead(userConfigPath))
            {
                devices = Devices.Parser.ParseFrom(stream);
            }
        }
        private void SaveDevices()
        {
            using (Stream output = File.Create(userConfigPath))
            {
                devices.WriteTo(output);
            }
        }
        #endregion

        #region INSERT
        private void InsertDevice(string name, int id, int port)
        {
            devices.Device.Add(new Device() { Name = name, Id = id, Port = port });
        }
        #endregion

        #region DELETE
        private void DeleteDevices()
        {
            if (currentDevice == null) return;

            devices.Device.Remove(currentDevice);
        }
        #endregion

        #region SELECT
        private IEnumerable<Device> SelectAllDevices()
        {
            return devices.Device;
        }

        private IEnumerable<Device.Types.DataItem> SelectDataItemsOfDevice(Device device)
        {
            if (device == null) return new Device.Types.DataItem[] { };

            return device.DataItem;
        }

        private int SelectDeviceNextUnitId()
        {
            if (devices.Device.Count == 0) return 1;

            return devices.Device.Max(d => d.Id) + 1;
        }

        private int SelectDataItemNextAddress()
        {
            if (currentDevice == null || currentDevice.DataItem.Count == 1) return 0;

            return currentDevice.DataItem.Max(i => i.Address) + 1;
        }
        #endregion

        #region UPDATE

        private void UpdateDevice(string name, int port, int id)
        {
            if (currentDevice == null) return;

            currentDevice.Name = name;
            currentDevice.Id = id;
            currentDevice.Port = port;
        }

        private void UpdateDataItemValue(Device device, int address, int value)
        {
            if (device == null) return;

            var dataItem = device.DataItem.Where(i => i.Address == address).FirstOrDefault();
            if (dataItem != null)
            {
                dataItem.Value = value;
            }
        }

        #endregion

        #endregion

        public Form1()
        {

            InitializeComponent();
#if Release
            this.WindowState = FormWindowState.Minimized;
#endif
            LoadData();
        }

        private void LoadData()
        {
            LoadDevices();
            UpdateDeviceList();
            Text = userConfigPath + " - " + appName;
        }

        private void SaveData()
        {
            SaveDevices();
        }

        private void newFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                Title = "Save New Data File",
                FileName = appName,
                DefaultExt = "data",
                Filter = "Data File|*.data"
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string temp = userConfigPath;
                try
                {
                    userConfigPath = saveFileDialog.FileName;
                    LoadData();
                    Settings.Default.Save();
                }
                catch
                {
                    userConfigPath = temp;
                    MessageBox.Show("Save new file error", appName, MessageBoxButtons.OK, MessageBoxIcon.Warning); ;
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "Data File|*.data"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string temp = userConfigPath;
                try
                {
                    userConfigPath = openFileDialog.FileName;
                    LoadData();
                    Settings.Default.Save();
                }
                catch
                {
                    userConfigPath = temp;
                    MessageBox.Show("Open file error", appName, MessageBoxButtons.OK, MessageBoxIcon.Warning); ;
                }
            }
        }

        private void UpdateDeviceList()
        {
            listBox1.Items.Clear();

            foreach (var device in SelectAllDevices())
            {
                listBox1.Items.Add(device.Name);
            }

            UpdateDataItemList();

            UpdateModbusSlave();
        }

        private void UpdateDataItemList()
        {
            dataGridView1.DataSource = null;

            if (currentDevice == null) return;

            bindingSource1.DataSource = SelectDataItemsOfDevice(currentDevice);
            dataGridView1.DataSource = bindingSource1;
            dataGridView1.AutoResizeColumns();
        }

        private void UpdateModbusSlave()
        {
            modbusSlaveDataStoreList.Clear();

            var count = modbusSlaveNetworkList.Count;

            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    modbusSlaveNetworkList[i].Item1.Dispose();
                    modbusSlaveNetworkList.RemoveAt(i);
                }
            }

            foreach (var device in SelectAllDevices())
            {
                IModbusSlaveNetwork modebusSlave;

                try
                {
                    var tuple = modbusSlaveNetworkList.First((t) => t.Item2 == device.Port);
                    modebusSlave = tuple.Item1;
                }
                catch
                {
                    modebusSlave = modbusFactory.CreateSlaveNetwork(new TcpListener(IPAddress.Any, device.Port));
                    modbusSlaveNetworkList.Add(Tuple.Create(modebusSlave, device.Port));
                }

                var dataStore = new DataStore(WriteHook);

                foreach (var dataItem in SelectDataItemsOfDevice(device))
                {
                    dataStore.HoldingRegisters.WritePoints((ushort)dataItem.Address, new[] { (ushort)dataItem.Value });
                }

                modebusSlave.AddSlave(modbusFactory.CreateSlave((byte)device.Id, dataStore));

                modbusSlaveDataStoreList.Add(Tuple.Create(dataStore, device));

                modebusSlave.ListenAsync();

                void WriteHook(ushort start, ushort[] values)
                {
                    foreach (var value in values)
                    {
                        var dataItem = device.DataItem.Where((i) => i.Address == start).FirstOrDefault();
                        if (dataItem != null && dataItem.IsVolatile == false)
                        {
                            UpdateDataItemValue(device, start, value);
                        }
                        start++;
                    }
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (currentDevice == null) return;

            toolStripStatusLabel_Port.Text = currentDevice.Port.ToString();
            toolStripStatusLabel_Id.Text = currentDevice.Id.ToString();

            UpdateDataItemList();
        }

        private void listBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;

            var index = listBox1.IndexFromPoint(e.Location);

            if (index != ListBox.NoMatches)
            {
                listBox1.SelectedIndex = index;
                contextMenuStrip_Device.Show(Cursor.Position);
                contextMenuStrip_Device.Visible = true;
            }
            else
            {
                contextMenuStrip_Device.Visible = false;
            }
        }

        private void newDeviceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new DeviceForm();

            dialog.Device_UnitId = SelectDeviceNextUnitId().ToString();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    InsertDevice(dialog.Device_Name, int.Parse(dialog.Device_UnitId), int.Parse(dialog.Device_TcpPort));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, appName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                UpdateDeviceList();
            }
        }

        private void modifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentDevice == null) return;

            var dialog = new DeviceForm();

            dialog.Device_Name = currentDevice.Name;
            dialog.Device_TcpPort = currentDevice.Port.ToString();
            dialog.Device_UnitId = currentDevice.Id.ToString();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    UpdateDevice(dialog.Device_Name, int.Parse(dialog.Device_TcpPort), int.Parse(dialog.Device_UnitId));

                    currentDevice.Name = dialog.Device_Name;
                    currentDevice.Port = int.Parse(dialog.Device_TcpPort);
                    currentDevice.Id = int.Parse(dialog.Device_UnitId);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, appName, MessageBoxButtons.OK, MessageBoxIcon.Warning); ;
                }

                UpdateDeviceList();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentDevice == null) return;

            if (MessageBox.Show($"Are you sure you want to delete device '{currentDevice.Name}' ?", appName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DeleteDevices();

                UpdateDeviceList();
            }
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (currentDevice == null) return;

            if (MessageBox.Show($"Are you sure you want to delete dataItem '{e.Row.Cells["Name"].Value}' ?", appName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        private void dataGridView1_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            if (currentDevice == null) return;

            e.Row.Cells[0].Value = "New";
            e.Row.Cells[1].Value = SelectDataItemNextAddress();
            e.Row.Cells[2].Value = 0;
            e.Row.Cells[3].Value = false;
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var row = dataGridView1.Rows[e.RowIndex];

            if (e.ColumnIndex >= 0 && e.ColumnIndex <= 2)
            {
                if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
                {
                    e.Cancel = true;
                }
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var row = dataGridView1.Rows[e.RowIndex];

            if (e.ColumnIndex == 2)
            {
                var addressCell = row.Cells[1];
                var valueCell = row.Cells[2];
                if (addressCell.Value != null && valueCell.Value != null)
                {
                    WriteDataStore((int)addressCell.Value, (int)valueCell.Value);
                }
            }
        }

        private void WriteDataStore(int address, int value)
        {
            var tuple = modbusSlaveDataStoreList.FirstOrDefault((t) => t.Item2 == currentDevice);

            if (tuple == null) return;

            var dataStore = tuple.Item1;

            dataStore.HoldingRegisters.WritePoints((ushort)address, new[] { (ushort)value });
        }

        private void NotifyIcon1_Click(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.TopMost = false;
        }

        private void Form1_VisibleChanged(object sender, EventArgs e)
        {
            this.notifyIcon1.Visible = !this.Visible;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Hide();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
#if Release
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Hide();
                e.Cancel = true;
            }
#endif
            SaveData();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
