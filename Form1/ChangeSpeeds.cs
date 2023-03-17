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
    public partial class ChangeSpeeds : Form
    {
        // Atributos
        FlightPlanList fpList = new FlightPlanList();

        List<FlightPlan> oldVels = new List<FlightPlan>();
        List<FlightPlan> newVels = new List<FlightPlan>();

        // InitializeComponent()
        public ChangeSpeeds()
        {
            InitializeComponent();
        }

        // Métodos
        public void TomaDatos(FlightPlanList fplist)
        // Receives the necessary data in order to know the current velocities so that they can be changed by the user
        {
            this.fpList = fplist;
        }

        public FlightPlanList GetFlightPlanList()
        // Returns the aircraftsForm updated with the new velocities given by the user
        {
            return this.fpList;
        }

        public List<FlightPlan> GetOldVels()
        // Returns the vector with the old velocities
        {
            return this.oldVels;
        }

        public List<FlightPlan> GetNewVels()
        // Returns the vector with the new velocities
        {
            return this.newVels;
        }

        private void button1_Click(object sender, EventArgs e)
        // Applies the changes, if any, given by the user on the velocities. (FlightPlans are updated with the new velocities)
        {
            try
            {
                for (int i = 0; i < this.fpList.GetLista().Count; i++)
                {
                    double velocity = Convert.ToDouble(dataGridView1.Rows[i+1].Cells[1].Value);
                    string id = this.fpList.GetLista()[i].DameId();

                    // Velocity
                    if (velocity >= 10 && velocity <= 500)
                    {
                        //velocity = velocity;
                    }
                    if (velocity < 10)
                    {
                        velocity = 10;
                        MessageBox.Show("'Velocity' of " + id + " lower than permited values.\nThe minimum permited value (10) has been assigned");
                    }
                    if (velocity > 500)
                    {
                        velocity = 500;
                        MessageBox.Show("'Velocity' of " + id + " higher than permited values.\nThe maximum permited value (500) has been assigned");
                    }
                    // Sets the new velocity
                    this.fpList.GetLista()[i].SetVelocidad(velocity);

                    FlightPlan fp = new FlightPlan();
                    fp.CopiarFlightPlan(this.fpList.GetLista()[i]);
                    this.newVels.Add(fp);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Format Error");
            }

            Close();
        }

        private void ChangeSpeeds_Load(object sender, EventArgs e)
        // Shows in a DataGriedView the current velocities of the aircrafts
        {
            for (int i = 0; i < this.fpList.GetLista().Count; i++)
            {
                FlightPlan fp = new FlightPlan();
                fp.CopiarFlightPlan(this.fpList.GetLista()[i]);
                this.oldVels.Add(fp);
            }

            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ColumnHeadersVisible = false;

            dataGridView1.RowCount = this.fpList.GetLista().Count + 1;
            dataGridView1.ColumnCount = 2;

            // Row[0] bold
            dataGridView1.Rows[0].DefaultCellStyle.Font = new Font("Tahoma", 11, FontStyle.Bold);

            // Headers
            dataGridView1.Rows[0].Cells[0].Value = "ID";
            dataGridView1.Rows[0].Cells[1].Value = "VELOCITY";

            for (int i = 0; i< this.fpList.GetLista().Count; i++)
            {
                dataGridView1.Rows[i+1].Cells[0].Value = this.fpList.GetLista()[i].DameId();
                dataGridView1.Rows[i+1].Cells[1].Value = this.fpList.GetLista()[i].DameVelocidad();
            }

            // Clears the selection
            dataGridView1.ClearSelection();
        }
    }
}
