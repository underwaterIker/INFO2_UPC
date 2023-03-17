
namespace Form1
{
    partial class Tutorial
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
            this.infoLbl = new System.Windows.Forms.Label();
            this.continueBtn = new System.Windows.Forms.Button();
            this.endTutorialBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // infoLbl
            // 
            this.infoLbl.AutoSize = true;
            this.infoLbl.BackColor = System.Drawing.SystemColors.Info;
            this.infoLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.infoLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoLbl.Location = new System.Drawing.Point(134, 119);
            this.infoLbl.Name = "infoLbl";
            this.infoLbl.Size = new System.Drawing.Size(2, 39);
            this.infoLbl.TabIndex = 0;
            // 
            // continueBtn
            // 
            this.continueBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.continueBtn.Location = new System.Drawing.Point(214, 464);
            this.continueBtn.Name = "continueBtn";
            this.continueBtn.Size = new System.Drawing.Size(198, 87);
            this.continueBtn.TabIndex = 1;
            this.continueBtn.Text = "Continue";
            this.continueBtn.UseVisualStyleBackColor = true;
            this.continueBtn.Click += new System.EventHandler(this.continueBtn_Click);
            // 
            // endTutorialBtn
            // 
            this.endTutorialBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endTutorialBtn.Location = new System.Drawing.Point(522, 464);
            this.endTutorialBtn.Name = "endTutorialBtn";
            this.endTutorialBtn.Size = new System.Drawing.Size(226, 87);
            this.endTutorialBtn.TabIndex = 2;
            this.endTutorialBtn.Text = "End Tutorial";
            this.endTutorialBtn.UseVisualStyleBackColor = true;
            this.endTutorialBtn.Click += new System.EventHandler(this.endTutorialBtn_Click);
            // 
            // Tutorial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(936, 618);
            this.Controls.Add(this.endTutorialBtn);
            this.Controls.Add(this.continueBtn);
            this.Controls.Add(this.infoLbl);
            this.Name = "Tutorial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tutorial";
            this.Load += new System.EventHandler(this.Tutorial_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label infoLbl;
        private System.Windows.Forms.Button continueBtn;
        private System.Windows.Forms.Button endTutorialBtn;
    }
}