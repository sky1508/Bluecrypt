namespace GUI_1
{
    partial class Start_form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Start_form));
            this.label1 = new System.Windows.Forms.Label();
            this.btn_new_user = new System.Windows.Forms.Button();
            this.btn_existing_user = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_register = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(289, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome Guest";
            // 
            // btn_new_user
            // 
            this.btn_new_user.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_new_user.Location = new System.Drawing.Point(90, 133);
            this.btn_new_user.Name = "btn_new_user";
            this.btn_new_user.Size = new System.Drawing.Size(114, 62);
            this.btn_new_user.TabIndex = 1;
            this.btn_new_user.Text = "New User";
            this.btn_new_user.UseVisualStyleBackColor = true;
            this.btn_new_user.Click += new System.EventHandler(this.btn_new_user_Click);
            // 
            // btn_existing_user
            // 
            this.btn_existing_user.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_existing_user.Location = new System.Drawing.Point(293, 133);
            this.btn_existing_user.Name = "btn_existing_user";
            this.btn_existing_user.Size = new System.Drawing.Size(114, 62);
            this.btn_existing_user.TabIndex = 2;
            this.btn_existing_user.Text = "Existing User";
            this.btn_existing_user.UseVisualStyleBackColor = true;
            this.btn_existing_user.Click += new System.EventHandler(this.btn_existing_user_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_exit.Location = new System.Drawing.Point(503, 133);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(114, 62);
            this.btn_exit.TabIndex = 3;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(90, 241);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(318, 29);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "Enter Your Email Id Here";
            this.textBox1.Click += new System.EventHandler(this.textBox1_Click);
            // 
            // btn_register
            // 
            this.btn_register.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_register.Location = new System.Drawing.Point(503, 241);
            this.btn_register.Name = "btn_register";
            this.btn_register.Size = new System.Drawing.Size(114, 29);
            this.btn_register.TabIndex = 5;
            this.btn_register.Text = "Register";
            this.btn_register.UseVisualStyleBackColor = true;
            this.btn_register.Click += new System.EventHandler(this.btn_register_Click);
            // 
            // btn_close
            // 
            this.btn_close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_close.Location = new System.Drawing.Point(662, 1);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(37, 23);
            this.btn_close.TabIndex = 24;
            this.btn_close.Text = "x";
            this.btn_close.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Khaki;
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(2, 338);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(700, 13);
            this.label2.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Khaki;
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(-1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(700, 24);
            this.label3.TabIndex = 22;
            // 
            // Start_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(700, 350);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_register);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_existing_user);
            this.Controls.Add(this.btn_new_user);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Start_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Start_form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_new_user;
        private System.Windows.Forms.Button btn_existing_user;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_register;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}