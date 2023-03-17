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
    public partial class FlightData : Form
    {
        // Atributos
        List<FlightPlan> lista = new List<FlightPlan>();
        List<FlightPlan> listaFull = new List<FlightPlan>();
        OperationsBBDD myOperations = new OperationsBBDD();

        // InitializeComponent()
        public FlightData()
        {
            InitializeComponent();
        }

        // Métodos
        public void TomaDatos(List<FlightPlan> lista, List<FlightPlan> listaFull)
        // Receives the necessary data (in this case, a List of FlightPlans)
        {
            this.lista = lista;
            this.listaFull = listaFull;
        }

        private void button1_Click(object sender, EventArgs e)
        // Button that closes the Form
        {
            this.myOperations.Close();
            Close();
        }

        private void FlightData_Load(object sender, EventArgs e)
        // Shows the data of every FlightPlan in the list
        {
            this.myOperations.Iniciar();

            flightDataGrid.RowHeadersVisible = false;
            flightDataGrid.ColumnHeadersVisible = false;

            flightDataGrid.RowCount = lista.Count + 1;
            flightDataGrid.ColumnCount = 11;

            // Row[0] bold
            flightDataGrid.Rows[0].DefaultCellStyle.Font = new Font("Tahoma", 11, FontStyle.Bold);

            // Headers
            flightDataGrid.Rows[0].Cells[0].Value = "ID";
            flightDataGrid.Rows[0].Cells[1].Value = "COMPANY";
            flightDataGrid.Rows[0].Cells[2].Value = "IX";
            flightDataGrid.Rows[0].Cells[3].Value = "IY";
            flightDataGrid.Rows[0].Cells[4].Value = "CX";
            flightDataGrid.Rows[0].Cells[5].Value = "CY";
            flightDataGrid.Rows[0].Cells[6].Value = "FX";
            flightDataGrid.Rows[0].Cells[7].Value = "FY";
            flightDataGrid.Rows[0].Cells[8].Value = "VEL";
            flightDataGrid.Rows[0].Cells[9].Value = "TEL";
            flightDataGrid.Rows[0].Cells[10].Value = "EMAIL";

            // loop
            for (int i = 0; i<lista.Count; i++)
            {
                flightDataGrid.Rows[i + 1].Cells[0].Value = lista[i].DameId();
                flightDataGrid.Rows[i + 1].Cells[1].Value = lista[i].DameCompany();
                flightDataGrid.Rows[i + 1].Cells[2].Value = Convert.ToInt32(lista[i].DameInitialPosition().GetX());
                flightDataGrid.Rows[i + 1].Cells[3].Value = Convert.ToInt32(lista[i].DameInitialPosition().GetY());
                flightDataGrid.Rows[i + 1].Cells[4].Value = Convert.ToInt32(lista[i].DameCurrentPosition().GetX());
                flightDataGrid.Rows[i + 1].Cells[5].Value = Convert.ToInt32(lista[i].DameCurrentPosition().GetY());
                flightDataGrid.Rows[i + 1].Cells[6].Value = Convert.ToInt32(lista[i].DameFinalPosition().GetX());
                flightDataGrid.Rows[i + 1].Cells[7].Value = Convert.ToInt32(lista[i].DameFinalPosition().GetY());
                flightDataGrid.Rows[i + 1].Cells[8].Value = Convert.ToInt32(lista[i].DameVelocidad());
                flightDataGrid.Rows[i + 1].Cells[9].Value = Convert.ToInt32(this.myOperations.ObtainTelephoneWithCompNameInt_COMPANY(lista[i].DameCompany()));
                flightDataGrid.Rows[i + 1].Cells[10].Value = this.myOperations.ObtainEmailWithCompNameDT_COMPANY(lista[i].DameCompany());
            }

            // Clears the selection
            flightDataGrid.ClearSelection();

            // The user can't edit the tables
            flightDataGrid.ReadOnly = true;
        }

        private void flightDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        // Event that opens the DistanceClick Form in order to show the distance between the specific clicked aircraft and all the others
        {
            if(flightDataGrid.Rows.Count >= 2)
            {
                if(this.listaFull.Count > 1)
                {
                    if(flightDataGrid.Rows.Count > 2)
                    {
                        int num = e.RowIndex;

                        if (num == 0)
                        {
                            MessageBox.Show("This is not a Flight Plan");
                        }
                        else
                        {
                            DistanceClick distForm = new DistanceClick();
                            distForm.TomaDatos(this.lista, num);
                            distForm.ShowDialog();
                        }
                    }
                    else
                    {
                        int num = e.RowIndex;

                        if (num == 0)
                        {
                            MessageBox.Show("This is not a Flight Plan");
                        }
                        else
                        {
                            DistanceClick distForm = new DistanceClick();
                            distForm.TomaDatos2(this.listaFull, this.lista);
                            distForm.ShowDialog();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("There is only one Flight Plan in the List.\nThat means that there are no distances to calculate between aircrafts.");
                }
            }            
        }
    }
}
