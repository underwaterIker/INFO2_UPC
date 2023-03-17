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
    public partial class LogIn : Form
    {
        // Atributos
        OperationsBBDD myOperations = new OperationsBBDD();
        Main main = new Main();
        User userClass = new User();
        Email emailClass = new Email();

        Queue<string> usernameError = new Queue<string>();
        int numErrors = 0;

        // InitializeComponent()
        public LogIn()
        {
            InitializeComponent();
        }

        // Métodos
        public User GetUserClass()
        // Returns the class User with all the data of the user that has logged in
        {
            return this.userClass;
        }

        private void signUpBtn_Click(object sender, EventArgs e)
        // Adds the new user to our Database
        {
            DataTable consulta = myOperations.ObtainUserWithUsernameDT_USER(userSU.Text);
            if(consulta.Rows.Count == 0)
            {
                string user = userSU.Text;
                string password = passwordSU.Text;
                string email = emailSU.Text;

                int numUppers = 0;
                int numDigits = 0;
                foreach (char c in password)
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

                if(password.Length >= 8 && numUppers >= 1 && numDigits >= 1)
                {
                    myOperations.InsertUser(user, password, email);
                    MessageBox.Show("Congrats, you have been registered!");

                    userSU.Clear();
                    passwordSU.Clear();
                    emailSU.Clear();
                }
                else
                {
                    MessageBox.Show("Password must contain a minimum of 8 letters, 1 upper letter and 1 number.");
                    passwordSU.Clear();
                }
            }
            else
            {
                MessageBox.Show("This user is already registered!\nTry with another username.");
                userSU.Clear();
            }
        }

        private void LogIn_Load(object sender, EventArgs e)
        // Connects to our Database
        {
            myOperations.Iniciar();
            passwordLI.PasswordChar = Convert.ToChar("●");
            passwordSU.PasswordChar = Convert.ToChar("●");
        }

        private void logInBtn_Click(object sender, EventArgs e)
        // Logs in if the username is in our Database and the password is correct
        {
            DataTable consulta = myOperations.ObtainUserWithUsernameAndPasswordDT_USER(userLI.Text, passwordLI.Text);
            DataTable consulta2 = myOperations.ObtainUserWithUsernameDT_USER(userLI.Text);
            if(consulta.Rows.Count == 0 && consulta2.Rows.Count == 0)
            {
                MessageBox.Show("Username or Password are incorrect.\nTry again!");
                userLI.Clear();
                passwordLI.Clear();
            }
            else
            {
                if (consulta.Rows.Count == 0 && consulta2.Rows.Count == 1)
                {
                    string username = Convert.ToString(consulta2.Rows[0]["username"]);
                    usernameError.Enqueue(username);
                    int j = 0;
                    foreach (string un in usernameError)
                    {
                        if (un == username)
                        {
                            j++;
                        }
                    }
                    this.numErrors = j;

                    if (this.numErrors < 3)
                    {
                        passwordLI.Clear();
                        if (this.numErrors == 1)
                        {
                            MessageBox.Show("Incorrect password!\nYou have two opportunities left.");
                        }
                        if (this.numErrors == 2)
                        {
                            MessageBox.Show("Incorrect password!\nYou have one opportunity left.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("You have failed 3 times!\nSending an email to the user warning him.");

                        string email = myOperations.ObtainEmailWithUsernameString_USER(username);
                        string subject = "Warning!";
                        string body = "Someone is trying to enter into your account!\nIf it wasn't you, change your password as soon as possible.";
                        
                        int q = emailClass.SendEmailWithoutAttachment(email, subject, body);

                        if(q == 1)
                        {
                            MessageBox.Show("An email has been sent to the user warning him.");

                            myOperations.Close();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Error when sending email.");

                            myOperations.Close();
                            this.Close();
                        }
                    }
                }
                else
                {
                    this.userClass.SetUsername(userLI.Text);
                    this.userClass.SetPassword(passwordLI.Text);
                    this.userClass.SetEmail(myOperations.ObtainEmailWithUsernameString_USER(userLI.Text));

                    myOperations.Close();

                    this.Hide();
                    this.main.TomaDatos(userClass);
                    this.main.ShowDialog();

                    this.Close();
                }
            }
            
        }

        private void recoverBtn_Click(object sender, EventArgs e)
        // Sends an email to the user with their password
        {
            RecoverPassword recoverForm = new RecoverPassword();
            recoverForm.ShowDialog();
        }

        private void changePasswordBtn_Click(object sender, EventArgs e)
        // Opens the Form 'ChangePassword' so that the user can change their password
        {
            ChangePassword changePassword = new ChangePassword();
            changePassword.ShowDialog();
        }

        private void randomPasswordBtn_Click(object sender, EventArgs e)
        {
            RandomPassword randomPasswordForm = new RandomPassword();
            randomPasswordForm.ShowDialog();
            string recommndedPassword = randomPasswordForm.GetRecommendedPassword();

            if(recommndedPassword != null)
            {
                passwordSU.Text = recommndedPassword;
            }
        }
    }
}
