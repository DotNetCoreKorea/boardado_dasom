using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Board_Web.DotNetNote
{
    public partial class ThumbNail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int boxWidth = 100;
            int boxHeigth = 100;
            double scale = 0;

            string fileName = String.Empty;
            string selectedFile = String.Empty;

            if(Request["FileName"] != null)
            {
                selectedFile = Request.QueryString["FileName"];
                fileName = Server.MapPath("./MyFiles/" + selectedFile);
            }
            else
            {
                selectedFile = "/images/dnn/img.jpg";
                fileName = Server.MapPath("/imges/dnn/img.jpg");
            }
        }
    }
}