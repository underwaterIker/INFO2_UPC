
namespace Form1
{
    partial class LogIn
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
            this.userSU = new System.Windows.Forms.TextBox();
            this.passwordSU = new System.Windows.Forms.TextBox();
            this.userLI = new System.Windows.Forms.TextBox();
            this.passwordLI = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.signUpBtn = new System.Windows.Forms.Button();
            this.logInBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.recoverBtn = new System.Windows.Forms.Button();
            this.emailSU = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.changePasswordBtn = new System.Windows.Forms.Button();
            this.randomPasswordBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // userSU
            // 
            this.userSU.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userSU.Location = new System.Drawing.Point(137, 274);
            this.userSU.Name = "userSU";
            this.userSU.Size = new System.Drawing.Size(206, 40);
            this.userSU.TabIndex = 0;
            // 
            // passwordSU
            // 
            this.passwordSU.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordSU.Location = new System.Drawing.Point(137, 345);
            this.passwordSU.Name = "passwordSU";
            this.passwordSU.Size = new System.Drawing.Size(206, 40);
            this.passwordSU.TabIndex = 1;
            // 
            // userLI
            // 
            this.userLI.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userLI.Location = new System.Drawing.Point(591, 274);
            this.userLI.Name = "userLI";
            this.userLI.Size = new System.Drawing.Size(206, 40);
            this.userLI.TabIndex = 2;
            // 
            // passwordLI
            // 
            this.passwordLI.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLI.Location = new System.Drawing.Point(591, 345);
            this.passwordLI.Name = "passwordLI";
            this.passwordLI.Size = new System.Drawing.Size(206, 40);
            this.passwordLI.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(146, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 57);
            this.label1.TabIndex = 4;
            this.label1.Text = "Sign Up";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(610, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 57);
            this.label2.TabIndex = 5;
            this.label2.Text = "Log In";
            // 
            // signUpBtn
            // 
            this.signUpBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signUpBtn.Location = new System.Drawing.Point(169, 506);
            this.signUpBtn.Name = "signUpBtn";
            this.signUpBtn.Size = new System.Drawing.Size(144, 65);
            this.signUpBtn.TabIndex = 6;
            this.signUpBtn.Text = "Sign up";
            this.signUpBtn.UseVisualStyleBackColor = true;
            this.signUpBtn.Click += new System.EventHandler(this.signUpBtn_Click);
            // 
            // logInBtn
            // 
            this.logInBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logInBtn.Location = new System.Drawing.Point(627, 420);
            this.logInBtn.Name = "logInBtn";
            this.logInBtn.Size = new System.Drawing.Size(126, 65);
            this.logInBtn.TabIndex = 7;
            this.logInBtn.Text = "Log in";
            this.logInBtn.UseVisualStyleBackColor = true;
            this.logInBtn.Click += new System.EventHandler(this.logInBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Gold;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(391, 274);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 33);
            this.label3.TabIndex = 8;
            this.label3.Text = "Username";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Gold;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(391, 348);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 33);
            this.label4.TabIndex = 9;
            this.label4.Text = "Password";
            // 
            // recoverBtn
            // 
            this.recoverBtn.BackColor = System.Drawing.Color.LightCoral;
            this.recoverBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recoverBtn.Location = new System.Drawing.Point(539, 506);
            this.recoverBtn.Name = "recoverBtn";
            this.recoverBtn.Size = new System.Drawing.Size(292, 65);
            this.recoverBtn.TabIndex = 10;
            this.recoverBtn.Text = "Recover Password";
            this.recoverBtn.UseVisualStyleBackColor = false;
            this.recoverBtn.Click += new System.EventHandler(this.recoverBtn_Click);
            // 
            // emailSU
            // 
            this.emailSU.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailSU.Location = new System.Drawing.Point(137, 417);
            this.emailSU.Name = "emailSU";
            this.emailSU.Size = new System.Drawing.Size(206, 40);
            this.emailSU.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Gold;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(414, 420);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 33);
            this.label5.TabIndex = 12;
            this.label5.Text = "Email";
            // 
            // changePasswordBtn
            // 
            this.changePasswordBtn.BackColor = System.Drawing.Color.LightCoral;
            this.changePasswordBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changePasswordBtn.Location = new System.Drawing.Point(539, 595);
            this.changePasswordBtn.Name = "changePasswordBtn";
            this.changePasswordBtn.Size = new System.Drawing.Size(292, 65);
            this.changePasswordBtn.TabIndex = 13;
            this.changePasswordBtn.Text = "Change Password";
            this.changePasswordBtn.UseVisualStyleBackColor = false;
            this.changePasswordBtn.Click += new System.EventHandler(this.changePasswordBtn_Click);
            // 
            // randomPasswordBtn
            // 
            this.randomPasswordBtn.BackColor = System.Drawing.Color.LightCoral;
            this.randomPasswordBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.randomPasswordBtn.Location = new System.Drawing.Point(37, 595);
            this.randomPasswordBtn.Name = "randomPasswordBtn";
            this.randomPasswordBtn.Size = new System.Drawing.Size(426, 65);
            this.randomPasswordBtn.TabIndex = 14;
            this.randomPasswordBtn.Text = "Generate Random Password";
            this.randomPasswordBtn.UseVisualStyleBackColor = false;
            this.randomPasswordBtn.Click += new System.EventHandler(this.randomPasswordBtn_Click);
            // 
            // LogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BackgroundImage = global::Form1.Properties.Resources.bigplane;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(952, 709);
            this.Controls.Add(this.randomPasswordBtn);
            this.Controls.Add(this.changePasswordBtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.emailSU);
            this.Controls.Add(this.recoverBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.logInBtn);
            this.Controls.Add(this.signUpBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.passwordLI);
            this.Controls.Add(this.userLI);
            this.Controls.Add(this.passwordSU);
            this.Controls.Add(this.userSU);
            this.DoubleBuffered = true;
            this.Name = "LogIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LogIn";
            this.Load += new System.EventHandler(this.LogIn_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox userSU;
        private System.Windows.Forms.TextBox passwordSU;
        private System.Windows.Forms.TextBox userLI;
        private System.Windows.Forms.TextBox passwordLI;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button signUpBtn;
        private System.Windows.Forms.Button logInBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button recoverBtn;
        private System.Windows.Forms.TextBox emailSU;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button changePasswordBtn;
        private System.Windows.Forms.Button randomPasswordBtn;
    }
}