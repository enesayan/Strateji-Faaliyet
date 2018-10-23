using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Container;
using System.Data.SqlClient;


namespace DataAccessLayer
{
    public class ProsesData : DataAccessBase
    {
        public bool Proses_Ekle(Prosesler P)
        {
            int id = 0;
            using (SqlConnection connect = new SqlConnection(base.ConnectionString))
            {
                string sql;
                try
                {
                    
                    sql = "INSERT INTO  Prosesler (ProsesAdi,ProsesKodu,ProsesHizmetTanimi,ProsesKaynaklari,ProsesHedefi) OUTPUT INSERTED.Id VALUES(@NAME,@KOD,@HİZMET,@KAYNAK,@HEDEF)";
                    connect.Open();

                    SqlCommand command = new SqlCommand(sql, connect);
                    command.Parameters.AddWithValue("@NAME", P.ProsesAdi);
                    command.Parameters.AddWithValue("@KOD", P.ProsesKodu);
                    command.Parameters.AddWithValue("@HİZMET", P.ProsesHizmetTanimi);
                    command.Parameters.AddWithValue("@KAYNAK", P.ProsesKaynaklari);
                    command.Parameters.AddWithValue("@HEDEF", P.ProsesHedefi);
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
        public List<Prosesler> ProsesListele()
        {
            List<Prosesler> ProsesList = new List<Prosesler>();

            using (SqlConnection connect = new SqlConnection(base.ConnectionString))
            {
                string sql = "SELECT Id,ProsesAdi,ProsesKodu,ProsesHizmetTanimi,ProsesKaynaklari,ProsesHedefi,Durum FROM Prosesler WHERE Silindi=0";
                connect.Open();

                SqlCommand command = new SqlCommand(sql, connect);
                SqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    Prosesler B = new Prosesler();
                    B.Id = (int)read["Id"];
                    B.ProsesAdi = (string)read["ProsesAdi"];
                    B.ProsesKodu = (string)read["ProsesKodu"];
                    B.ProsesHizmetTanimi = (string)read["ProsesHizmetTanimi"];
                    B.ProsesKaynaklari = (string)read["ProsesKaynaklari"];
                    B.ProsesHedefi = (int)read["ProsesHedefi"];
                    B.Durum = (Boolean)read["Durum"];

                    ProsesList.Add(B);
                }
                connect.Close();
            }
            return ProsesList;
        }
        public bool Proses_Sil(string D_id)
        {
            bool result = false;
            using (SqlConnection connect = new SqlConnection(base.ConnectionString))
            {
                try
                {
                    string sql = "UPDATE Prosesler SET Silindi=1 WHERE Id=@ID";
                    connect.Open();

                    SqlCommand command = new SqlCommand(sql, connect);
                    command.Parameters.AddWithValue("@ID", D_id);
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

        public bool Proses_Guncelle(Prosesler Proses)
        {
            bool result = false;
            using (SqlConnection connect = new SqlConnection(base.ConnectionString))
            {
                try
                {
                    string sql = "UPDATE Prosesler SET ProsesAdi=@NAME,ProsesKodu=@CODE,ProsesHizmetTanimi=@SERVICES,ProsesKaynaklari=@SOURCES,ProsesHedefi=@GOALS,Durum=@STATUS WHERE Id=@ID";
                    connect.Open();

                    SqlCommand command = new SqlCommand(sql, connect);
                    command.Parameters.AddWithValue("@NAME", Proses.ProsesAdi);
                    command.Parameters.AddWithValue("@CODE", Proses.ProsesKodu);
                    command.Parameters.AddWithValue("@SERVICES", Proses.ProsesHizmetTanimi);
                    command.Parameters.AddWithValue("@SOURCES", Proses.ProsesKaynaklari);
                    command.Parameters.AddWithValue("@GOALS", Proses.ProsesHedefi);
                    command.Parameters.AddWithValue("@STATUS", Proses.Durum);
                    command.Parameters.AddWithValue("@ID", Proses.Id);
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

                return result;
            }
        }
        public Prosesler Id_Ile_Proses_Getir(string proses_id)
        {
            Prosesler d = new Prosesler();
            using (SqlConnection connect = new SqlConnection(base.ConnectionString))
            {
                string sql = "SELECT Id,ProsesAdi,ProsesKodu,ProsesHizmetTanimi,ProsesKaynaklari,ProsesHedefi,Durum FROM Prosesler WHERE Silindi=0  AND Id=@PROSES";
                connect.Open();

                SqlCommand command = new SqlCommand(sql, connect);

                command.Parameters.AddWithValue("@PROSES", proses_id);
                SqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    d.Id = (int)read["Id"];
                    d.ProsesAdi = (string)read["ProsesAdi"];
                    d.ProsesKodu = (string)read["ProsesKodu"];
                    d.ProsesHizmetTanimi = (string)read["ProsesHizmetTanimi"];
                    d.ProsesKaynaklari = (string)read["ProsesKaynaklari"];
                    d.ProsesHedefi = (int)read["ProsesHedefi"];
                    d.Durum = (Boolean)read["Durum"];
                }
                connect.Close();
            }

            return d;
        }
    }
}
