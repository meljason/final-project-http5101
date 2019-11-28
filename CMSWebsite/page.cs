using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;

namespace CMSWebsite
{
    public class Page
    {
        private string PageTitle;
        private string PageBody;
        private HttpPostedFileBase PageImage;
        private DateTime UploadDate;

        public string GetPageTitle()
        {
            return PageTitle;
        }

        public string GetPageBody()
        {
            return PageBody;
        }

        public HttpPostedFileBase GetPageImage()
        {
            return PageImage;
        }

        public DateTime GetUploadDate()
        {
            return UploadDate;
        }

        public void SetPageTitle(string value)
        {
            PageTitle = value;
        }

        public void SetPageBody(string value)
        {
            PageBody = value;
        }

        public void SetPageImage(HttpPostedFileBase value)
        {
            PageImage = value;
        }
        public void SetUploadDate(DateTime value)
        {
            UploadDate = value;
        }

    }
}