using System;
using System.Collections.Generic;
using System.Text;

namespace FlightLib
{
    public class User
    {
        // Atributos
        string username;
        string password;
        string email;

        // Constructores
        public User()
        {

        }

        // Métodos
        public void SetUsername(string username)
        // Sets the username
        {
            this.username = username;
        }

        public void SetPassword(string password)
        // Sets the password
        {
            this.password = password;
        }

        public void SetEmail(string email)
        // Sets the email
        {
            this.email = email;
        }

        public string GetUsername()
        // Returns the username
        {
            return this.username;
        }

        public string GetPassword()
        // Returns the password
        {
            return this.password;
        }

        public string GetEmail()
        // Returns the email
        {
            return this.email;
        }
    }
}
