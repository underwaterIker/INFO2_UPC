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
using System.Net.Mail;

namespace Form1
{
    public partial class RecoverPassword : Form
    {
        // Atributos
        OperationsBBDD myOperations = new OperationsBBDD();
        Email emailClass = new Email();

        // InitializeComponent()
        public RecoverPassword()
        {
            InitializeComponent();
        }

        // Métodos
        private void sendBtn_Click(object sender, EventArgs e)
        // Sends an email to the user with their username and password
        {
            try
            {
                string email = myOperations.ObtainEmailWithUsernameString_USER(usernameBox.Text);
                string subject = "Recover password";
                string password = myOperations.ObtainPasswordWithUsernameString_USER(usernameBox.Text);
                string body = "Your password is: " + password;

                int j = this.emailClass.SendEmailWithoutAttachment(email, subject, body);

                if (j == 1)
                {
                    MessageBox.Show("An email with the password has been sent to your mail account.");

                    myOperations.Close();
                    this.Close();
                }
                if (j == 0)
                {
                    MessageBox.Show("Error when sending email.");

                    myOperations.Close();
                    this.Close();
                }
                if (j == -1)
                {
                    MessageBox.Show("This user does not exist.\nTry again!");
                    usernameBox.Clear();
                }
            }
            catch
            {
                MessageBox.Show("This user does not exist.`\nTry again!");
                usernameBox.Clear();
            }
        }

        private void RecoverPassword_Load(object sender, EventArgs e)
        // Opens the Database
        {
            myOperations.Iniciar();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        // Closes the Form
        {
            myOperations.Close();
            this.Close();
        }
    }
}
