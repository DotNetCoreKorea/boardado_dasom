using devADONET.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace devADONET
{
    public partial class FrmMemoModify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Request["Num"]))
            {
                Response.Write("잘못된 요청입니다.");
                Response.End();
            }
            else
            {
                if (!Page.IsPostBack)
                {
                    DisplayDate();
                }
            }
        }

        private void DisplayDate()
        {
            //[1] 커넥션
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();

            //[2] 커맨드
            SqlCommand cmd = new SqlCommand("ViewMemo", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            //[!]파라미터 추가
            cmd.Parameters.Add("Num", SqlDbType.Int);
            cmd.Parameters["Num"].Value = Convert.ToInt32(Request["Num"]);

            //[3] 데이터 리더
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                //[!] 각각의 컨트롤에 바인딩
                this.lblNum.Text = Request["Num"];
                this.txtName.Text = dr["Name"].ToString();
                this.txtEmail.Text = dr[2].ToString();
                this.txtTitle.Text = dr.GetString(3);
                
            }
            else
            {
                Response.Write("없는 데이터 입니다.");
                Response.End();
            }
            dr.Close();
            con.Close();

        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            Memo memo = new Memo();
            memo.Num = Convert.ToInt32(Request["Num"]);
            memo.Name = txtName.Text;
            memo.Email = txtEmail.Text;
            memo.Title = txtTitle.Text;

            //[1] 커넥션
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();

            //[2] 커맨드
            SqlCommand cmd = new SqlCommand("ModifyMemo", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            //[!]파라미터 추가
            cmd.Parameters.AddWithValue("@Name", memo.Name);
            cmd.Parameters.AddWithValue("@Email", memo.Email);
            cmd.Parameters.AddWithValue("@Title", memo.Title);
            cmd.Parameters.AddWithValue("@Num", memo.Num);

            //[!] 실행
            cmd.ExecuteNonQuery();

            //[3] 마무리
            con.Close();
            Response.Redirect("FrmMemoView.aspx?Num=" + Request["Num"]);


        }


        protected void btnList_Click(object sender, EventArgs e)
        {
            Response.RedirectPermanent("FrmMemoList.aspx");
        }
    }
}