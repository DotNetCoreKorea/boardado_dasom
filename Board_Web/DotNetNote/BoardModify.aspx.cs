﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Board_Web.DotNetNote
{
    public partial class BoardModify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ctlBoardEditorFormControl.FormType = Models.BoardWriteFormType.Modify;
        }
    }
}