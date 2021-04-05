namespace SomerenUI
{
    partial class Registration_form
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
            this.User_name_text = new System.Windows.Forms.Label();
            this.username_in = new System.Windows.Forms.TextBox();
            this.Reg_label = new System.Windows.Forms.Label();
            this.Password_in = new System.Windows.Forms.TextBox();
            this.Verification_key_in = new System.Windows.Forms.TextBox();
            this.password_text = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPassConfirm = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // User_name_text
            // 
            this.User_name_text.AutoSize = true;
            this.User_name_text.Location = new System.Drawing.Point(26, 43);
            this.User_name_text.Name = "User_name_text";
            this.User_name_text.Size = new System.Drawing.Size(73, 17);
            this.User_name_text.TabIndex = 0;
            this.User_name_text.Text = "Username";
            this.User_name_text.Click += new System.EventHandler(this.Label1_Click);
            // 
            // username_in
            // 
            this.username_in.Location = new System.Drawing.Point(29, 63);
            this.username_in.Name = "username_in";
            this.username_in.Size = new System.Drawing.Size(115, 22);
            this.username_in.TabIndex = 1;
            // 
            // Reg_label
            // 
            this.Reg_label.AutoSize = true;
            this.Reg_label.Location = new System.Drawing.Point(225, 33);
            this.Reg_label.Name = "Reg_label";
            this.Reg_label.Size = new System.Drawing.Size(120, 17);
            this.Reg_label.TabIndex = 2;
            this.Reg_label.Text = "Registration page";
            // 
            // Password_in
            // 
            this.Password_in.Location = new System.Drawing.Point(29, 152);
            this.Password_in.Name = "Password_in";
            this.Password_in.Size = new System.Drawing.Size(115, 22);
            this.Password_in.TabIndex = 3;
            // 
            // Verification_key_in
            // 
            this.Verification_key_in.Location = new System.Drawing.Point(203, 254);
            this.Verification_key_in.Name = "Verification_key_in";
            this.Verification_key_in.Size = new System.Drawing.Size(142, 22);
            this.Verification_key_in.TabIndex = 4;
            // 
            // password_text
            // 
            this.password_text.AutoSize = true;
            this.password_text.Location = new System.Drawing.Point(31, 111);
            this.password_text.Name = "password_text";
            this.password_text.Size = new System.Drawing.Size(68, 17);
            this.password_text.TabIndex = 5;
            this.password_text.Text = "password";
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(203, 332);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(157, 23);
            this.btnRegister.TabIndex = 6;
            this.btnRegister.Text = "Verify and Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.BtnRegister_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(225, 230);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "license key";
            this.label1.Click += new System.EventHandler(this.Label1_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 207);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "confirm password";
            // 
            // txtPassConfirm
            // 
            this.txtPassConfirm.Location = new System.Drawing.Point(29, 254);
            this.txtPassConfirm.Name = "txtPassConfirm";
            this.txtPassConfirm.Size = new System.Drawing.Size(115, 22);
            this.txtPassConfirm.TabIndex = 8;
            // 
            // Registration_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPassConfirm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.password_text);
            this.Controls.Add(this.Verification_key_in);
            this.Controls.Add(this.Password_in);
            this.Controls.Add(this.Reg_label);
            this.Controls.Add(this.username_in);
            this.Controls.Add(this.User_name_text);
            this.Name = "Registration_form";
            this.Text = "Registration";
            this.Load += new System.EventHandler(this.Registration_form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label User_name_text;
        private System.Windows.Forms.TextBox username_in;
        private System.Windows.Forms.Label Reg_label;
        private System.Windows.Forms.TextBox Password_in;
        private System.Windows.Forms.TextBox Verification_key_in;
        private System.Windows.Forms.Label password_text;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPassConfirm;
    }
}