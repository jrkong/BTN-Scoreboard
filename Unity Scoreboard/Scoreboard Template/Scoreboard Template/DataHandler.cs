using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows;
using System.IO;

using MySql.Data.MySqlClient; //Jay's database is actually MySql, be sure to get this package

namespace Scoreboard_Template
{
    class DataHandler
    {
        //SqlConnection conn;
        //SqlCommand cmd;
        MySqlConnection conn;
        MySqlCommand cmd;
        string query;

        public DataHandler()
        {
            conn = null;
            cmd = null;
            query = "";
        }

        public bool verifyDatabase()
        {
            bool exists = false;
            int databaseId = 0;
            query = "SELECT testId FROM TestTable"; //change this later
            //conn = new SqlConnection("server=(local);Trusted_Connection=yes");  //Local db
            MySqlConnectionStringBuilder connectionString = new MySqlConnectionStringBuilder
            {
                { "Host", "99.227.52.70" },
                { "Port", "3306" },
                { "Database", "InjectionDataBase" },
                { "UserId", "Pat" },
                { "Password", "GG" }
            };

            conn = new MySqlConnection(connectionString.ConnectionString);            
            try
            {
                using (conn)
                {
                    using (cmd = new MySqlCommand(query, conn))
                    {
                        conn.Open();
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            int.TryParse(result.ToString(), out databaseId);
                        }
                        conn.Close();
                        exists = (databaseId > 0);
                    }
                }
            }
            catch (Exception ex)
            {
                exists = false;
                MessageBox.Show(ex.ToString());
            }
            return exists;
        }

        public void initializeDatabase()
        {
            query = "CREATE DATABASE nightmares";
            conn = new MySqlConnection("server=(local);Trusted_Connection=yes");
            cmd = new MySqlCommand(query, conn);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();                
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            query = File.ReadAllText(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\create_tables.sql")));
            conn = new MySqlConnection("server=(local);Trusted_Connection=yes;Initial Catalog=nightmares");
            cmd = new MySqlCommand(query, conn);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public bool authenticate(String user, String pwd)
        {
            bool auth = true;
            //perform authentication
            return auth;
        }

        public DataSet getScores()
        {
            DataSet ds = new DataSet();
            conn = new MySqlConnection("server=(local);Trusted_Connection=yes;Initial Catalog=nightmares");
            query =
                "SELECT TOP 40 l.score, u.username, l.sDate FROM dbo.leaderboard l " +
                "INNER JOIN dbo.users u ON l.userId = u.id " +
                "ORDER BY l.score DESC";
            MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
            try
            {
                conn.Open();
                da.Fill(ds, "Scores");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return ds;
        }
    }
}
