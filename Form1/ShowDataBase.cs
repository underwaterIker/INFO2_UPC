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
    public partial class ShowDataBase : Form
    {
        // Atributos
        OperationsBBDD myOperations = new OperationsBBDD();

        DataTable usersDataTable;
        DataTable flightCompaniesDataTable;

        // InitializeComponent()
        public ShowDataBase()
        {
            InitializeComponent();
        }

        // Métodos
        private void closeBtn_Click(object sender, EventArgs e)
        // Closes the Form
        {
            myOperations.Close();
            this.Close();
        }

        private void ShowDataBase_Load(object sender, EventArgs e)
        // Shows all the information in the data base in two different DataGridViews
        {
            myOperations.Iniciar();
            this.usersDataTable = myOperations.ObtainUsersDT_USER();
            this.flightCompaniesDataTable = myOperations.ObtainFlightCompaniesDT_COMPANY();

            // Set the DataGriedViews
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dataGridView1.DataSource = this.usersDataTable;
            dataGridView2.DataSource = this.flightCompaniesDataTable;

            // Column headers bold
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 11, FontStyle.Bold);
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 11, FontStyle.Bold);

            // Clears the selection
            dataGridView1.ClearSelection();
            dataGridView2.ClearSelection();

            // The user can't edit the tables
            dataGridView1.ReadOnly = true;
            dataGridView2.ReadOnly = true;
        }

        private void insertDeleteBtn_Click(object sender, EventArgs e)
        // Opens the InsertDeleteCompanyForm, so that the user can insert or delete a company
        {
            InsertDeleteCompany insertDeleteForm = new InsertDeleteCompany();
            insertDeleteForm.ShowDialog();

            ShowDataBase_Load(sender, e);
        }
    }
}
