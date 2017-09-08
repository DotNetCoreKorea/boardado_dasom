using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Board_Web.DotNetNote
{
    public partial class AdvancedPagingSingleWithBootstrap : System.Web.UI.UserControl
    {
        public bool SearchMode { get; set; } = false;
        public string SearchField { get; set; }
        public string SearchQuery { get; set; }

        [Category("페이징 처리")]
        public int PageIndex { get; set; }

        [Category("페이징 처리")]
        public int PageCount { get; set; }

        [Description("한 페이지에서 몇 개의 레코드를 보여줄 건지 결정")]
        [Category("페이징 처리")]
        public int PageSize { get; set; } = 10;
        
        private int _RecordCount;

        [Category("페이징 처리")]
        [Description("현재 테이블에 몇개의 레코드가 있는지 지정")]
        public  int RecordCount
        {
            get { return _RecordCount; }
            set
            {
                _RecordCount = value;

                PageCount = ((_RecordCount - 1) / PageSize) + 1;
            }
        }

        /// <summary>
        /// 페이지 로드할 때 웹 페이지 구현하기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //검색모드 결정
            SearchMode =
                (!String.IsNullOrEmpty(Request.QueryString["SearchField"]) && !String.IsNullOrEmpty(Request.QueryString["SearchQuery"]));

            if (SearchMode)
            {
                SearchField = Request.QueryString["SearchField"];
                SearchQuery = Request.QueryString["SearchQuery"];

            }

            ++PageIndex;
            int i = 0;

            string strPage = "<ul class='pagination pagination-sm'>";
            if(PageIndex > 10)
            {
                //검색 모드이면 추가적으로 SearchField와 SearchQuery 를 전송함
                if (SearchMode)
                {
                    strPage += "<li><a href=\""
                        + Request.ServerVariables["SCRIPT_NAME"]
                        + "?Page="
                        + Convert.ToString(((PageIndex - 1) / (int)10) * 10)
                        + "&SearchField = " + SearchField
                        + "&SearchQuery = " + SearchQuery + "\">◀</a></li>";
                }
                else
                {
                    strPage += "<li><a href=\""
                        + Request.ServerVariables["SCRIPT_NAME"]
                        + "?Page="
                        + Convert.ToString(((PageIndex - 1) / (int)10) * 10)
                        + "\">◀</a></li>";
                }
            }
            else
            {
                strPage += "<li class=\"disabled\"><a>◁</a></li>";
            }

            for (
                i = (((PageIndex -1) / (int)10) * 10 +1);
                i <= ((((PageIndex - 1) / (int)10) +1) * 10);
                i++)
            {
                if (i > PageCount)
                {
                    break;
                }

                if(i== PageIndex)
                {
                    strPage += "<li class='active'><a href='#'>" + i.ToString() + "</a></li>";
                }
                else
                {
                    if (SearchMode)
                    {
                        strPage += "<li><a href=\""
                            + Request.ServerVariables["SCRIPT_NAME"]
                            + "?Page=" + i.ToString()
                            + "&SearchField=" + SearchField
                            + "&SearchQuery=" + SearchQuery + "\">"
                            + i.ToString() + "</a></li>";
                    }
                    else
                    {
                        strPage += "<li><a href=\""
                            + Request.ServerVariables["SCRIPT_NAME"]
                            + "?Page=" + i.ToString() + "\">"
                            + i.ToString() + "</a></li>";
                    }
                }
            }
            if(i < PageCount)
            {
                if (SearchMode)
                {
                    strPage += "<li><a href=\""
                         + Request.ServerVariables["SCRIPT_NAME"]
                         + "?Page="
                         + Convert.ToString(((PageIndex - 1) / (int)10) * 10 + 11)
                         + "&SearchField= " + SearchField
                         + "&SearchQuery=" + SearchQuery + "\">▶</a></li>";


                }
                else
                {
                    strPage += "<li><a href=\""
                        + Request.ServerVariables["SCRIPT_NAME"]
                        + "?Page="
                        + Convert.ToString(((PageIndex - 1) / (int)10) * 10 + 11)
                        + "\"></a></li>";
                }
            }
            else
            {
                strPage += "<li class=\"disabled\"><a>▷</a></li>";
            }
            strPage += "</ul>";

            ctlAdvancedPagingSingleWithBootstrap.Text = strPage;
        }

    }
}