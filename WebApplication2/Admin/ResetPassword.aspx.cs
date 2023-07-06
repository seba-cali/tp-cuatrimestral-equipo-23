using System;
using System.Web.UI;

namespace WebApplication2.Admin
{
    public partial class ResetPassword : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string code = Request.QueryString["code"];

        }
    }
}