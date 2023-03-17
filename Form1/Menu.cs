using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlightLib;

namespace Form1
{
    public partial class Menu : Form
    {
        // Atributos
        FlightPlanList fpList = new FlightPlanList();
        List<PictureBox> picBoxLista = new List<PictureBox>();

        double secDist;
        double cycleTime;

        // InitializeComponent()
        public Menu()
        {
            InitializeComponent();
        }

        // Métodos
        public FlightPlanList GetFlightPlanList()
        // Returns the FlightPlanList
        {
            return this.fpList;
        }

        public List<PictureBox> GetPicBoxList()
        // Returns the List of PictureBoxes
        {
            return this.picBoxLista;
        }

        public double GetSecurityDistance()
        // Returns the 'Security distance'
        {
            return this.secDist;
        }

        public double GetCycleTime()
        // Returns the 'Cycle time'
        {
            return this.cycleTime;
        }

        private void manually_Click(object sender, EventArgs e)
        // Opens the AircraftsForm Form in order to manually input the data of different FlightPlans
        {
            AircraftsForm aircraftsForm = new AircraftsForm();

            aircraftsForm.ShowDialog();

            if(aircraftsForm.GetFlightPlanList().GetLista().Count != 0 && aircraftsForm.GetPicBoxList().Count != 0)
            {
                this.fpList = aircraftsForm.GetFlightPlanList();
                this.picBoxLista = aircraftsForm.GetPicBoxList();

                if (dataBtn.Enabled is false)
                {
                    this.Hide();
                }
                else
                {
                    manuallyBtn.Enabled = false;
                    fileBtn.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("You have NOT input any data!");
            }
        }

        private void fileBtn_Click(object sender, EventArgs e)
        // The user can select a (.txt) file with FlightPlans data so that you don't have to input data manually
        {
            try
            {
                openFileDialog1.ShowDialog();
                string fileName = openFileDialog1.FileName;
                try
                {
                    this.fpList.ReadFile(fileName);

                    for (int i = 0; i < this.fpList.GetLista().Count; i++)
                    {
                        PictureBox aircraft1 = new PictureBox();
                        aircraft1.Width = 20;
                        aircraft1.Height = 20;
                        aircraft1.ClientSize = new Size(20, 20);
                        aircraft1.Location = new Point(Convert.ToInt32(fpList.GetLista()[i].DameCurrentPosition().GetX()) - 10, Convert.ToInt32(fpList.GetLista()[i].DameCurrentPosition().GetY()) - 10);
                        aircraft1.SizeMode = PictureBoxSizeMode.StretchImage;
                        Bitmap image1 = new Bitmap("avion.png"); aircraft1.Image = (Image)image1;
                        aircraft1.Tag = fpList.GetLista()[i].DameId();
                        aircraft1.Click += new System.EventHandler(this.evento1);

                        this.picBoxLista.Add(aircraft1);
                    }

                    if (dataBtn.Enabled is false)
                    {
                        this.Hide();
                    }
                    else
                    {
                        manuallyBtn.Enabled = false;
                        fileBtn.Enabled = false;
                    }

                }
                catch
                {
                    MessageBox.Show("Incorrect data");
                }
            }
            catch
            {
                MessageBox.Show("Format Error");
            }
        }

        public FlightPlan FindFP(string tag)
        // Finds and returns the FlightPlan that has the same identification as the string given as a parameter (used for evento1, in order to know which aircraft is the user clicking on)
        {
            for (int i = 0; i < picBoxLista.Count; i++)
            {
                if (this.fpList.GetLista()[i].DameId() == tag)
                {
                    return this.fpList.GetLista()[i];
                }
            }
            return null;
        }

        private void evento1(object sender, EventArgs e)
        // Event that executes when one PictureBox is clicked, it shows the data of the aircraft you have clicked on
        {
            FlightData flightDataForm = new FlightData();

            PictureBox p = (PictureBox)sender;
            string nombre = (string)p.Tag;

            FlightPlan fp = this.FindFP(nombre);

            List<FlightPlan> list = new List<FlightPlan>();
            list.Add(fp);

            flightDataForm.TomaDatos(list, this.fpList.GetLista());
            flightDataForm.ShowDialog();

            //MessageBox.Show(fp.MostrarDatos());
        }

        private void dataBtn_Click(object sender, EventArgs e)
        // Opens the SecDist_CycleTime Form in order to input the security distance and the cycle time
        {
            SecDist_CycleTime secDist_cycleTimeForm = new SecDist_CycleTime();
            secDist_cycleTimeForm.ShowDialog();

            if(secDist_cycleTimeForm.GetSecurityDistance() != 0 && secDist_cycleTimeForm.GetCycleTime() != 0)
            {
                this.secDist = secDist_cycleTimeForm.GetSecurityDistance();
                this.cycleTime = secDist_cycleTimeForm.GetCycleTime();

                if (manuallyBtn.Enabled is false && fileBtn.Enabled is false)
                {
                    this.Hide();
                }
                else
                {
                    dataBtn.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("You have NOT input any data!");
            }
        }
    }
}
