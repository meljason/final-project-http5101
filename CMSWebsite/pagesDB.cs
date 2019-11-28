using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace CMSWebsite
{
    public class PagesDB
    {
        //This code in this class is referred to the database connection of Christine Bittles
        private static string User { get { return "root"; } }
        private static string Password { get { return ""; } }
        private static string Database { get { return "cms"; } }
        private static string Server { get { return "localhost"; } }
        private static string Port { get { return "8889"; } }

        private static string ConnectionString
        {
            get
            {
                return "server = " + Server
                    + "; user = " + User
                    + "; database = " + Database
                    + "; port = " + Port
                    + "; password = " + Password;
            }
        }

        public List<Dictionary<String, String>> List_Query(string query)
        {
            MySqlConnection Connect = new MySqlConnection(ConnectionString);

            List<Dictionary<String, String>> ResultSet = new List<Dictionary<String, String>>();

            try
            {
                Debug.WriteLine("Connection Initialized...");
                Debug.WriteLine("Attempting to execute query " + query);
                //open the db connection
                Connect.Open();
                //give the connection a query
                MySqlCommand cmd = new MySqlCommand(query, Connect);
                //grab the result set
                MySqlDataReader resultset = cmd.ExecuteReader();


                //for every row in the result set
                while (resultset.Read())
                {
                    Dictionary<String, String> Row = new Dictionary<String, String>();
                    //for every column in the row
                    for (int i = 0; i < resultset.FieldCount; i++)
                    {
                        Row.Add(resultset.GetName(i), resultset.GetString(i));

                    }

                    ResultSet.Add(Row);
                }//end row
                resultset.Close();


            }
            catch (Exception ex)
            {
                Debug.WriteLine("Something went wrong in the List_Query method!");
                Debug.WriteLine(ex.ToString());

            }

            Connect.Close();
            Debug.WriteLine("Database Connection Terminated.");

            return ResultSet;
        }

        public Page findPage(int id)
        {
            MySqlConnection Connect = new MySqlConnection(ConnectionString);

            Page result_page = new Page();

            try
            {
                string query = "select * from page where pageid = " + id;
                Debug.WriteLine("Connection Initialized...");

                Connect.Open();

                MySqlCommand cmd = new MySqlCommand(query, Connect);

                MySqlDataReader resultset = cmd.ExecuteReader();

                List<Page> pages = new List<Page>();

                while (resultset.Read())
                {
                    Page currentpage = new Page();

                    for(int i = 0; i < resultset.FieldCount; i++)
                    {
                        string key = resultset.GetName(i);
                        string value = resultset.GetString(i);
                        Debug.WriteLine("Attempting to transfer " + key + " data of " + value);

                        switch (key)
                        {
                            case "PAGETITLE":
                                currentpage.SetPageTitle(value);
                                break;
                            case "PAGEBODY":
                                currentpage.SetPageBody(value);
                                break;
                            case "PAGEIMAGE":
                                currentpage.SetPageImage();
                                break;
                            case "UPLOADDATE":
                                currentpage.SetUploadDate(DateTime.ParseExact(value, "M/d/yyyy hh:mm:ss tt", new CultureInfo("en-US")));
                                break;

                        }

                    }
                }
           
            }
            catch
            {

            }
        }
    }
}