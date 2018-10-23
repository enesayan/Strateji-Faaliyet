using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Container;

namespace faaliyet
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Birim_Id"] != null)
            {
                Hosgeldiniz_label.Text = "Buraya Birim Adı Yazılacaktır!!!";
            }
            else if (Session["Yonetim"] != null)
            {
                Hosgeldiniz_label.Text = "Sistem Yöneticisi Hesabı";
            }
        }
    }
}