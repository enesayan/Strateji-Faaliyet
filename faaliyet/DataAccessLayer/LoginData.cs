using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Container;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class LoginData : DataAccessBase
    {

        public bool YonetimLogin(string email, string pass)
        {
            using (SqlConnection connect = new SqlConnection(base.ConnectionString))
            {
                string sql = "SELECT COUNT(Id) FROM Yoneticiler WHERE KullaniciAdi=@user AND Sifre=@pass";
                connect.Open();

                SqlCommand command = new SqlCommand(sql, connect);
                command.Parameters.AddWithValue("@user", email);
                command.Parameters.AddWithValue("@pass", pass);
                int count = Convert.ToInt32(command.ExecuteScalar());
                connect.Close();

                if (count == 1)
                    return true;
                else
                    return false;
            }

        }
        public bool BirimLogin(string email, string pass)
        {
            using (SqlConnection connect = new SqlConnection(base.ConnectionString))
            {
                string sql = "SELECT COUNT(Id) FROM BirimSorumlulari WHERE KullaniciAdi=@mail AND Sifre=@pass";
                connect.Open();

                SqlCommand command = new SqlCommand(sql, connect);
                command.Parameters.AddWithValue("@mail", email);
                command.Parameters.AddWithValue("@pass", pass);
                int count = Convert.ToInt32(command.ExecuteScalar());
                connect.Close();

                if (count == 1)
                    return true;
                else
                    return false;
            }

        }

        // birim sorumlusunu getiriyor login sayfasına
        public BirimSorumlulari BirimSorumlusuGiris(string email, string pass)
        {
            BirimSorumlulari bs = new BirimSorumlulari();
            using (SqlConnection connect = new SqlConnection(base.ConnectionString))
            {
                string sql = "SELECT * FROM BirimSorumlulari WHERE KullaniciAdi=@mail AND Sifre=@pass";
                connect.Open();
                SqlCommand command = new SqlCommand(sql, connect);
                command.Parameters.AddWithValue("@mail", email);
                command.Parameters.AddWithValue("@pass", pass);
                SqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    bs.BirimId = (int)read["BirimId"];
                    bs.KullaniciAdi = (string)read["KullaniciAdi"];
                    bs.AdiSoyadi = (string)read["AdiSoyadi"];
                }
                connect.Close();
            }
            return bs;
        }

    }
}
