using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PostBack_Ex
{
    /// <summary>
    /// 한 페이지에서 다른 페이지로 이동하는 것이 아닌 
    /// Submit 같은 버튼을 통해 자신에 페이지가 새로고침이 일어나는 현상
    /// </summary>
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                TextBox1.Text = "초기화 된 문자열";
            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Write(TextBox1.Text);
        }
    }
}