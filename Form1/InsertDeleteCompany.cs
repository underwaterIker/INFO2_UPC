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
    public partial class InsertDeleteCompany : Form
    {
        // Atributos
        OperationsBBDD myOperations = new OperationsBBDD();

        // InitializeComponent()
        public InsertDeleteCompany()
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

        private void InsertDeleteCompany_Load(object sender, EventArgs e)
        // Opens the Database
        {
            myOperations.Iniciar();
        }

        private void insertBtn_Click(object sender, EventArgs e)
        // Inserts the company in the DataBase
        {
            try
            {
                string name = nameInsertBox.Text;
                int tel = Convert.ToInt32(telBox.Text);
                string email = emailBox.Text;

                myOperations.InsertCompany(name, tel, email);

                nameInsertBox.Clear();
                telBox.Clear();
                emailBox.Clear();

                MessageBox.Show("Company has been INSERTED successfully!");
            }
            catch
            {
                nameInsertBox.Clear();
                telBox.Clear();
                emailBox.Clear();

                MessageBox.Show("Error. Company could NOT be inserted!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        // Deletes the company from the DataBase
        {
            string name = nameDeleteBox.Text;

            bool exists = false;
            for(int i = 0; i < myOperations.ObtainFlightCompaniesDT_COMPANY().Rows.Count; i++)
            {
                if(Convert.ToString(myOperations.ObtainFlightCompaniesDT_COMPANY().Rows[i]["name"]) == name)
                {
                    exists = true;
                }
            }

            if(exists is true)
            {
                myOperations.DeleteCompany(name);

                nameDeleteBox.Clear();

                MessageBox.Show("Company has been DELETED successfully!");
            }
            else
            {
                MessageBox.Show("Error. This company could NOT be deleted because it's not in our Database!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
