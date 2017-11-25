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
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlConnectionStringBuilder connectionString;
        string query;

        public DataHandler()
        {
            conn = null;
            cmd = null;
            query = "";
            connectionString = new MySqlConnectionStringBuilder
            {
                { "Host", "99.227.52.70" },
                //{ "Host", "localhost" },
                { "Port", "3306" },
                { "Database", "InjectionDataBase" },
                { "UserId", "Pat" },
                { "Password", "GG" }
            };
        }

        public bool verifyDatabase()
        {
            bool exists = false;
            int databaseId = 0;
            query = "SELECT testId FROM TestTable"; //change this later
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
            query = File.ReadAllText(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\create_tables.sql")));
            conn = new MySqlConnection(connectionString.ConnectionString);
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

        public void createUser(string usr, string pwd, string email)
        {
            conn = new MySqlConnection(connectionString.ConnectionString);
            query =
                "INSERT INTO users (username, password) " +
                "VALUES('" + usr + "', '" + pwd + "')";
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

        public void submitScore(int score)
        {


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
            conn = new MySqlConnection(connectionString.ConnectionString);
            query =
                "SELECT l.score, u.username, l.sDate " +
                "FROM leaderboard l INNER JOIN users u ON l.userId = u.id " +
                "ORDER BY l.score DESC ";
                //"LIMIT 50";
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

        public DataSet getMyScores(string tb_username)
        {
            DataSet ds = new DataSet();
            conn = new MySqlConnection(connectionString.ConnectionString);
            query =
                "SELECT l.score, u.username, l.sDate " +
                "FROM leaderboard l INNER JOIN users u ON l.userId = u.id " +
                "WHERE username = '" + tb_username + "'";
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
