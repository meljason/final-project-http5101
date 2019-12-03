using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMSWebsite
{
    public partial class DeletePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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