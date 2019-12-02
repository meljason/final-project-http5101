using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMSWebsite
{
    public partial class NewPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void Add_Page(object sender, EventArgs e)
        {
            PagesDB db = new PagesDB();

            Page new_page = new Page();

            new_page.SetPageTitle(page_title.Text);
            new_page.SetPageBody(page_body.Text);
            //new_page.SetPageImage(page_image.Text);
            new_page.SetUploadDate(DateTime.Now);

            db.AddPage(new_page);

            Response.Redirect("ListPages.aspx");
        }
    }
}