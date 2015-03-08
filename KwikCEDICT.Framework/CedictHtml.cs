using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KwikCEDICT.Framework
{
    class CedictHtml
    {
        private static string _template = "<!DOCTYPE html>" +
            "<head>" +
            "<title>Kwik CEDICT</title>" +
            "<style type=\"text/css\">" +
            "body {" +
            "font-family: Tahoma, Geneva, sans-serif;" +
            "font-size: 20pt;" +
            "}" +
            ".TextChinese {" +
            "font-family: \"Adobe Kaiti Std R\";" +
            "}" +
            "</style>" +
            "</head>" +
            "<body>" +
            "<table width=\"100%\" border=\"0\">" +
            "<tr>" +
            "<td width=\"22%\">Simplified:</td>" +
            "<td width=\"78%\"><a class=\"TextChinese\">{0}</a></td>" +
            "</tr>" +
            "<tr>" +
            "<td>Traditional:</td>" +
            "<td><a class=\"TextChinese\">{1}</a></td>" +
            "</tr>" +
            "<tr>" +
            "<td>Pinyin:</td>" +
            "<td>{2}</td>" +
            "</tr>" +
            "<tr>" +
            "<td>English:</td>" +
            "<td>{3}</a></td>" +
            "</tr>" +
            "</table>" +
            "</body>";

        public static string Template { get { return _template; } }
    }
}
