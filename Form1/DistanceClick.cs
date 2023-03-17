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
    public partial class DistanceClick : Form
    {
        // Atributos
        List<FlightPlan> listaFull = new List<FlightPlan>();
        List<FlightPlan> lista = new List<FlightPlan>();
        int num;

        // InitializeComponent()
        public DistanceClick()
        {
            InitializeComponent();
        }

        // Métodos
        public void TomaDatos(List<FlightPlan> lista, int numero)
        // Receives the necessary data
        {
            this.listaFull = lista;
            this.lista = lista;
            this.num = numero;
        }

        public void TomaDatos2(List<FlightPlan> listaFull, List<FlightPlan> lista)
        // Receives the necessary data
        {
            this.listaFull = listaFull;
            this.lista = lista;

            for(int i = 0; i < this.listaFull.Count; i++)
            {
                if(this.listaFull[i].DameId() == this.lista[0].DameId())
                {
                    this.num = i+1;
                }
            }
        }

        private void DistanceClick_Load(object sender, EventArgs e)
        // Shows the distance between one specific aircraft and all the other aircrafts in the FlightPlanList
        {
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dataGridView1.RowCount = this.listaFull.Count - 1;
            dataGridView1.ColumnCount = 2;

            int j = 0;
            for(int i = 0; i < this.listaFull.Count; i++)
            {
                if (i != this.num-1)
                {
                    dataGridView1.Rows[j].Cells[0].Value = "Distance between " + listaFull[this.num-1].DameId() + " & " + this.listaFull[i].DameId();
                    dataGridView1.Rows[j].Cells[1].Value = listaFull[this.num-1].Distance(listaFull[i]);
                }
                else
                {
                    j = j-1;
                }
                j++;
            }

            // Clears the selection
            dataGridView1.ClearSelection();

            // The user can't edit the tables
            dataGridView1.ReadOnly = true;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        // Button that closes the Form
        {
            Close();
        }
    }
}
