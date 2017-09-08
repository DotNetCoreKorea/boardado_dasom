using Board_Web.DotNetNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Board_Web.DotNetNote
{
    public partial class BoardList : System.Web.UI.Page
    {
        public bool SearchMode { get; set; } = false; 
        public string SearchField { get; set; }
        public  string SearchQuery { get; set; }

        public int PageIndex = 0; //현재 보여줄 페이지 번호
        public int RecordCount = 0; // 총 레코드 개수(글번호 순서 정렬용)

        private NoteRepository _repository;
        public BoardList()
        {
            _repository = new NoteRepository();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            SearchMode =
                (!String.IsNullOrEmpty(Request.QueryString["SearchField"]) && !String.IsNullOrEmpty(Request.QueryString["SearchQuery"]));
            if (SearchMode)
            {
                SearchField = Request.QueryString["SearchField"];
                SearchQuery = Request.QueryString["SearchQuery"];
            }

            if(Request["Page"] != null)
            {
                PageIndex = Convert.ToInt32(Request["Page"]) - 1;
            }
            else
            {
                PageIndex = 0;// 1페이지
            }

            if(Request.Cookies["DotNetNote"] != null)
            {
                if (!String.IsNullOrEmpty(Request.Cookies["DotNetNote"]["PageNum"]))
                {
                    PageIndex = Convert.ToInt32(Request.Cookies["DotNetNote"]["PageNum"]);
                }
                else
                {
                    PageIndex = 0;
                }

            }

            //레코드 카운트 출력
            if (SearchMode == false)
            {
                RecordCount =
                    _repository.GetCountAll();
            }
            else
            {
                RecordCount =
                    _repository.GetCountBySearch(SearchField, SearchQuery);
            }
            lblTotalRecord.Text = RecordCount.ToString();

            AdvancedPagingSingleWithBootstrap.PageIndex = PageIndex;
            AdvancedPagingSingleWithBootstrap.RecordCount = RecordCount;

            if (!Page.IsPostBack)
            {
                DisplayDate();
            }
        }

        private void DisplayDate()
        {
            if(SearchMode == false)
            {
                ctlBoardList.DataSource = _repository.GetAll(PageIndex);
            }
            else
            {
                ctlBoardList.DataSource = _repository.GetSearchAll(PageIndex, SearchField, SearchQuery);
            }
            ctlBoardList.DataBind();
        }
    }
}