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
        private static string Port { get { return "3306"; } }

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

        public Page FindPage(int id)
        {
            MySqlConnection Connect = new MySqlConnection(ConnectionString);

            Page result_page = new Page();

            try
            {
                string query = "select * from pages where pageid = " + id;
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
                            case "pagetitle":
                                Debug.WriteLine("we are trying to set the page title to " + value);
                                currentpage.SetPageTitle(value);
                                break;
                            case "pagebody":
                                currentpage.SetPageBody(value);
                                break;

                            //I wanted to set the image of the page, but I cant seem to find out how to convert string to a type HttpPostedFileBase, Sorry!
                            //case "PAGEIMAGE":
                                //currentpage.SetPageImage();
                                //break;

                            case "dateupload":
                                Debug.WriteLine("we are trying to set the page date to " + value);
                                currentpage.SetUploadDate(DateTime.ParseExact(value, "dd/MM/yyyy hh:mm:ss", new CultureInfo("en-US")));
                                break;

                        }

                    }

                    //adding the page to the list of pages
                    pages.Add(currentpage);
                }

                result_page = pages[0]; //getting the first page
           
            }
            catch(Exception ex)
            {
                Debug.WriteLine("Something went wrong in the find Page method!");
                Debug.WriteLine(ex.ToString());

            }

            Connect.Close();
            Debug.WriteLine("Database Connection Terminated.");

            return result_page;
        }

        public void AddPage(Page new_page)
        {
            string query = "insert into pages (PAGETITLE, PAGEBODY, PAGEIMAGE, DATEUPLOAD) values ('{0}','{1}','{2}','{3}')";
            query = String.Format(query, new_page.GetPageTitle(), new_page.GetPageBody(), new_page.GetPageImage(), new_page.GetUploadDate().ToString("yyyy-MM-dd"));


            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, Connect);
            try
            {
                Connect.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Something went wrong in the NewPage Method!");
                Debug.WriteLine(ex.ToString());
            }

            Connect.Close();
        }

        public void UpdatePage(int pageid, Page new_page)
        {
            string query = "update PAGES set PAGETITLE='{0}', PAGEBODY='{1}', PAGEIMAGE='{2}' where PAGEID={3}";
            query = String.Format(query, new_page.GetPageTitle(), new_page.GetPageBody(), new_page.GetPageImage(), pageid);

  
            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, Connect);
            try
            {
                Connect.Open();
                cmd.ExecuteNonQuery();
                Debug.WriteLine("Executed query " + query);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Something went wrong in the UpdatePage Method!");
                Debug.WriteLine(ex.ToString());
            }

            Connect.Close();
        }
        public void DeletePage(int pageid)
        {

            string removespage = "delete from PAGES where PAGEID = {0}";
            removespage = String.Format(removespage, pageid);

            MySqlConnection Connect = new MySqlConnection(ConnectionString);
           
            MySqlCommand cmd_removepage = new MySqlCommand(removespage, Connect);
            try
            {
                //try to execute both commands!
                Connect.Open();
                cmd_removepage.ExecuteNonQuery();
                Debug.WriteLine("Executed query " + cmd_removepage);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Something went wrong in the delete Page Method!");
                Debug.WriteLine(ex.ToString());
            }

            Connect.Close();
        }



    }
}