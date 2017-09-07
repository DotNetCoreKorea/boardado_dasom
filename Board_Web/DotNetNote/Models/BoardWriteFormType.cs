using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Board_Web.DotNetNote.Models
{
    public enum BoardWriteFormType
    {
        /// <summary>
        /// 글 쓰기 페이지
        /// </summary>
        Write,
        /// <summary>
        /// 글 수정 페이지
        /// </summary>
        Modify,
        /// <summary>
        /// 글 답변 페이지
        /// </summary>
        Reply
    }
}