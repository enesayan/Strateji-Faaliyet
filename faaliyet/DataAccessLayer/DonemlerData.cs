using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Container;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DonemlerData : DataAccessBase
    {
        public bool Donem_Ekle(Donemler D)
        {
            int id = 0;
            using (SqlConnection connect = new SqlConnection(base.ConnectionString))
            {
                string sql;
                try
                {

                    sql = "INSERT INTO Donemler (DonemAdi,BaslangicTarih,BitisTarih) OUTPUT INSERTED.Id VALUES(@NAME,@START,@FINISH)";
                    connect.Open();

                    SqlCommand command = new SqlCommand(sql, connect);
                    command.Parameters.AddWithValue("@NAME", D.DonemAdi);
                    command.Parameters.AddWithValue("@START", D.BaslangicTarih);
                    command.Parameters.AddWithValue("@FINISH", D.BitisTarih);
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

        // proses değer girerken aktif dönemi getirmek için
        public Donemler AktifDonemGetir()
        {
            Donemler d = new Donemler();
            using (SqlConnection connect = new SqlConnection(base.ConnectionString))
            {
                string sql = "SELECT Id,DonemAdi,BaslangicTarih,BitisTarih,Durum FROM Donemler WHERE Durum=@Aktif";
                connect.Open();

                SqlCommand command = new SqlCommand(sql, connect);

                command.Parameters.AddWithValue("@aktif", 1);
                SqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    d.Id = (int)read["Id"];
                    d.DonemAdi = (string)read["DonemAdi"];
                    d.BaslangicTarih = (DateTime)read["BaslangicTarih"];
                    d.BaslangicTarihYIL = d.BaslangicTarih.ToString("yyyy");
                    d.BaslangicTarihAY = d.BaslangicTarih.ToString("MM");
                    d.BaslangicTarihGUN = d.BitisTarih.Day;
                    d.BitisTarih = (DateTime)read["BitisTarih"];
                    d.BitisTarihYIL = d.BitisTarih.ToString("yyyy");
                    d.BitisTarihAY = d.BitisTarih.ToString("MM");
                    d.BitisTarihGUN = d.BitisTarih.Day;
                    d.Durum = (int)read["Durum"];

                    if (d.Durum == 2 || (DateTime.Now < d.BitisTarih && DateTime.Now > d.BaslangicTarih))
                    {
                        d.DurumAciklama = "Veri Girilebilir";
                    }
                    else
                    {
                        d.DurumAciklama = "Veri Girilemez";
                    }
                }
                connect.Close();
            }

            return d;
        }
        public List<Donemler> DonemleriListele()
        {
            List<Donemler> DonemList = new List<Donemler>();

            using (SqlConnection connect = new SqlConnection(base.ConnectionString))
            {
                string sql = "SELECT Id,DonemAdi,BaslangicTarih,BitisTarih,Durum FROM Donemler WHERE Silindi=0";
                connect.Open();

                SqlCommand command = new SqlCommand(sql, connect);
                SqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    Donemler d = new Donemler();
                    d.Id = (int)read["Id"];
                    d.DonemAdi = (string)read["DonemAdi"];
                    d.BaslangicTarih = (DateTime)read["BaslangicTarih"];
                    d.BaslangicTarihYIL = d.BaslangicTarih.ToString("yyyy");
                    d.BaslangicTarihAY = d.BaslangicTarih.ToString("MM");
                    d.BaslangicTarihGUN = d.BaslangicTarih.Day;
                    d.BitisTarih = (DateTime)read["BitisTarih"];
                    d.BitisTarihYIL = d.BitisTarih.ToString("yyyy");
                    d.BitisTarihAY = d.BitisTarih.ToString("MM");
                    d.BitisTarihGUN = d.BitisTarih.Day;
                    d.Durum = (int)read["Durum"];

                    if (d.Durum == 2 || DateTime.Now < d.BitisTarih)
                    {
                        d.DurumAciklama = "Veri Girilebilir";
                    }
                    else
                    {
                        d.DurumAciklama = "Veri Girilemez";
                    }
                    DonemList.Add(d);
                }
                connect.Close();
            }
            return DonemList;
        }
        public bool Donem_Sil(string D_id)
        {
            bool result = false;
            using (SqlConnection connect = new SqlConnection(base.ConnectionString))
            {
                try
                {
                    string sql = "UPDATE Donemler SET Silindi=1 WHERE Id=@ID";
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
        public bool Donem_Guncelle(Donemler Donem)
        {
            bool result = false;
            using (SqlConnection connect = new SqlConnection(base.ConnectionString))
            {
                try
                {
                    string sql = "UPDATE Donemler SET DonemAdi=@NAME,BaslangicTarih=@START,BitisTarih=@FINISH,Durum=@STATUS WHERE Id=@ID";
                    connect.Open();

                    SqlCommand command = new SqlCommand(sql, connect);
                    command.Parameters.AddWithValue("@NAME", Donem.DonemAdi);
                    command.Parameters.AddWithValue("@START", Donem.BaslangicTarih);
                    command.Parameters.AddWithValue("@FINISH", Donem.BitisTarih);
                    command.Parameters.AddWithValue("@STATUS", Donem.Durum);
                    command.Parameters.AddWithValue("@ID", Donem.Id);
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
        public Donemler Id_Ile_Donem_Getir(string donem_id)
        {
            Donemler d = new Donemler();
            using (SqlConnection connect = new SqlConnection(base.ConnectionString))
            {
                string sql = "SELECT Id,DonemAdi,BaslangicTarih,BitisTarih,Durum FROM Donemler WHERE Silindi=0  AND Id=@BIRIM";
                connect.Open();

                SqlCommand command = new SqlCommand(sql, connect);

                command.Parameters.AddWithValue("@BIRIM", donem_id);
                SqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    d.Id = (int)read["Id"];
                    d.DonemAdi = (string)read["DonemAdi"];
                    d.BaslangicTarih = (DateTime)read["BaslangicTarih"];
                    d.BaslangicTarihYIL = d.BaslangicTarih.ToString("yyyy");
                    d.BaslangicTarihAY = d.BaslangicTarih.ToString("MM");
                    d.BaslangicTarihGUN = d.BitisTarih.Day;
                    d.BitisTarih = (DateTime)read["BitisTarih"];
                    d.BitisTarihYIL = d.BitisTarih.ToString("yyyy");
                    d.BitisTarihAY = d.BitisTarih.ToString("MM");
                    d.BitisTarihGUN = d.BitisTarih.Day;
                    d.Durum = (int)read["Durum"];

                    if (d.Durum == 2 || DateTime.Now < d.BitisTarih)
                    {
                        d.DurumAciklama = "Veri Girilebilir";
                    }
                    else
                    {
                        d.DurumAciklama = "Veri Girilemez";
                    }
                }
                connect.Close();
            }

            return d;
        }
    }
}
