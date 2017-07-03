namespace GUI_1
{
    partial class bluetooth_form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(bluetooth_form1));
            this.device_list = new System.Windows.Forms.ListBox();
            this.selected_device = new System.Windows.Forms.ListBox();
            this.btn_find = new System.Windows.Forms.Button();
            this.add_device = new System.Windows.Forms.Button();
            this.btn_next = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_devicename = new System.Windows.Forms.TextBox();
            this.txt_lastseen = new System.Windows.Forms.TextBox();
            this.txt_remembered = new System.Windows.Forms.TextBox();
            this.txt_authenticated = new System.Windows.Forms.TextBox();
            this.txt_connected = new System.Windows.Forms.TextBox();
            this.txt_lastused = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btn_close = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // device_list
            // 
            this.device_list.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.device_list.FormattingEnabled = true;
            this.device_list.ItemHeight = 21;
            this.device_list.Location = new System.Drawing.Point(12, 25);
            this.device_list.Name = "device_list";
            this.device_list.Size = new System.Drawing.Size(230, 193);
            this.device_list.TabIndex = 2;
            this.device_list.SelectedIndexChanged += new System.EventHandler(this.device_list_SelectedIndexChanged);
            // 
            // selected_device
            // 
            this.selected_device.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selected_device.FormattingEnabled = true;
            this.selected_device.ItemHeight = 21;
            this.selected_device.Location = new System.Drawing.Point(12, 224);
            this.selected_device.Name = "selected_device";
            this.selected_device.Size = new System.Drawing.Size(230, 130);
            this.selected_device.TabIndex = 4;
            // 
            // btn_find
            // 
            this.btn_find.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_find.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_find.Location = new System.Drawing.Point(262, 40);
            this.btn_find.Name = "btn_find";
            this.btn_find.Size = new System.Drawing.Size(234, 27);
            this.btn_find.TabIndex = 1;
            this.btn_find.Text = "Find Bluetooth Devices";
            this.btn_find.UseVisualStyleBackColor = false;
            this.btn_find.Click += new System.EventHandler(this.btn_find_Click);
            // 
            // add_device
            // 
            this.add_device.BackColor = System.Drawing.Color.Gainsboro;
            this.add_device.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add_device.Location = new System.Drawing.Point(572, 40);
            this.add_device.Name = "add_device";
            this.add_device.Size = new System.Drawing.Size(159, 27);
            this.add_device.TabIndex = 3;
            this.add_device.Text = "Add Device";
            this.add_device.UseVisualStyleBackColor = false;
            this.add_device.Click += new System.EventHandler(this.add_device_Click);
            // 
            // btn_next
            // 
            this.btn_next.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_next.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_next.Location = new System.Drawing.Point(469, 327);
            this.btn_next.Name = "btn_next";
            this.btn_next.Size = new System.Drawing.Size(104, 27);
            this.btn_next.TabIndex = 4;
            this.btn_next.Text = "Next";
            this.btn_next.UseVisualStyleBackColor = false;
            this.btn_next.Click += new System.EventHandler(this.btn_next_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(266, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Device Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(501, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Connected";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(266, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Authenticated";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(266, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Remembered";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(268, 211);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "LastSeen";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(503, 211);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "LastUsed";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(268, 256);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "DeviceType";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(502, 256);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "MAC Address";
            // 
            // txt_devicename
            // 
            this.txt_devicename.Enabled = false;
            this.txt_devicename.Location = new System.Drawing.Point(344, 87);
            this.txt_devicename.Name = "txt_devicename";
            this.txt_devicename.Size = new System.Drawing.Size(306, 20);
            this.txt_devicename.TabIndex = 5;
            // 
            // txt_lastseen
            // 
            this.txt_lastseen.Enabled = false;
            this.txt_lastseen.Location = new System.Drawing.Point(344, 208);
            this.txt_lastseen.Name = "txt_lastseen";
            this.txt_lastseen.Size = new System.Drawing.Size(152, 20);
            this.txt_lastseen.TabIndex = 16;
            // 
            // txt_remembered
            // 
            this.txt_remembered.Enabled = false;
            this.txt_remembered.Location = new System.Drawing.Point(344, 165);
            this.txt_remembered.Name = "txt_remembered";
            this.txt_remembered.Size = new System.Drawing.Size(306, 20);
            this.txt_remembered.TabIndex = 17;
            // 
            // txt_authenticated
            // 
            this.txt_authenticated.Enabled = false;
            this.txt_authenticated.Location = new System.Drawing.Point(344, 127);
            this.txt_authenticated.Name = "txt_authenticated";
            this.txt_authenticated.Size = new System.Drawing.Size(150, 20);
            this.txt_authenticated.TabIndex = 6;
            // 
            // txt_connected
            // 
            this.txt_connected.Enabled = false;
            this.txt_connected.Location = new System.Drawing.Point(577, 127);
            this.txt_connected.Name = "txt_connected";
            this.txt_connected.Size = new System.Drawing.Size(152, 20);
            this.txt_connected.TabIndex = 7;
            // 
            // txt_lastused
            // 
            this.txt_lastused.Enabled = false;
            this.txt_lastused.Location = new System.Drawing.Point(579, 208);
            this.txt_lastused.Name = "txt_lastused";
            this.txt_lastused.Size = new System.Drawing.Size(152, 20);
            this.txt_lastused.TabIndex = 22;
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(579, 253);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(152, 20);
            this.textBox2.TabIndex = 23;
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(344, 249);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(152, 20);
            this.textBox1.TabIndex = 24;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(271, 293);
            this.progressBar1.MarqueeAnimationSpeed = 80;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(460, 23);
            this.progressBar1.Step = 0;
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 25;
            // 
            // btn_close
            // 
            this.btn_close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_close.Location = new System.Drawing.Point(717, -3);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(33, 24);
            this.btn_close.TabIndex = 37;
            this.btn_close.Text = "x";
            this.btn_close.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Khaki;
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label11.Location = new System.Drawing.Point(-2, 367);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(752, 13);
            this.label11.TabIndex = 36;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Khaki;
            this.label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label12.Location = new System.Drawing.Point(-7, -3);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(757, 24);
            this.label12.TabIndex = 35;
            // 
            // bluetooth_form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(750, 380);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.txt_lastused);
            this.Controls.Add(this.txt_connected);
            this.Controls.Add(this.txt_authenticated);
            this.Controls.Add(this.txt_remembered);
            this.Controls.Add(this.txt_lastseen);
            this.Controls.Add(this.txt_devicename);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_next);
            this.Controls.Add(this.add_device);
            this.Controls.Add(this.btn_find);
            this.Controls.Add(this.selected_device);
            this.Controls.Add(this.device_list);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "bluetooth_form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "bluetooth_form1";
            this.Load += new System.EventHandler(this.bluetooth_form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox device_list;
        private System.Windows.Forms.ListBox selected_device;
        private System.Windows.Forms.Button btn_find;
        private System.Windows.Forms.Button add_device;
        private System.Windows.Forms.Button btn_next;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_devicename;
        private System.Windows.Forms.TextBox txt_lastseen;
        private System.Windows.Forms.TextBox txt_remembered;
        private System.Windows.Forms.TextBox txt_authenticated;
        private System.Windows.Forms.TextBox txt_connected;
        private System.Windows.Forms.TextBox txt_lastused;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
    }
}