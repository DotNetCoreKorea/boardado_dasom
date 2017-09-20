using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EddyHomepage.Models
{
    public class ArticleEditViewModel
    {
        public Articles Article { get; set; }
        public List<ArticleFiles> Files { get; set; }
        public List<ArticleComments> Comments { get; set; }
    
    }
}