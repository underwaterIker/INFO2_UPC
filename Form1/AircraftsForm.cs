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
    public partial class AircraftsForm : Form
    {
        // Atributos
        public FlightPlanList flightPlanLista = new FlightPlanList();
        public List<PictureBox> picBoxLista = new List<PictureBox>();

        // InitializeComponent()
        public AircraftsForm()
        {
            InitializeComponent();
        }

        // Métodos
        private void button1_Click(object sender, EventArgs e)
        // Closes the Form when the user has ended inputting data
        {
            Close();
        }

        public FlightPlan FindFP(string tag)
        // Finds and returns the FlightPlan that has the same identification as the string given as a parameter (used for evento1, in order to know which aircraft is the user clicking on)
        {
            for(int i =0; i<picBoxLista.Count; i++)
            {
                if(this.flightPlanLista.GetLista()[i].DameId() == tag)
                {
                    return this.flightPlanLista.GetLista()[i];
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

            flightDataForm.TomaDatos(list, this.flightPlanLista.GetLista());
            flightDataForm.ShowDialog();

            //MessageBox.Show(fp.MostrarDatos());
        }

        private void button2_Click(object sender, EventArgs e)
        // Writes predetermined values on the TextBoxes
        {
            idA1Box.Text = "A";
            compA1Box.Text = "Vueling";
            ipA1Box.Text = "200 200";
            fpA1Box.Text = "600 600";
            velA1Box.Text = "300";
        }

        private void nextBtn_Click(object sender, EventArgs e)
        // Reads the data input manually by the user and creates a FlightPlan with it. After this, clears the TextBoxs so that the user can keep giving data and creating more FlightPlans
        {
            FlightPlan fp1 = new FlightPlan();
            PictureBox aircraft1 = new PictureBox();

            try
            {
                // Set FlightPlan
                string[] a1InitialPos = ipA1Box.Text.Split(' ');
                string[] a1FinalPos = fpA1Box.Text.Split(' ');

                double initialPosX = Convert.ToDouble(a1InitialPos[0]);
                double initialPosY = Convert.ToDouble(a1InitialPos[1]);
                double finalPosX = Convert.ToDouble(a1FinalPos[0]);
                double finalPosY = Convert.ToDouble(a1FinalPos[1]);
                double velocity = Convert.ToDouble(velA1Box.Text);

                // Initial position
                if (initialPosX >= 0 && initialPosX <= 900 && initialPosY >= 0 && initialPosY <= 800)
                {
                    //initialPosX = initialPosX;
                    //initialPosY = initialPosY;
                    //Position a1InitialPosition = new Position(initialPosX, initialPosY);
                }
                if (initialPosX < 0)
                {
                    initialPosX = 0;
                    MessageBox.Show("Coordinate X of 'Initial position' lower than permited values.\nThe minimum permited value (0) has been assigned.");
                }
                if (initialPosX > 900)
                {
                    initialPosX = 900;
                    MessageBox.Show("Coordinate X of 'Initial position' higher than permited values.\nThe maximum permited value (900) has been assigned.");
                }
                if (initialPosY < 0)
                {
                    initialPosY = 0;
                    MessageBox.Show("Coordinate Y of 'Initial position' lower than permited values.\nThe minimum permited value (0) has been assigned.");
                }
                if (initialPosY > 800)
                {
                    initialPosY = 800;
                    MessageBox.Show("Coordinate Y of 'Initial position' higher than permited values.\nThe maximum permited value (800) has been assigned.");
                }

                // Final position
                if (finalPosX >= 0 && finalPosX <= 900 && finalPosY >= 0 && finalPosY <= 800)
                {
                    //finalPosX = finalPosX;
                    //finalPosY = finalPosY;
                }
                if (finalPosX < 0)
                {
                    finalPosX = 0;
                    MessageBox.Show("Coordinate X of 'Final position' lower than permited values.\nThe minimum permited value (0) has been assigned.");
                }
                if (finalPosX > 900)
                {
                    finalPosX = 900;
                    MessageBox.Show("Coordinate X of 'Final position' higher than permited values.\nThe maximum permited value (900) has been assigned.");
                }
                if (finalPosY < 0)
                {
                    finalPosY = 0;
                    MessageBox.Show("Coordinate Y of 'Final position' lower than permited values.\nThe minimum permited value (0) has been assigned.");
                }
                if (finalPosY > 800)
                {
                    finalPosY = 800;
                    MessageBox.Show("Coordinate Y of 'Final position' higher than permited values.\nThe maximum permited value (800) has been assigned.");
                }

                // Velocity
                if(velocity >= 10 && velocity <= 500)
                {
                    //velocity = velocity;
                }
                if (velocity < 10)
                {
                    velocity = 10;
                    MessageBox.Show("'Velocity' lower than permited values.\nThe minimum permited value (10) has been assigned");
                }
                if (velocity > 500)
                {
                    velocity = 500;
                    MessageBox.Show("'Velocity' higher than permited values.\nThe maximum permited value (500) has been assigned");
                }

                Position a1InitialPosition = new Position(initialPosX, initialPosY);
                Position a1FinalPosition = new Position(finalPosX, finalPosY);
                fp1.SetId(idA1Box.Text);
                fp1.SetCompany(compA1Box.Text);
                fp1.SetCurrentPosition(a1InitialPosition);
                fp1.SetInitialPosition(a1InitialPosition);
                fp1.SetFinalPosition(a1FinalPosition);
                fp1.SetVelocidad(velocity);

                // Set PictureBox
                aircraft1.Width = 20;
                aircraft1.Height = 20;
                aircraft1.ClientSize = new Size(20, 20);
                aircraft1.Location = new Point(Convert.ToInt32(initialPosX) - 10, Convert.ToInt32(initialPosY) - 10);
                aircraft1.SizeMode = PictureBoxSizeMode.StretchImage;
                Bitmap image1 = new Bitmap("avion.png"); aircraft1.Image = (Image)image1;
                aircraft1.Tag = Convert.ToString(idA1Box.Text);
                aircraft1.Click += new System.EventHandler(this.evento1);


                this.flightPlanLista.GetLista().Add(fp1);
                this.picBoxLista.Add(aircraft1);

                idA1Box.Clear();
                compA1Box.Clear();
                ipA1Box.Clear();
                fpA1Box.Clear();
                velA1Box.Clear();
            }
            catch (FormatException)
            {
                idA1Box.Clear();
                compA1Box.Clear();
                ipA1Box.Clear();
                fpA1Box.Clear();
                velA1Box.Clear();
                MessageBox.Show("Format Error.\nTry again!");
            }
        }

        public FlightPlanList GetFlightPlanList()
        // Returns the FlightPlanList
        {
            return this.flightPlanLista;
        }

        public List<PictureBox> GetPicBoxList()
        // Returns the List of PictureBoxes
        {
            return this.picBoxLista;
        }
    }
}
