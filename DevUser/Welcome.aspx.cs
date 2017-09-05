using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DevUser
{
    public partial class Welcome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 인증 여부 확인 : 
            if (Page.User.Identity.IsAuthenticated)
            {
                lblName.Text = Page.User.Identity.Name;
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }
    }
}