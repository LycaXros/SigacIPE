using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIGAC.WEB
{
    public partial class ErrorHandlerPage : System.Web.UI.Page
    {
        public static int ErrorCode { get; set; }
        public static string ErrorName { get; set; }
        public static string ErrorMessage { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = $" {ErrorCode} ({ErrorName})";
            Number.InnerText = ErrorCode.ToString();
            Name.InnerText = ErrorName;
            descr.InnerText = ErrorMessage;
        }
    }
}