using DevUser.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DevUser
{
    public partial class UserInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Login.aspx");
            }
            if (!Page.IsPostBack)
            {
                DisplayDate();
            }
        }

        private void DisplayDate()
        {
            UserRepository userRepo = new UserRepository();
            var model = userRepo.GetUserByUserId(Page.User.Identity.Name);

            lblUID.Text = model.Id.ToString();
            txtUserID.Text = model.UserId;
            txtPassword.Text = model.Password;
            
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            // 데이터 수정
            var UserRepo = new UserRepository();
            UserRepo.ModifyUser(Convert.ToInt32(lblUID.Text), txtUserID.Text, txtPassword.Text);

            //메세지 박스 출력
            string strJs = "<script>alert('수정완료');location.href='Default.aspx';</script>";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "goDefault", strJs);
        }
    }
}