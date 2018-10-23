using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Container;
using System.Data.SqlClient;


namespace DataAccessLayer
{
    public class ProsesDegerleriData : DataAccessBase
    {
        public bool ProsesDegeri_Ekle(ProsesDegerleri P)
        {
            int id = 0;
            using (SqlConnection connect = new SqlConnection(base.ConnectionString))
            {
                string sql;
                try
                {

                    sql = "INSERT INTO  ProsesDegerleri (ProsesId,Gorev) OUTPUT INSERTED.Id VALUES(@PROSES,@SERVICE)";
                    connect.Open();

                    SqlCommand command = new SqlCommand(sql, connect);
                    command.Parameters.AddWithValue("@PROSES", P.ProsesId);
                    command.Parameters.AddWithValue("@SERVICE", P.Gorev);
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
        public List<ProsesDegerleri> ProsesDegeriListele()
        {
            List<ProsesDegerleri> ProsesDegerList = new List<ProsesDegerleri>();

            using (SqlConnection connect = new SqlConnection(base.ConnectionString))
            {
                string sql = "SELECT Id,ProsesId,Gorev,Durum FROM ProsesDegerleri WHERE Silindi=0";
                connect.Open();

                SqlCommand command = new SqlCommand(sql, connect);
                SqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    ProsesDegerleri B = new ProsesDegerleri();
                    B.Id = (int)read["Id"];
                    B.ProsesId = (int)read["ProsesId"];
                    B.Gorev = (string)read["Gorev"];
                    B.Durum = (Boolean)read["Durum"];

                    ProsesDegerList.Add(B);
                }
                connect.Close();
            }
            return ProsesDegerList;
        }

        //  proses id ye göre proses değerlerini getir
        public List<ProsesDegerleri> ProsesDegeriListelewithProsesId(string pdId)
        {
            List<ProsesDegerleri> ProsesDegerList = new List<ProsesDegerleri>();

            using (SqlConnection connect = new SqlConnection(base.ConnectionString))
            {
                string sql = "SELECT Id,ProsesId,Gorev,Durum FROM ProsesDegerleri WHERE Silindi=0 AND ProsesId=@PROSESDEGER";
                connect.Open();

                SqlCommand command = new SqlCommand(sql, connect);
                command.Parameters.AddWithValue("@PROSESDEGER", pdId);
                SqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    ProsesDegerleri B = new ProsesDegerleri();
                    B.Id = (int)read["Id"];
                    B.ProsesId = (int)read["ProsesId"];
                    B.Gorev = (string)read["Gorev"];
                    B.Durum = (Boolean)read["Durum"];

                    ProsesDegerList.Add(B);
                }
                connect.Close();
            }
            return ProsesDegerList;
        }
        public bool ProsesDegeri_Sil(string D_id)
        {
            bool result = false;
            using (SqlConnection connect = new SqlConnection(base.ConnectionString))
            {
                try
                {
                    string sql = "UPDATE ProsesDegerleri SET Silindi=1 WHERE Id=@ID";
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

        public bool ProsesDegeri_Guncelle(ProsesDegerleri ProsesDegeri)
        {
            bool result = false;
            using (SqlConnection connect = new SqlConnection(base.ConnectionString))
            {
                try
                {
                    string sql = "UPDATE ProsesDegerleri SET ProsesId=@PROSES,Gorev=@SERVICE WHERE Id=@ID";
                    connect.Open();

                    SqlCommand command = new SqlCommand(sql, connect);
                    command.Parameters.AddWithValue("@PROSES", ProsesDegeri.ProsesId);
                    command.Parameters.AddWithValue("@SERVICE", ProsesDegeri.Gorev);
                    command.Parameters.AddWithValue("@ID", ProsesDegeri.Id);
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
        public ProsesDegerleri Id_Ile_ProsesDegeri_Getir(string prosesDeger_id)
        {
            ProsesDegerleri B = new ProsesDegerleri();
            using (SqlConnection connect = new SqlConnection(base.ConnectionString))
            {
                string sql = "SELECT Id,ProsesId,Gorev,Durum FROM ProsesDegerleri WHERE Silindi=0  AND Id=@PROSESDEGER";
                connect.Open();

                SqlCommand command = new SqlCommand(sql, connect);

                command.Parameters.AddWithValue("@PROSESDEGER", prosesDeger_id);
                SqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    B.Id = (int)read["Id"];
                    B.ProsesId = (int)read["ProsesId"];
                    B.Gorev = (string)read["Gorev"];
                    B.Durum = (Boolean)read["Durum"];

                }
                connect.Close();
            }

            return B;
        }
    }
}
