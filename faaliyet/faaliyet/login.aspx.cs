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
    public partial class login : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginbutton_Click(object sender, EventArgs e)
        {

        }

        protected void Birim_loginbutton_Click(object sender, EventArgs e)
        {
            BirimSorumlulari result;
            result = base.Get_login_bl.BirimSorumlusu_Login(F_Email.Value, F_Pass.Value);

            if (result.KullaniciAdi != null)
            {
                Session["BirimId"] = result.BirimId;
                Session["KullaniciAdi"] = result.KullaniciAdi;
                Session["AdiSoyadi"] = result.AdiSoyadi;
                Response.Redirect("birimislemler.aspx");
            }
            else
            {
                Response.Redirect("login.aspx");
               
            }

            

        }
    }
}