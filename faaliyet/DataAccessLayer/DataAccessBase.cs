using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;


namespace DataAccessLayer
{
    public class DataAccessBase
    {
        protected string ConnectionString = ConfigurationManager.ConnectionStrings["Faaliyet"].ConnectionString;
        //protected string ConnectionString = @"Data Source=FAHRETTIN-PC\SQLEXPRESS_FH;Initial Catalog=DB_Deneme;Integrated Security=True";
    }
}
