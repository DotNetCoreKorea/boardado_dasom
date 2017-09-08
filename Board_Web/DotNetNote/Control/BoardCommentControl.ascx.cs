using Board_Web.DotNetNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Board_Web.DotNetNote.Control
{
    public partial class BoardCommentControl : System.Web.UI.UserControl
    {
        private NoteCommentsRepository _repository;

        public BoardCommentControl()
        {
            _repository = new NoteCommentsRepository();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ctlCommentList.DataSource =
                    _repository.GetNoteComments(Convert.ToInt32(Request["Id"]));
                ctlCommentList.DataBind();
            }
        }

        protected void btnWriteComment_Click(object sender, EventArgs e)
        {
            NoteComment comment = new NoteComment();
            comment.Boardid = Convert.ToInt32(Request["Id"]);
            comment.Name = txtName.Text;
            comment.Password = txtPassword.Text;
            comment.Opinion = txtOpinion.Text;

            _repository.AddNoteComment(comment);

            Response.Redirect($"{Request.ServerVariables["SCRIPT_NAME"]}?Id={Request["Id"]}");
        }
    }
}