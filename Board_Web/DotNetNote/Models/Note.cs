using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Board_Web.DotNetNote.Models
{
    public class Note
    {
        [Display(Name ="번호")]
        public int Id { get; set; }
        [Display(Name = "이름")]
        [Required(ErrorMessage ="이름을 입력하세요")]
        public string Name { get; set; }

        [Display(Name = "이메일")]
        [Required(ErrorMessage = "이메일을 정확하게 입력하세요")]
        public string Email { get; set; }

        [Display(Name = "제목")]
        [Required(ErrorMessage = "제목을 입력하세요")]
        public string Title { get; set; }
        [Display(Name = "작성일")]
        public DateTime PostDate { get; set; }
        public string PostIp { get; set; }
        [Display(Name = "내용")]
        [Required(ErrorMessage = "내용을 입력하세요")]
        public string Content { get; set; }

        [Display(Name = "암호")]
        [Required(ErrorMessage = "암호를 입력하세요")]
        public string Password { get; set; }
        public int ReadCount { get; set; }
        public string Encoding { get; set; }
        public string Homepage { get; set; }
        public DateTime ModifyDate { get; set; }
        public string ModifyIp { get; set; }
        public string FileName { get; set; }
        public int FileSize { get; set; }
        public int DownCount { get; set; }
        public int Ref { get; set; }
        public int Step { get; set; }
        public int RefOrder { get; set; }
        public int AnswerNum { get; set; }
        public int ParentNum { get; set; }
        public int CommentCount { get; set; }
        public string Category { get; set; }

    }
}