using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMSWebsite
{
    public partial class UpdatePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PagesDB db = new PagesDB();
                ShowPageInfo(db);
            }
        }

        protected void Update_Page(object sender, EventArgs e)
        {
            PagesDB db = new PagesDB();

            bool valid = true;
            string pageid = Request.QueryString["pageid"];
            if (String.IsNullOrEmpty(pageid)) valid = false;

            if (valid)
            {
                Page new_page = new Page();

                new_page.SetPageTitle(page_title.Text);
                new_page.SetPageBody(page_body.Text);
                //new_page.SetPageImage(page_image.Text);


                try
                {
                    db.UpdatePage(Int32.Parse(pageid), new_page);
                    Response.Redirect("ShowPage.aspx?pageid=" + pageid);
                }
                catch
                {
                    valid = false;
                }             
            }
            if(!valid)
            {
                pages.InnerHtml = "There was an error in updating that page!";
            }
        }

        protected void ShowPageInfo(PagesDB db)
        {
            bool valid = true;
            string pageid = Request.QueryString["pageid"];
            if (String.IsNullOrEmpty(pageid)) valid = false;

            if (valid)
            {
                Page page_record = db.FindPage(Int32.Parse(pageid));
                page_title.Text = page_record.GetPageTitle();
                page_body.Text = page_record.GetPageBody();
                
            }

            if (!valid)
            {
                pages.InnerHtml = "There was an error finding that page!";
            }
        }
    }
}