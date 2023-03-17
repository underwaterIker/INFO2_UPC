
namespace Form1
{
    partial class Menu
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
            this.manuallyBtn = new System.Windows.Forms.Button();
            this.fileBtn = new System.Windows.Forms.Button();
            this.dataBtn = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // manuallyBtn
            // 
            this.manuallyBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.manuallyBtn.FlatAppearance.BorderSize = 2;
            this.manuallyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manuallyBtn.Location = new System.Drawing.Point(160, 131);
            this.manuallyBtn.Name = "manuallyBtn";
            this.manuallyBtn.Size = new System.Drawing.Size(340, 99);
            this.manuallyBtn.TabIndex = 0;
            this.manuallyBtn.Text = "Input Flight Plans manually";
            this.manuallyBtn.UseVisualStyleBackColor = true;
            this.manuallyBtn.Click += new System.EventHandler(this.manually_Click);
            // 
            // fileBtn
            // 
            this.fileBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.fileBtn.FlatAppearance.BorderSize = 2;
            this.fileBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileBtn.Location = new System.Drawing.Point(160, 289);
            this.fileBtn.Name = "fileBtn";
            this.fileBtn.Size = new System.Drawing.Size(340, 99);
            this.fileBtn.TabIndex = 1;
            this.fileBtn.Text = "Input Flight Plans from a File";
            this.fileBtn.UseVisualStyleBackColor = true;
            this.fileBtn.Click += new System.EventHandler(this.fileBtn_Click);
            // 
            // dataBtn
            // 
            this.dataBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.dataBtn.FlatAppearance.BorderSize = 2;
            this.dataBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataBtn.Location = new System.Drawing.Point(118, 444);
            this.dataBtn.Name = "dataBtn";
            this.dataBtn.Size = new System.Drawing.Size(407, 99);
            this.dataBtn.TabIndex = 2;
            this.dataBtn.Text = "Input Security Distance and Cycle Time";
            this.dataBtn.UseVisualStyleBackColor = true;
            this.dataBtn.Click += new System.EventHandler(this.dataBtn_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BackgroundImage = global::Form1.Properties.Resources.tree;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(698, 652);
            this.Controls.Add(this.dataBtn);
            this.Controls.Add(this.fileBtn);
            this.Controls.Add(this.manuallyBtn);
            this.DoubleBuffered = true;
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button manuallyBtn;
        private System.Windows.Forms.Button fileBtn;
        private System.Windows.Forms.Button dataBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}