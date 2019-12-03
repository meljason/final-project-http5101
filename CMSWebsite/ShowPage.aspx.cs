using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMSWebsite
{
    public partial class ShowPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PagesDB db = new PagesDB();
            ShowPageInfo(db);

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

        protected void ShowPageInfo(PagesDB db)
        {

            bool valid = true;
            string pageid = Request.QueryString["pageid"];
            if (String.IsNullOrEmpty(pageid)) valid = false;

            if (valid)
            {

                Page page_record = db.FindPage(Int32.Parse(pageid));

                page_title_name.InnerHtml = page_record.GetPageTitle();
                page_title.InnerHtml = page_record.GetPageTitle();
                page_body.InnerHtml = page_record.GetPageBody();
                //page_image.InnerHtml = page_record.GetPageImage();
                upload_date.InnerHtml = page_record.GetUploadDate().ToString("yyyy-MM-dd");
            }
            else
            {
                valid = false;
            }


            if (!valid)
            {
                page.InnerHtml = "There was an error finding that page.";
            }
        }
    }
}