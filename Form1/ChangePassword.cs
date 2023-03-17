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
    public partial class ChangePassword : Form
    {
        // Atributos
        OperationsBBDD myOperations = new OperationsBBDD();

        // InitializeComponent();
        public ChangePassword()
        {
            InitializeComponent();
        }

        // Métodos
        private void button1_Click(object sender, EventArgs e)
        // Changes the password of the user
        {
            string username = usernameBox.Text;
            string oldPassword = oldPasswordBox.Text;
            string newPassword = newPasswordBox.Text;

            DataTable consulta = myOperations.ObtainUserWithUsernameDT_USER(username);
            if(consulta.Rows.Count == 0)
            {
                MessageBox.Show("This user does not exist!\nTry again.");
                usernameBox.Clear();
                oldPasswordBox.Clear();
                newPasswordBox.Clear();
            }
            else
            {
                if (myOperations.ObtainPasswordWithUsernameString_USER(username) == oldPassword)
                {
                    if (oldPassword == newPassword)
                    {
                        MessageBox.Show("You have input the same password as the old one!\nNo changes have been applied.");
                    }
                    else
                    {
                        int numUppers = 0;
                        int numDigits = 0;
                        foreach (char c in newPassword)
                        {
                            if (char.IsUpper(c))
                            {
                                numUppers++;
                            }
                            if (char.IsDigit(c))
                            {
                                numDigits++;
                            }
                        }

                        if (newPassword.Length >= 8 && numUppers >= 1 && numDigits >= 1)
                        {
                            myOperations.UpdatePassword(username, newPassword);
                            MessageBox.Show("Password has been changed succesfully!");

                            myOperations.Close();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Password must contain a minimum of 8 letters, 1 upper letter and 1 number.");
                            newPasswordBox.Clear();
                        }
                    }   
                }
                else
                {
                    MessageBox.Show("The input 'old password' is not correct!\nTry again.");
                    oldPasswordBox.Clear();
                    newPasswordBox.Clear();
                }
            }
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        // Iniciates the DataBase
        {
            myOperations.Iniciar();

            oldPasswordBox.PasswordChar = Convert.ToChar("●");
            newPasswordBox.PasswordChar = Convert.ToChar("●");
        }

        private void closeBtn_Click(object sender, EventArgs e)
        // Closes the Form
        {
            myOperations.Close();
            this.Close();
        }
    }
}
