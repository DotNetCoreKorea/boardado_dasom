﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Board_Web.DotNetNote
{
    public partial class ImageDown : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Request.QueryString["FileName"]))
            {
                Response.End();
            }
            string fileName = Request.Params["FileName"].ToString();
            string ext = Path.GetExtension(fileName);
            string contentType = "";

            if(ext == ".gif" || ext == ".jpg" || ext == ".png" || ext == ".jpeg")
            {
                switch (ext)
                {
                    case ".gif":
                        contentType = "image/gif"; break;
                    case ".png":
                        contentType = "image/png"; break;
                    case ".jpg":
                        contentType = "image/jpg"; break;
                    case ".jpeg":
                        contentType = "image/jpeg"; break;
                }

            }
            else
            {
                Response.Write(
                    "<script language ='javascript'> alert('이미지 파일이 아닙니다.')</script>");
                Response.End();

            }
            string file = Server.MapPath("./MyFiles/") + fileName;

            Response.Clear();
            Response.ContentType = contentType;
            Response.WriteFile(file);
            Response.End();

        }
    }
}