
namespace Form1
{
    partial class Main
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.moveAutoBtn = new System.Windows.Forms.Button();
            this.posLabel = new System.Windows.Forms.Label();
            this.Reloj = new System.Windows.Forms.Timer(this.components);
            this.moveOneCycleBtn = new System.Windows.Forms.Button();
            this.flightDataBtn = new System.Windows.Forms.Button();
            this.conflictBtn = new System.Windows.Forms.Button();
            this.restartBtn = new System.Windows.Forms.Button();
            this.changeVelBtn = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.undoBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.saveFileVelChangesBtn = new System.Windows.Forms.Button();
            this.showDatabaseBtn = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Location = new System.Drawing.Point(440, 54);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(900, 800);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseLeave += new System.EventHandler(this.panel1_MouseLeave);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Info;
            this.label1.Location = new System.Drawing.Point(410, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Info;
            this.label2.Location = new System.Drawing.Point(434, 27);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Info;
            this.label3.Location = new System.Drawing.Point(390, 829);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "799";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Info;
            this.label4.Location = new System.Drawing.Point(1292, 27);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "899";
            // 
            // moveAutoBtn
            // 
            this.moveAutoBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moveAutoBtn.Location = new System.Drawing.Point(24, 137);
            this.moveAutoBtn.Margin = new System.Windows.Forms.Padding(4);
            this.moveAutoBtn.Name = "moveAutoBtn";
            this.moveAutoBtn.Size = new System.Drawing.Size(369, 54);
            this.moveAutoBtn.TabIndex = 6;
            this.moveAutoBtn.Text = "Move Automatically";
            this.moveAutoBtn.UseVisualStyleBackColor = true;
            this.moveAutoBtn.Click += new System.EventHandler(this.moveAutoBtn_Click);
            // 
            // posLabel
            // 
            this.posLabel.BackColor = System.Drawing.SystemColors.Info;
            this.posLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.posLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.posLabel.Location = new System.Drawing.Point(774, 15);
            this.posLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.posLabel.Name = "posLabel";
            this.posLabel.Size = new System.Drawing.Size(218, 35);
            this.posLabel.TabIndex = 7;
            this.posLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Reloj
            // 
            this.Reloj.Tick += new System.EventHandler(this.Reloj_Tick);
            // 
            // moveOneCycleBtn
            // 
            this.moveOneCycleBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moveOneCycleBtn.Location = new System.Drawing.Point(24, 54);
            this.moveOneCycleBtn.Name = "moveOneCycleBtn";
            this.moveOneCycleBtn.Size = new System.Drawing.Size(369, 58);
            this.moveOneCycleBtn.TabIndex = 10;
            this.moveOneCycleBtn.Text = "Move One Cycle";
            this.moveOneCycleBtn.UseVisualStyleBackColor = true;
            this.moveOneCycleBtn.Click += new System.EventHandler(this.moveOneCycleBtn_Click);
            // 
            // flightDataBtn
            // 
            this.flightDataBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flightDataBtn.Location = new System.Drawing.Point(24, 211);
            this.flightDataBtn.Name = "flightDataBtn";
            this.flightDataBtn.Size = new System.Drawing.Size(369, 56);
            this.flightDataBtn.TabIndex = 11;
            this.flightDataBtn.Text = "Flight data";
            this.flightDataBtn.UseVisualStyleBackColor = true;
            this.flightDataBtn.Click += new System.EventHandler(this.flightDataBtn_Click);
            // 
            // conflictBtn
            // 
            this.conflictBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.conflictBtn.Location = new System.Drawing.Point(24, 288);
            this.conflictBtn.Name = "conflictBtn";
            this.conflictBtn.Size = new System.Drawing.Size(369, 57);
            this.conflictBtn.TabIndex = 12;
            this.conflictBtn.Text = "Check Conflict";
            this.conflictBtn.UseVisualStyleBackColor = true;
            this.conflictBtn.Click += new System.EventHandler(this.conflictBtn_Click);
            // 
            // restartBtn
            // 
            this.restartBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.restartBtn.Location = new System.Drawing.Point(24, 361);
            this.restartBtn.Name = "restartBtn";
            this.restartBtn.Size = new System.Drawing.Size(369, 57);
            this.restartBtn.TabIndex = 13;
            this.restartBtn.Text = "Restart";
            this.restartBtn.UseVisualStyleBackColor = true;
            this.restartBtn.Click += new System.EventHandler(this.restartBtn_Click);
            // 
            // changeVelBtn
            // 
            this.changeVelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changeVelBtn.Location = new System.Drawing.Point(24, 434);
            this.changeVelBtn.Name = "changeVelBtn";
            this.changeVelBtn.Size = new System.Drawing.Size(369, 56);
            this.changeVelBtn.TabIndex = 14;
            this.changeVelBtn.Text = "Change Velocity";
            this.changeVelBtn.UseVisualStyleBackColor = true;
            this.changeVelBtn.Click += new System.EventHandler(this.changeVelBtn_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // undoBtn
            // 
            this.undoBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.undoBtn.Location = new System.Drawing.Point(24, 511);
            this.undoBtn.Name = "undoBtn";
            this.undoBtn.Size = new System.Drawing.Size(369, 55);
            this.undoBtn.TabIndex = 15;
            this.undoBtn.Text = "Undo last simulation step";
            this.undoBtn.UseVisualStyleBackColor = true;
            this.undoBtn.Click += new System.EventHandler(this.undoBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtn.Location = new System.Drawing.Point(24, 585);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(369, 62);
            this.saveBtn.TabIndex = 16;
            this.saveBtn.Text = "Save Flight Plan List";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // saveFileVelChangesBtn
            // 
            this.saveFileVelChangesBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveFileVelChangesBtn.Location = new System.Drawing.Point(24, 664);
            this.saveFileVelChangesBtn.Name = "saveFileVelChangesBtn";
            this.saveFileVelChangesBtn.Size = new System.Drawing.Size(369, 60);
            this.saveFileVelChangesBtn.TabIndex = 17;
            this.saveFileVelChangesBtn.Text = "Save File with Velocity changes";
            this.saveFileVelChangesBtn.UseVisualStyleBackColor = true;
            this.saveFileVelChangesBtn.Click += new System.EventHandler(this.saveFileVelChangesBtn_Click);
            // 
            // showDatabaseBtn
            // 
            this.showDatabaseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showDatabaseBtn.Location = new System.Drawing.Point(24, 740);
            this.showDatabaseBtn.Name = "showDatabaseBtn";
            this.showDatabaseBtn.Size = new System.Drawing.Size(369, 56);
            this.showDatabaseBtn.TabIndex = 18;
            this.showDatabaseBtn.Text = "Show info in the Database";
            this.showDatabaseBtn.UseVisualStyleBackColor = true;
            this.showDatabaseBtn.Click += new System.EventHandler(this.showDatabaseBtn_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1351, 40);
            this.menuStrip1.TabIndex = 19;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(116, 36);
            this.optionsToolStripMenuItem.Text = "Tutorial";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::Form1.Properties.Resources.nube3;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1351, 859);
            this.Controls.Add(this.showDatabaseBtn);
            this.Controls.Add(this.saveFileVelChangesBtn);
            this.Controls.Add(this.conflictBtn);
            this.Controls.Add(this.flightDataBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.undoBtn);
            this.Controls.Add(this.changeVelBtn);
            this.Controls.Add(this.restartBtn);
            this.Controls.Add(this.moveOneCycleBtn);
            this.Controls.Add(this.posLabel);
            this.Controls.Add(this.moveAutoBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button moveAutoBtn;
        private System.Windows.Forms.Label posLabel;
        private System.Windows.Forms.Timer Reloj;
        private System.Windows.Forms.Button moveOneCycleBtn;
        private System.Windows.Forms.Button flightDataBtn;
        private System.Windows.Forms.Button conflictBtn;
        private System.Windows.Forms.Button restartBtn;
        private System.Windows.Forms.Button changeVelBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button undoBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button saveFileVelChangesBtn;
        private System.Windows.Forms.Button showDatabaseBtn;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
    }
}

