using Board_Web.DotNetNote.Models;
using Dul;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Board_Web.DotNetNote.Control
{
    public partial class BoardEditorFormControl : System.Web.UI.UserControl
    {
        public BoardWriteFormType FormType { get; set; }

        private string _Id;

        private string _BaseDir = String.Empty;
        private string _FileName = String.Empty;
        private int _FileSize = 0; 

        protected void Page_Load(object sender, EventArgs e)
        {
            _Id = Request.QueryString["Id"];
            if (!Page.IsPostBack)
            {
                switch (FormType)
                {
                    case BoardWriteFormType.Write:
                        lblTitleDescription.Text = "글쓰기 - 다음 필드를 채워주세요";
                        break;
                    case BoardWriteFormType.Modify:
                        lblTitleDescription.Text = "글수정 - 아래 항목을 수정해주세요";
                        DisplayDateForModify();
                        break;
                    case BoardWriteFormType.Reply:
                        lblTitleDescription.Text = "글답변 - 다음 필드를 채워주세요.";
                        DisplayDateForReply();
                        break;
                }

            }
        }

        private void DisplayDateForModify()
        {
            //넘어온 Id 값에 해당하는 레코드를 하나 읽어서 Note 클래스에 바인딩
            var note = (new NoteRepository()).GetNoteById(Convert.ToInt32(_Id));

            txtName.Text = note.Name;
            txtEmail.Text = note.Email;
            txtHomepage.Text = note.Homepage;
            txtTitle.Text = note.Title;
            txtContent.Text = note.Content;

            //인코딩 방식에 따른 데이터 출력
            string strEncoding = note.Encoding;
            if(strEncoding == "Text")
            {
                rdoEncoding.SelectedIndex = 0;
            }
            else if(strEncoding == "Mixed")
            {
                rdoEncoding.SelectedIndex = 2;
            }
            else
            {
                rdoEncoding.SelectedIndex = 1;
            }

            // 첨부된 파일명 및 파일 크기 기록
            if(note.FileName.Length > 1)
            {
                ViewState["FileName"] = note.FileName;
                ViewState["FileSize"] = note.FileSize;

                pnlFile.Height = 50;
                lblFileNamePrevious.Visible = true;
                lblFileNamePrevious.Text = $"기존에 업로드 된 파일명:{note.FileName}";
            }
            else
            {
                ViewState["FileName"] = "";
                ViewState["FileSize"] = 0;
            }
        }
        
        private void DisplayDateForReply()
        {
            //넘어온  Id 값에 해당하는 레코드를 하나 읽어서 Note 클래스에 바인딩
            var note = (new NoteRepository()).GetNoteById(Convert.ToInt32(_Id));

            txtTitle.Text = $"Re : {note.Title}";
            txtContent.Text = "$\n\n0n {note.PostDate}, '{note.Name}' wrote:\n--------------\n>"
                + $"{note.Content.Replace("\n", "\n>")}\n------------";
        }

        protected void btnWrite_Click(object sender, EventArgs e)
        {
            if (IsImageTextCorrect())
            {
                UploadProcess();

                Note note = new Note();

                note.Id = Convert.ToInt32(_Id);

                note.Name = txtName.Text;
                note.Email = HtmlUtility.Encode(txtEmail.Text);
                note.Homepage = txtHomepage.Text;
                note.Title = HtmlUtility.Encode(txtTitle.Text);
                note.Content = txtContent.Text;
                note.FileName = _FileName;
                note.FileSize = _FileSize;
                note.Password = txtPassword.Text;
                note.PostIp = Request.UserHostAddress;
                note.Encoding = rdoEncoding.SelectedValue;

                NoteRepository repository = new NoteRepository();

                switch (FormType)
                {
                    case BoardWriteFormType.Write:
                        repository.Add(note);
                        Response.Redirect("BoardList.aspx");
                        break;
                    case BoardWriteFormType.Modify:
                        note.ModifyIp = Request.UserHostAddress;
                        note.FileName = ViewState["FileName"].ToString();
                        note.FileSize = Convert.ToInt32(ViewState["FileSIze"]);
                        int r = repository.UpdateNote(note);
                        if (r > 0)
                        {
                            Response.Redirect($"BoardView.aspx?Id={_Id}");
                        }
                        else
                        {
                            lblError.Text = "업데이트가 되지 않습니다. 암호를 확인하세요.";
                        }
                        break;
                    case BoardWriteFormType.Reply:
                        note.ParentNum = Convert.ToInt32(_Id);
                        repository.ReplyNote(note);
                        Response.Redirect("BoardList.aspx");
                        break;
                    default:
                        repository.Add(note);
                        Response.Redirect("BoardList.aspx");
                        break;
                }
            }
            else
            {
                lblError.Text = "보안코드가 틀립니다. 다시 입력하세요.";
            }
        }

        private void UploadProcess()
        {
            //파일 업로드 시작
            _BaseDir = Server.MapPath("./MyFiles");
            _FileName = String.Empty;
            _FileSize = 0; 
            if(txtFileName.PostedFile != null)
            {
                if(txtFileName.PostedFile.FileName.Trim().Length > 0 && txtFileName.PostedFile.ContentLength > 0)
                {
                    if(FormType == BoardWriteFormType.Modify)
                    {
                        ViewState["FileName"] =
                            FileUtility.GetFileNamewithNumbering(_BaseDir, Path.GetFileName(txtFileName.PostedFile.FileName));
                        ViewState["FileSize"] =
                            txtFileName.PostedFile.ContentLength;
                        txtFileName.PostedFile.SaveAs(Path.Combine(_BaseDir, ViewState["FileName"].ToString()));
                    }
                    else
                    {
                        _FileName = FileUtility.GetFileNamewithNumbering(_BaseDir, Path.GetFileName(txtFileName.PostedFile.FileName));
                        _FileSize = txtFileName.PostedFile.ContentLength;
                        txtFileName.PostedFile.SaveAs(Path.Combine(_BaseDir, _FileName));
                    }
                }
            }
        }



        private bool IsImageTextCorrect()
        {
            if (!Page.User.Identity.IsAuthenticated)
            {
                return true;
            }
            else
            {
                if(Session["ImageText"] != null)
                {
                    return (txtImageText.Text == Session["ImageText"].ToString());
                }
            }
            return false;
        }

        
        protected void chkUpload_CheckedChanged(object sender, EventArgs e)
        {
            pnlFile.Visible = !pnlFile.Visible;
        }

      
    }
}