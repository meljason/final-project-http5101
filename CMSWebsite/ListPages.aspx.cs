using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace CMSWebsite
{
    public partial class ListPages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pages_result.InnerHtml = "";

            string searchkey = "";

            if (Page.IsPostBack)
            {          
                searchkey = page_search.Text;
            }

            string query = "select * from PAGES";

            if (searchkey != "")
            {
                query += " where pagetitle like '%" + searchkey + "%' ";
                query += " or pagebody like '%" + searchkey + "%' ";
                query += " or pageimage like '%" + searchkey + "%' ";
                query += " or dateupload like '%" + searchkey + "%' ";
            }
            sql_debugger.InnerHtml = query;

            var db = new PagesDB();
            List<Dictionary<String, String>> rs = db.List_Query(query);
            foreach(Dictionary<String,String> row in rs)
            {
                pages_result.InnerHtml += "<tr>";

                string pageid = row["pageid"];
                pages_result.InnerHtml += "<th scope=\"row\"><a href=\"ShowPage.aspx?pageid=" + pageid + "\">" + pageid + "</a></th>";

                string pagetitle = row["pagetitle"];
                pages_result.InnerHtml += "<td>" + pagetitle + "</td>";

                string pagebody = row["pagebody"];
                pages_result.InnerHtml += "<td>" + pagebody + "</td>";

                string pageimage = row["pageimage"];
                pages_result.InnerHtml += "<td>" + pageimage + "</td>";

                string dateupload = row["dateupload"];
                pages_result.InnerHtml += "<td>" + dateupload + "</td>";

                pages_result.InnerHtml += "</tr>";
            }
        }
    }
}