using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form1
{
    public partial class RandomPassword : Form
    {
        // Atributos
        string password;

        // InitializeComponent()
        public RandomPassword()
        {
            InitializeComponent();
        }

        // Métodos
        public string GetRecommendedPassword()
        {
            return this.password;
        }

        private void RandomPassword_Load(object sender, EventArgs e)
        {
            Random random = new Random();

            char[] lettersUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            char[] lettersMinus = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            int randomNumber4Digits = random.Next(1000, 9999);

            string word = "";

            for (int i = 0; i < 4; i++)
            {
                int letter_num = random.Next(0, lettersUpper.Length - 1);

                if (i == 0)
                {
                    word += lettersUpper[letter_num];
                }
                else
                {
                    word += lettersMinus[letter_num];
                }

            }
            word += randomNumber4Digits;

            randomPasswordLbl.Text = word;
        }

        private void thisOneBtn_Click(object sender, EventArgs e)
        {
            this.password = randomPasswordLbl.Text;
            MessageBox.Show("This password will be copied to the 'Password TextBox'!");
            this.Close();
        }

        private void anotherOneBtn_Click(object sender, EventArgs e)
        {
            RandomPassword_Load(sender, e);
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
