using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Dul
{
    public class FileUtility
    {
        /// <summary>
        /// GetFileNamewithNumbering : 중복된 파일명 뒤에 번호 붙이는 메소드
        /// </summary>
        /// <param name="dir">경로</param>
        /// <param name="name">Test.txt</param>
        /// <returns></returns>
        public static string GetFileNamewithNumbering(string dir, string name)
        {
            string strName = Path.GetFileNameWithoutExtension(name);

            string strExt = Path.GetExtension(name);
            bool blnExists = true;

            int i = 0;

            while (blnExists)
            {
                if(File.Exists(Path.Combine(dir, name)))
                {
                    name = strName + "(" + ++i + ")" + strExt;
                }
                else
                {
                    blnExists = false;
                }
            }
            return name;

        }

        
    }
}
