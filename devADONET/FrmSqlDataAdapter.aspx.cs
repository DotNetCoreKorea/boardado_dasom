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
    public partial class FrmSqlDataAdapter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = @" 
                    Select Num, Name, Email, Title, PostDate, PostIP FROM Memos Order BY Num Desc
                ";
            cmd.CommandType = CommandType.Text;

            //[1]DataAdapter 
            SqlDataAdapter da = new SqlDataAdapter();
            //[2] selectCommand 지정
            da.SelectCommand = cmd;

            //[3]DataSet: 메모리상의 데이터베이스
            DataSet ds = new DataSet();

            //[4]Fill() 메소드로 DataSet 채우기
            da.Fill(ds, "Memos");

            //[!]출력
            ctlMemoLists.DataSource = ds.Tables[0].DefaultView;
            ctlMemoLists.DataBind();

            con.Close();

        }
    }
}