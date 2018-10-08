namespace Ptlk_ModbusSlaveV2.View
{
    partial class DeviceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_TcpPort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_UnitId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_OK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_TcpPort
            // 
            this.textBox_TcpPort.Location = new System.Drawing.Point(108, 74);
            this.textBox_TcpPort.Name = "textBox_TcpPort";
            this.textBox_TcpPort.Size = new System.Drawing.Size(162, 25);
            this.textBox_TcpPort.TabIndex = 11;
            this.textBox_TcpPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_TcpPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_TcpPort_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(3, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 24);
            this.label3.TabIndex = 10;
            this.label3.Text = "TCP Port:";
            // 
            // textBox_UnitId
            // 
            this.textBox_UnitId.Location = new System.Drawing.Point(108, 43);
            this.textBox_UnitId.Name = "textBox_UnitId";
            this.textBox_UnitId.Size = new System.Drawing.Size(162, 25);
            this.textBox_UnitId.TabIndex = 9;
            this.textBox_UnitId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_UnitId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_UnitId_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(3, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 24);
            this.label2.TabIndex = 8;
            this.label2.Text = "Unit Id:";
            // 
            // textBox_Name
            // 
            this.textBox_Name.Location = new System.Drawing.Point(108, 11);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(162, 25);
            this.textBox_Name.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "Name:";
            // 
            // button_OK
            // 
            this.button_OK.AutoSize = true;
            this.button_OK.Font = new System.Drawing.Font("新細明體", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_OK.Location = new System.Drawing.Point(195, 105);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 34);
            this.button_OK.TabIndex = 15;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // DeviceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 143);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.textBox_TcpPort);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_UnitId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_Name);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DeviceForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Device";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_TcpPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_UnitId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_OK;
    }
}