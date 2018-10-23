using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace faaliyet
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {

           

                List<String> keys = Request.Form.AllKeys.Where(key => key.Contains("txtDynamic")).ToList();
                //Response.Write(keys.Count());

                string mesaj = "";
                int i = 1;
                foreach (string key in keys)
                {
                    this.CreateTexbox("txtDynamic" + i);
                    i++;
                }
                
               // ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('" + mesaj + "');", true);
           
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if(!Page.IsPostBack)
            {
                DropDownList1.Items.Add("1");
                DropDownList1.Items.Add("2");
                DropDownList1.Items.Add("3");
            }

        }

        private void CreateTexbox(string id)
        {
            try
            {
                TextBox txt = new TextBox();
                txt.CssClass = "form-control";
                txt.ID = id;
                PanelProsesVeriler.Controls.Add(txt);
            }
            catch (Exception e)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('" + e + "');", true);
            }
        }

        protected void ProsesVeriKaydetButton_Click(object sender, EventArgs e)
        {
            string message = "";
            foreach (TextBox textBox in PanelProsesVeriler.Controls.OfType<TextBox>())
            {
                message += textBox.ID + ": " + textBox.Text + "\\n";
            }
            //ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('" + message + "');", true);
            Label1.Text = message;
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = DropDownList1.SelectedValue.ToString();
            Label1.Text = id;
            for(int i=1;i<=int.Parse(id);i++)
            {
                this.CreateTexbox("txtDynamic" + i.ToString());
            }

        }
    }
}