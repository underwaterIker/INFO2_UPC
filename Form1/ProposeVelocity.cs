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
    public partial class ProposeVelocity : Form
    {
        // Atributos
        FlightPlanList fpListOriginal;
        FlightPlanList fpListCopia;

        List<FlightPlan> oldVels = new List<FlightPlan>();
        List<FlightPlan> newVels = new List<FlightPlan>();

        bool accept;

        // InitializeComponent()
        public ProposeVelocity()
        {
            InitializeComponent();
        }

        // Métodos
        public void TomaDatos(FlightPlanList fplOriginal, FlightPlanList fplCopia)
        // Receives the necessary data
        {
            this.fpListOriginal = fplOriginal;
            this.fpListCopia = fplCopia;
        }

        public bool DameAccept()
        // Returns true if the user has clicked "Accept", and False if the user chas clicked "Reject"
        {
            return this.accept;
        }

        public List<FlightPlan> GetOldVels()
        //Returns the vector with the old velocities
        {
            return this.oldVels;
        }

        public List<FlightPlan> GetNewVels()
        // Returns the vector with the new velocities
        {
            return this.newVels;
        }

        private void ProposeVelocity_Load(object sender, EventArgs e)
        // Shows in a DataGriedView the velocity changes proposed in order to avoid any conflict. (user can decide whether to accept those changes or not)
        {
            for (int i = 0; i < this.fpListOriginal.GetLista().Count; i++)
            {
                FlightPlan fp = new FlightPlan();
                fp.CopiarFlightPlan(this.fpListOriginal.GetLista()[i]);
                this.oldVels.Add(fp);
            }

            dataGridView1.RowCount = this.fpListCopia.GetLista().Count + 1;
            dataGridView1.ColumnCount = 2;

            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.RowHeadersVisible = false;

            // Row[0] bold
            dataGridView1.Rows[0].DefaultCellStyle.Font = new Font("Tahoma", 11, FontStyle.Bold);

            // Headers
            dataGridView1.Rows[0].Cells[0].Value = "ID";
            dataGridView1.Rows[0].Cells[1].Value = "VELOCITY";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            for(int i = 0; i < this.fpListCopia.GetLista().Count; i++)
            {
                dataGridView1.Rows[i+1].Cells[0].Value = fpListCopia.GetLista()[i].DameId();
                dataGridView1.Rows[i+1].Cells[1].Value = Convert.ToString(fpListCopia.GetLista()[i].DameVelocidad());
            }

            // Clears the selection
            dataGridView1.ClearSelection();

            // The user can't edit the tables
            dataGridView1.ReadOnly = true;
        }

        private void acceptBtn_Click(object sender, EventArgs e)
        // Sets the bool as true and closes the Form
        {
            for (int i = 0; i < this.fpListCopia.GetLista().Count; i++)
            {
                FlightPlan fp = new FlightPlan();
                fp.CopiarFlightPlan(this.fpListCopia.GetLista()[i]);
                this.newVels.Add(fp);
            }

            this.accept = true;
            Close();
        }

        private void rejectBtn_Click(object sender, EventArgs e)
        // Sets the bool as false and closes the Form
        {
            this.newVels = this.oldVels;

            this.accept = false;
            Close();
        }
    }
}
