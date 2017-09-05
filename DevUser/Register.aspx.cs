using DevUser.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DevUser
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            //데이터 저장
            var UserRepo = new UserRepository();
            UserRepo.AddUser(txtUserID.Text, txtPassword.Text);
            string strJs = "<script>alert('가입완료');location.href='Default.aspx';</script>";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "goDefault", strJs);
        }
    }
}