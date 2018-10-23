using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Container;
using System.Data.SqlClient;


namespace DataAccessLayer
{
    public class ProsesIslemlerData : DataAccessBase
    {


        // proses islem verisi ekleme
        public bool ProsesVeri_Ekle(ProsesIslemler pi)
        {

            int id = 0;
            using (SqlConnection connect = new SqlConnection(base.ConnectionString))
            {
                string sql;
                try
                {

                    sql = "INSERT INTO  ProsesIslemler (ProsesId,BirimId,ProsesDegerId,DonemId,Veri,KullaniciAdi,OlusturmaTarihi,OlusturmaIP) OUTPUT INSERTED.Id VALUES(@pid,@bid,@pdid,@did,@veri,@kadi,@ot,@oip)";
                    connect.Open();
                    SqlCommand command = new SqlCommand(sql, connect);
                    
                    command.Parameters.AddWithValue("@pid", (object)pi.ProsesId ??(object)DBNull.Value);
                    command.Parameters.AddWithValue("@bid", (object)pi.BirimId ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@pdid", (object)pi.ProsesDegerId ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@did", (object)pi.DonemId ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@veri", (object)pi.Veri ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@kadi", (object)pi.KullaniciAdi ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@ot", (object)pi.OlusturmaTarihi ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@oip", (object)pi.OlusturmaIP ?? (object)DBNull.Value);
                    id = (int)command.ExecuteScalar();
                 


                    connect.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (connect.State == System.Data.ConnectionState.Open)
                        connect.Close();
                }
            }
            return id > 0 ? true : false;
        }
    }
}
