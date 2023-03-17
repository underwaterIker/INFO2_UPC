using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form1
{
    public partial class Tutorial : Form
    {
        // Atributos
        string info;
        bool continueTutorial;

        // InitializeComponent()
        public Tutorial()
        {
            InitializeComponent();
        }

        // Métodos
        public void TomaDatos(string info)
        // Gets the info message that will be displayed in the Form
        {
            this.info = info;
        }

        public bool GetContinueTutorial()
        // Returns 'true' if the user has clicked 'Continue', and 'false' if the user has clicked 'End Tutorial'
        {
            return this.continueTutorial;
        }

        private void Tutorial_Load(object sender, EventArgs e)
        // Displays the info message
        {
            this.continueTutorial = new bool();
            infoLbl.Text = this.info;
        }

        private void continueBtn_Click(object sender, EventArgs e)
        // Sets the 'continueTutorial' bool as 'true' and closes the Form
        {
            this.continueTutorial = true;
            this.Close();
        }

        private void endTutorialBtn_Click(object sender, EventArgs e)
        // Sets the 'continueTutorial' bool as 'false' and closes the Form
        {
            this.continueTutorial = false;
            this.Close();
        }
    }
}
