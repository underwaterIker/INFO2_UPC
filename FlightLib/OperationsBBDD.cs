using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SQLite;

namespace FlightLib
{
    public class OperationsBBDD
    {
        // Atributos
        SQLiteConnection dbConnection;

        // Constructores
        public OperationsBBDD()
        {

        }

        // Métodos
        public void Iniciar()
        // Opens the Database
        {
            string dataSource = "Data source = practica.db";
            dbConnection = new SQLiteConnection(dataSource);
            dbConnection.Open();
        }

        public void Close()
        // Closes the connection
        {
            dbConnection.Close();
        }        

        public void InsertUser(string un, string pw, string email)
        // Inserts a user into the table 'users' of our DataBase
        {
            string sql = "INSERT INTO users (username, password, email) VALUES ('"+un+"', '"+pw+"', '"+email+"')";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }

        public DataTable ObtainUserWithUsernameAndPasswordDT_USER(string username, string password)
        // Returns the Username of a specific User, the row of the user we want to obtain its username is given as a parameter
        {
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM users WHERE username = '" + username + "' AND password = '" + password + "'";
            SQLiteDataAdapter adp = new SQLiteDataAdapter(sql, dbConnection);
            adp.Fill(dt);
            return dt;
        }

        public DataTable ObtainUserWithUsernameDT_USER(string name)
        // Returns the Username of a specific User, the row of the user we want to obtain its username is given as a parameter
        {
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM users WHERE username = '" + name + "'";
            SQLiteDataAdapter adp = new SQLiteDataAdapter(sql, dbConnection);
            adp.Fill(dt);
            return dt;
        }

        public string ObtainUsernameWithEmailString_USER(string email)
        // Returns the Username of a specific User, the email of the user is given as a parameter
        {
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM users WHERE email = '" + email + "'";
            SQLiteDataAdapter adp = new SQLiteDataAdapter(sql, dbConnection);
            adp.Fill(dt);
            string username = Convert.ToString(dt.Rows[0]["username"]);
            return username;
        }

        public string ObtainPasswordWithUsernameString_USER(string username)
        // Returns the Password of a specific User, the username of the user is given as a parameter
        {
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM users WHERE username = '" + username + "'";
            SQLiteDataAdapter adp = new SQLiteDataAdapter(sql, dbConnection);
            adp.Fill(dt);
            string password = Convert.ToString(dt.Rows[0]["password"]);
            return password;
        }

        public void UpdatePassword(string username, string newPassword)
        // Updates the password of a user
        {
            string sql = "UPDATE users SET password = '"+newPassword+"' WHERE username = '"+username+"'";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }

        public string ObtainEmailWithUsernameString_USER(string username)
        // Returns the Email of a specific User, the username is given as a parameter
        {
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM users WHERE username = '" + username + "'";
            SQLiteDataAdapter adp = new SQLiteDataAdapter(sql, dbConnection);
            adp.Fill(dt);
            string email = Convert.ToString(dt.Rows[0]["email"]);
            return email;
        }

        public int ObtainTelephoneWithCompNameInt_COMPANY(string compName)
        // Returns the Telephone of a specific Company, the name of the company is given as a parameter
        {
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM flightCompanies WHERE name = '" + compName + "'";
            SQLiteDataAdapter adp = new SQLiteDataAdapter(sql, dbConnection);
            adp.Fill(dt);
            int tel = Convert.ToInt32(dt.Rows[0]["telephone"]);
            return tel;
        }

        public string ObtainEmailWithCompNameDT_COMPANY(string compName)
        // Returns the Email of a specific Company, the name of the company is given as a parameter
        {
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM flightCompanies WHERE name = '" + compName + "'";
            SQLiteDataAdapter adp = new SQLiteDataAdapter(sql, dbConnection);
            adp.Fill(dt);
            string email = Convert.ToString(dt.Rows[0]["email"]);
            return email;
        }

        public DataTable ObtainUsersDT_USER()
        // Returns the DataTable 'users' from the DataBase
        {
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM users";
            SQLiteDataAdapter adp = new SQLiteDataAdapter(sql, dbConnection);
            adp.Fill(dt);
            return dt;
        }

        public DataTable ObtainFlightCompaniesDT_COMPANY()
        // Returns the DataTable 'flightCompanies' from the DataBase
        {
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM flightCompanies";
            SQLiteDataAdapter adp = new SQLiteDataAdapter(sql, dbConnection);
            adp.Fill(dt);
            return dt;
        }

        public void InsertCompany(string name, int tel, string email)
        // Inserts a company into the table 'flightCompanies' of our DataBase
        {
            string sql = "INSERT INTO flightCompanies (name, telephone, email) VALUES ('" + name + "', " + tel + ", '" + email + "')";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }

        public void DeleteCompany(string name)
        // Deletes a company from the table 'flightCompanies' of our DataBase
        {
            string sql = "DELETE FROM flightCompanies WHERE name='"+name+"'";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }
    }
}
