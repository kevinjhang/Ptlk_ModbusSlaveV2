using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ptlk_ModbusSlaveV2.View
{
    public partial class DeviceForm : Form
    {
        public string Device_Name { get => textBox_Name.Text; set => textBox_Name.Text = value; }
        public string Device_UnitId { get => textBox_UnitId.Text; set => textBox_UnitId.Text = value; }
        public string Device_TcpPort { get => textBox_TcpPort.Text; set => textBox_TcpPort.Text = value; }

        public DeviceForm()
        {
            InitializeComponent();
            textBox_UnitId.Text = "1";
            textBox_TcpPort.Text = "502";
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_Name.Text))
            {
                MessageBox.Show("Enter a string", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_Name.SelectAll();
                return;
            }

            byte unitId;
            if (!byte.TryParse(textBox_UnitId.Text, out unitId))
            {
                MessageBox.Show("Enter an integer", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_UnitId.SelectAll();
                return;
            }
            if (unitId < 1 || unitId > 247)
            {
                MessageBox.Show("Enter an integer between 1 and 247", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_UnitId.SelectAll();
                return;
            }

            int tcpPort;
            if (!int.TryParse(textBox_TcpPort.Text, out tcpPort))
            {
                MessageBox.Show("Enter an integer", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_TcpPort.SelectAll();
                return;
            }
            if (tcpPort < 1 || tcpPort > 65536)
            {
                MessageBox.Show("Enter an integer between 1 and 65536", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_TcpPort.SelectAll();
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void textBox_UnitId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox_TcpPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
