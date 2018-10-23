using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinnessLayer;
using Container;

namespace faaliyet
{
    public partial class yonetim : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void YonetimLoginButton_Click(object sender, EventArgs e)
        {
            bool result;
            result = base.Get_login_bl.Yonetim_Login(F_Email.Value, F_Pass.Value);

            if (result)
            {

                Session["Yonetim"] = "Ok";

                Response.Redirect("default.aspx");
            }

            Response.Redirect("yonetim.aspx?error");

        }
    }
}