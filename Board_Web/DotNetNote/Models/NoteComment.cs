using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Board_Web.DotNetNote.Models
{
    public class NoteComment
    {
        public int Id { get; set; }
        public string BoardName { get; set; }
        public int Boardid { get; set; }
        public string Name { get; set; }
        public string Opinion { get; set; }
        public DateTime PostDate { get; set; }
        public string Password { get; set; }
    }
}