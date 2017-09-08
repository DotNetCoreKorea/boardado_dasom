using Board_Web.DotNetNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Board_Web.DotNetNote
{
    public partial class BoardCommentDelete : System.Web.UI.Page
    {
        public int BoardId { get; set; }
        public int Id { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request["BoardId"] != null && Request.QueryString["Id"] != null)
            {
                BoardId = Convert.ToInt32(Request["BoardId"]);
                Id = Convert.ToInt32(Request["Id"]);
            }
            else
            {
                Response.End();
            }
        }

        protected void btnCommentDelete_Click(object sender, EventArgs e)
        {
            var repo = new NoteCommentsRepository();

            if(repo.GetCountBy(BoardId, Id, txtPassword.Text) > 0)
            {
                repo.DeleteNoteComment(BoardId, Id, txtPassword.Text);
                Response.Redirect($"/DotNetNote/BoardView.aspx?Id={BoardId}");
            }
            else
            {
                lblError.Text = "암호가 틀립니다. 다시 입력해주세요.";
            }
        }
    }
}