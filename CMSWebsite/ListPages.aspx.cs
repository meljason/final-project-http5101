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

                //pages_result.InnerHtml += "<td><i class=\"fas fa-trash-alt\"></i>";
               


                pages_result.InnerHtml += "<td><a href=\"DeletePage.aspx?pageid=" + pageid + "\"><i class=\"fas fa-trash-alt\" style=\"color:black\"></i></a></td>";


                //Attempts in adding the delete buttons:::

                //pages_result.InnerHtml += "<td><button runat=\"server\" OnClientClick=\"if(!confirm('Are you sure you want to delete this?')) return false;\" OnClick=\"Delete_Page\"><i class=\"fas fa-trash-alt\"></i>";

                //pages_result.InnerHtml += "<asp:LinkButton runat=\"server\" OnClientClick=\"if (!confirm(\'Are you sure you want to delete this?\')) return false; \" Text=\" < i class=\'fas fa-trash-alt\'></i>\" OnClick=\"Delete_Page\" />";

                //pages_result.InnerHtml += "<asp:Button OnClientClick=\"if (!confirm('Are you sure you want to delete this?')) return false; \" OnClick=\"Delete_Page\" CssClass=\"btn btn-dark\" Text=\"Delete\" runat=\"server\" />";
                pages_result.InnerHtml += "</tr>";
            }
        }

        protected void Delete_Page(object sender, EventArgs e)
        {
            bool valid = true;
            string pageid = Request.QueryString["pageid"];
            if (String.IsNullOrEmpty(pageid)) valid = false;

            PagesDB db = new PagesDB();

            //deleting the page from the system
            if (valid)
            {
                db.DeletePage(Int32.Parse(pageid));
                Response.Redirect("ListPages.aspx");
            }
        }
    }
}