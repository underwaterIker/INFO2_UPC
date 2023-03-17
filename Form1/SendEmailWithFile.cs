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
    public partial class SendEmailWithFile : Form
    {
        // Atributos
        User userClass;

        Email emailClass = new Email();

        string fileLocation;

        //InicializeComponent()
        public SendEmailWithFile()
        {
            InitializeComponent();
        }

        // Métodos
        public void TomaDatos(User user, string fileLoc)
        // Gets the location of the file in a string
        {
            this.userClass = user;
            this.fileLocation = fileLoc;
        }

        private void yesBtn_Click(object sender, EventArgs e)
        // Sends an email to the user with the file
        {
            string email = this.userClass.GetEmail();
            string fileLoc = this.fileLocation;

            int j = emailClass.SendEmailWithAttachment(email, fileLoc);

            if(j == 1)
            {
                MessageBox.Show("The File has been sent you to your email!");
                this.Close();
            }
            if(j == 0)
            {
                MessageBox.Show("Error when sending email.");
                this.Close();
            }
            if(j == -1)
            {
                MessageBox.Show("This user does not exist.\nTry again!");
            }
        }

        private void noBtn_Click(object sender, EventArgs e)
        // Closes the Form without sending the email with the file
        {
            this.Close();
        }
    }
}
