using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Container;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class BirimSorumlulariData : DataAccessBase
    {
        public bool BirimSorumlusu_Ekle(BirimSorumlulari B)
        {
            int id = 0;
            using (SqlConnection connect = new SqlConnection(base.ConnectionString))
            {
                string sql;
                try
                {

                    sql = "INSERT INTO BirimSorumlulari (BirimId,KullaniciAdi,Sifre,AdiSoyadi,Durum) OUTPUT INSERTED.Id VALUES(@ID,@USER,@PASS,@FULLNAME,@STATUS)";
                    connect.Open();

                    SqlCommand command = new SqlCommand(sql, connect);
                    command.Parameters.AddWithValue("@ID", B.BirimId);
                    command.Parameters.AddWithValue("@USER", B.KullaniciAdi);
                    command.Parameters.AddWithValue("@PASS", B.Sifre);
                    command.Parameters.AddWithValue("@FULLNAME", B.AdiSoyadi);
                    command.Parameters.AddWithValue("@STATUS", B.Durum);
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
        public List<BirimSorumlulari> BirimSorumlusuListele(string B_Id)
        {
            List<BirimSorumlulari> SorumluList = new List<BirimSorumlulari>();

            using (SqlConnection connect = new SqlConnection(base.ConnectionString))
            {
                string sql = "SELECT Id,BirimId,KullaniciAdi,Sifre,AdiSoyadi,Durum FROM BirimSorumlulari WHERE BirimId=@BID AND Silindi=0";
                connect.Open();

                SqlCommand command = new SqlCommand(sql, connect);
                command.Parameters.AddWithValue("@BID", B_Id);
                SqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    BirimSorumlulari B = new BirimSorumlulari();
                    B.Id = (int)read["Id"];
                    B.BirimId = (int)read["BirimId"];
                    B.KullaniciAdi = (string)read["KullaniciAdi"];
                    B.Sifre = (string)read["Sifre"];
                    B.AdiSoyadi = (string)read["AdiSoyadi"];
                    B.Durum = (Boolean)read["Durum"];

                    SorumluList.Add(B);
                }
                connect.Close();
            }
            return SorumluList;
        }
        public bool BirimSorumlusu_Sil(string B_id)
        {
            bool result = false;
            using (SqlConnection connect = new SqlConnection(base.ConnectionString))
            {
                try
                {
                    string sql = "UPDATE BirimSorumlulari SET Silindi=1 WHERE Id=@ID";
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
        public bool BirimSorumlusu_Guncelle(BirimSorumlulari B)
        {
            bool result = false;
            using (SqlConnection connect = new SqlConnection(base.ConnectionString))
            {
                try
                {
                    string sql = "UPDATE BirimSorumlulari SET KullaniciAdi=@USER, Sifre=@PASS, AdiSoyadi=@FULLNAME WHERE Id=@ID";
                    connect.Open();

                    SqlCommand command = new SqlCommand(sql, connect);
                    command.Parameters.AddWithValue("@ID", B.Id);
                    command.Parameters.AddWithValue("@USER", B.KullaniciAdi);
                    command.Parameters.AddWithValue("@PASS", B.Sifre);
                    command.Parameters.AddWithValue("@FULLNAME", B.AdiSoyadi);
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
        public BirimSorumlulari Id_Ile_BirimSorumlusu_Getir(string bid)
        {
            BirimSorumlulari B = new BirimSorumlulari();
            using (SqlConnection connect = new SqlConnection(base.ConnectionString))
            {
                string sql = "SELECT Id,BirimId,KullaniciAdi,Sifre,AdiSoyadi,Durum FROM BirimSorumlulari WHERE Silindi=0  AND Id=@BIRIM";
                connect.Open();

                SqlCommand command = new SqlCommand(sql, connect);

                command.Parameters.AddWithValue("@BIRIM", bid);
                SqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    B.Id = (int)read["Id"];
                    B.BirimId = (int)read["BirimId"];
                    B.KullaniciAdi = (string)read["KullaniciAdi"];
                    B.Sifre = (string)read["Sifre"];
                    B.AdiSoyadi = (string)read["AdiSoyadi"];
                    B.Durum = (Boolean)read["Durum"];
                }
                connect.Close();
            }

            return B;
        }
    }
}
