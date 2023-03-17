
namespace Form1
{
    partial class RandomPassword
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
            this.label1 = new System.Windows.Forms.Label();
            this.randomPasswordLbl = new System.Windows.Forms.Label();
            this.thisOneBtn = new System.Windows.Forms.Button();
            this.anotherOneBtn = new System.Windows.Forms.Button();
            this.closeBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(140, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(549, 51);
            this.label1.TabIndex = 0;
            this.label1.Text = "Recommended Password:";
            // 
            // randomPasswordLbl
            // 
            this.randomPasswordLbl.AutoSize = true;
            this.randomPasswordLbl.BackColor = System.Drawing.Color.Gold;
            this.randomPasswordLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.randomPasswordLbl.Location = new System.Drawing.Point(352, 283);
            this.randomPasswordLbl.Name = "randomPasswordLbl";
            this.randomPasswordLbl.Size = new System.Drawing.Size(0, 37);
            this.randomPasswordLbl.TabIndex = 1;
            // 
            // thisOneBtn
            // 
            this.thisOneBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thisOneBtn.Location = new System.Drawing.Point(104, 417);
            this.thisOneBtn.Name = "thisOneBtn";
            this.thisOneBtn.Size = new System.Drawing.Size(233, 104);
            this.thisOneBtn.TabIndex = 2;
            this.thisOneBtn.Text = "I want this one";
            this.thisOneBtn.UseVisualStyleBackColor = true;
            this.thisOneBtn.Click += new System.EventHandler(this.thisOneBtn_Click);
            // 
            // anotherOneBtn
            // 
            this.anotherOneBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.anotherOneBtn.Location = new System.Drawing.Point(468, 417);
            this.anotherOneBtn.Name = "anotherOneBtn";
            this.anotherOneBtn.Size = new System.Drawing.Size(233, 104);
            this.anotherOneBtn.TabIndex = 3;
            this.anotherOneBtn.Text = "Give me another one";
            this.anotherOneBtn.UseVisualStyleBackColor = true;
            this.anotherOneBtn.Click += new System.EventHandler(this.anotherOneBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtn.Location = new System.Drawing.Point(302, 577);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(192, 89);
            this.closeBtn.TabIndex = 4;
            this.closeBtn.Text = "Close";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // RandomPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(826, 704);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.anotherOneBtn);
            this.Controls.Add(this.thisOneBtn);
            this.Controls.Add(this.randomPasswordLbl);
            this.Controls.Add(this.label1);
            this.Name = "RandomPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RandomPassword";
            this.Load += new System.EventHandler(this.RandomPassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label randomPasswordLbl;
        private System.Windows.Forms.Button thisOneBtn;
        private System.Windows.Forms.Button anotherOneBtn;
        private System.Windows.Forms.Button closeBtn;
    }
}