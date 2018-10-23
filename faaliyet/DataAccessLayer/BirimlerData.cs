using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Container;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class BirimlerData : DataAccessBase
    {
        public bool Birim_Ekle(Birimler B)
        {
            int id = 0;
            using (SqlConnection connect = new SqlConnection(base.ConnectionString))
            {
                string sql;
                try
                {
                    
                    sql = "INSERT INTO Birimler (BirimAdi) OUTPUT INSERTED.Id VALUES(@NAME)";
                    connect.Open();

                    SqlCommand command = new SqlCommand(sql, connect);
                    command.Parameters.AddWithValue("@NAME", B.BirimAdi);
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
        public List<Birimler> BirimleriListele()
        {
            List<Birimler> BirimList = new List<Birimler>();

            using (SqlConnection connect = new SqlConnection(base.ConnectionString))
            {
                string sql = "SELECT Id,BirimAdi,Durum FROM Birimler WHERE Silindi=0";
                connect.Open();

                SqlCommand command = new SqlCommand(sql, connect);
                SqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    Birimler B = new Birimler();
                    B.Id = (int)read["Id"];
                    B.BirimAdi = (string)read["BirimAdi"];
                    B.Durum = (Boolean)read["Durum"];

                    BirimList.Add(B);
                }
                connect.Close();
            }
            return BirimList;
        }
        public bool Birim_Sil(string B_id)
        {
            bool result = false;
            using (SqlConnection connect = new SqlConnection(base.ConnectionString))
            {
                try
                {
                    string sql = "UPDATE Birimler SET Silindi=1 WHERE Id=@ID";
                    connect.Open();

                    SqlCommand command = new SqlCommand(sql, connect);
                    command.Parameters.AddWithValue("@ID", B_id);
                    command.ExecuteNonQuery();

                    connect.Close();
                    result = true;
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
            return result;
        }
        public bool Birim_Guncelle(Birimler Birim)
        {
            bool result = false;
            using (SqlConnection connect = new SqlConnection(base.ConnectionString))
            {
                try
                {
                    string sql = "UPDATE Birimler SET BirimAdi=@ADI WHERE Id=@ID";
                    connect.Open();

                    SqlCommand command = new SqlCommand(sql, connect);
                    command.Parameters.AddWithValue("@ADI", Birim.BirimAdi);
                    command.Parameters.AddWithValue("@ID", Birim.Id);
                    command.ExecuteNonQuery();

                    connect.Close();
                    result = true;
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
            return result;
        }
        public Birimler Id_Ile_Birim_Getir(string bid)
        {
            Birimler B = new Birimler();
            using (SqlConnection connect = new SqlConnection(base.ConnectionString))
            {
                string sql = "SELECT Id,BirimAdi,Durum FROM Birimler WHERE Silindi=0  AND Id=@BIRIM";
                connect.Open();

                SqlCommand command = new SqlCommand(sql, connect);

                command.Parameters.AddWithValue("@BIRIM", bid);
                SqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    B.Id = (int)read["Id"];
                    B.BirimAdi = (string)read["BirimAdi"];
                    B.Durum = (Boolean)read["Durum"];
                }
                connect.Close();
            }

            return B;
        }
    }
}
