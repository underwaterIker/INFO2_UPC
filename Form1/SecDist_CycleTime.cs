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
    public partial class SecDist_CycleTime : Form
    {
        // Atributos
        double securityDistance;
        double cycleTime;

        // InitializeComponent()
        public SecDist_CycleTime()
        {
            InitializeComponent();
        }

        // Métodos
        private void button1_Click(object sender, EventArgs e)
        // Obtains the values that the user has input on the TextBoxes and sets the "Security distance" and the "Cycle time"
        {
            try
            {
                double secDist = Convert.ToDouble(secDistBox.Text);
                double cycTime = Convert.ToDouble(cycleTimeBox.Text);
                if(secDist>=15 && secDist <= 40)
                {
                    this.securityDistance = secDist;
                }
                if (secDist < 15)
                {
                    this.securityDistance = 15;
                    MessageBox.Show("The input 'Security distance' is lower than the minimum permited value.\nThe minimum permited value (15) has been assigned as your 'Security distance'");
                }
                if (secDist > 40)
                {
                    this.securityDistance = 40;
                    MessageBox.Show("The input 'Security distance' is higher than the maximum permited value.\nThe maximum permited value (40) has been assigned as your 'Security distance'");
                }
                if (cycTime >= 0.1 && cycTime <= 5)
                {
                    this.cycleTime = cycTime;
                }
                if (cycTime < 0.1)
                {
                    this.cycleTime = 0.1;
                    MessageBox.Show("The input 'Cycle time' is lower than the minimum permited value.\nThe minimum permited value (0.1) has been assigned as your 'Cycle time'");
                }
                if (cycTime >5)
                {
                    this.cycleTime = 5;
                    MessageBox.Show("The input 'Cycle time' is higher than the maximum permited value.\nThe maximum permited value (5) has been assigned as your 'Cycle time'");
                }

                Close();
            }
            catch (FormatException)
            {
                secDistBox.Clear();
                cycleTimeBox.Clear();
                MessageBox.Show("Format Error");
            }
        }

        public double GetSecurityDistance()
        // Returns the "Security distance"
        {
            return this.securityDistance;
        }

        public double GetCycleTime()
        // Returns the "Cycle time"
        {
            return this.cycleTime;
        }

        private void predetBtn_Click(object sender, EventArgs e)
        // Puts predetermined values on the TextBoxes
        {
            secDistBox.Text = "30";
            cycleTimeBox.Text = "1";
        }
    }
}
