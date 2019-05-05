using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;


namespace WebApplication2
{
    /// <summary>
    /// AkıllıHaber için özet açıklama
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Bu Web Hizmeti'nin, ASP.NET AJAX kullanılarak komut dosyasından çağrılmasına, aşağıdaki satırı açıklamadan kaldırmasına olanak vermek için.
    // [System.Web.Script.Services.ScriptService]
    public class AkıllıHaber : System.Web.Services.WebService
    {
        [WebMethod]
        public DataSet YazarArama(string kullaniciadi)
        {
            Yazar member = new Yazar();



            string query = String.Format("SELECT YazarID FROM Yazar WHERE KullaniciAdi Like '%" + kullaniciadi + "%'");
            return ExecuteQueryab(query);
        }

        public DataSet ExecuteQueryab(string query)
        {
            SqlConnection con = new SqlConnection("workstation id=HaberDB.mssql.somee.com;packet size=4096;user id=senanurkiraz_SQLLogin_1;pwd=njas7u5ikz;data source=HaberDB.mssql.somee.com;persist security info=False;initial catalog=HaberDB");
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            da.SelectCommand.ExecuteNonQuery();
            DataSet dt = new DataSet();
            da.Fill(dt);
            return dt;
        }
        [WebMethod]
        public DataSet Kategori()
        {
            Kategori member = new Kategori();



            string query = String.Format("SELECT * FROM Kategori");
            return ExecuteQuerya(query);
        }

        public DataSet ExecuteQuerya(string query)
        {
            SqlConnection con = new SqlConnection("workstation id=HaberDB.mssql.somee.com;packet size=4096;user id=senanurkiraz_SQLLogin_1;pwd=njas7u5ikz;data source=HaberDB.mssql.somee.com;persist security info=False;initial catalog=HaberDB");
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            da.SelectCommand.ExecuteNonQuery();
            DataSet dt = new DataSet();
            da.Fill(dt);
            return dt;
        }
        [WebMethod]
        public DataSet Yazar()
        {

            string query = String.Format("SELECT * FROM Yazar");
            return ExecuteQueryb(query);
        }

        public DataSet ExecuteQueryb(string query)
        {
            SqlConnection con = new SqlConnection("workstation id=HaberDB.mssql.somee.com;packet size=4096;user id=senanurkiraz_SQLLogin_1;pwd=njas7u5ikz;data source=HaberDB.mssql.somee.com;persist security info=False;initial catalog=HaberDB");
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            da.SelectCommand.ExecuteNonQuery();
            DataSet dt = new DataSet();
            da.Fill(dt);
            return dt;
        }

        [WebMethod]
        public DataSet DeleteÜye(string kullaniciadi)
        {
            
            string query = String.Format("DELETE FROM Üye WHERE KullaniciAdi Like '" + kullaniciadi + "' ");
            return ExecuteQuery4(query);
        }

        public DataSet ExecuteQuery4(string query)
        {
            SqlConnection con = new SqlConnection("workstation id=HaberDB.mssql.somee.com;packet size=4096;user id=senanurkiraz_SQLLogin_1;pwd=njas7u5ikz;data source=HaberDB.mssql.somee.com;persist security info=False;initial catalog=HaberDB");
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            da.SelectCommand.ExecuteNonQuery();
            DataSet dt = new DataSet();
            da.Fill(dt);
            return dt;
        }
        [WebMethod]
        public DataSet DeleteKategori(string kategoriadi)
        {
            string query = String.Format("DELETE FROM Kategori WHERE KategoriAdi Like '" + kategoriadi + "'");

            return ExecuteQuery5(query);
        }

        public DataSet ExecuteQuery5(string query)
        {
            SqlConnection con = new SqlConnection("workstation id=HaberDB.mssql.somee.com;packet size=4096;user id=senanurkiraz_SQLLogin_1;pwd=njas7u5ikz;data source=HaberDB.mssql.somee.com;persist security info=False;initial catalog=HaberDB");
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            da.SelectCommand.ExecuteNonQuery();
            DataSet dt = new DataSet();
            da.Fill(dt);
            return dt;
        }
        [WebMethod]
        public DataSet DeleteYazar(string yazaradi)
        {
            string query = String.Format("DELETE FROM Yazar WHERE YazarAdi Like '" + yazaradi + "'");

            return ExecuteQuery6(query);
        }

        public DataSet ExecuteQuery6(string query)
        {
            SqlConnection con = new SqlConnection("workstation id=HaberDB.mssql.somee.com;packet size=4096;user id=senanurkiraz_SQLLogin_1;pwd=njas7u5ikz;data source=HaberDB.mssql.somee.com;persist security info=False;initial catalog=HaberDB");
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            da.SelectCommand.ExecuteNonQuery();
            DataSet dt = new DataSet();
            da.Fill(dt);
            return dt;
        }
        [WebMethod]
        public bool AddKategori(string kategoriadi)
        {
            Kategori member = new Kategori();


            member.KategoriAdi = kategoriadi;
          


            bool result = false;

            try
            {
                HaberDBEntities2 db = new HaberDBEntities2();
                db.Kategori.Add(member);
                db.SaveChanges();



                result = true;
            }
            catch (Exception e)
            {
                return result;
            }

            return result;
        }
        [WebMethod]
        public bool AddYazar(string yazaradi,string kullaniciadi)
        {
            Yazar member = new Yazar();


            member.YazarAdi = yazaradi;
            member.KullaniciAdi = kullaniciadi;


            bool result = false;

            try
            {
                HaberDBEntities2 db = new HaberDBEntities2();
                db.Yazar .Add(member);
                db.SaveChanges();


                result = true;
            }
            catch (Exception)
            {
                return result;
            }

            return result;
        }
        [WebMethod]
        public DataSet GetSecim(string yazaradi,string kategoriadi)
        {
         
            string query = String.Format("SELECT mp3 FROM Makale WHERE  YazarID IN(SELECT YazarID FROM Yazar WHERE YazarAdi Like '%" + yazaradi + "%') AND KategoriID IN(SELECT KategoriID FROM Kategori WHERE KategoriAdi Like '%" + kategoriadi + "%')");
            return ExecuteQuery1(query);
        }

        public DataSet ExecuteQuery1(string query)
        {
            SqlConnection con = new SqlConnection("workstation id=HaberDB.mssql.somee.com;packet size=4096;user id=senanurkiraz_SQLLogin_1;pwd=njas7u5ikz;data source=HaberDB.mssql.somee.com;persist security info=False;initial catalog=HaberDB");
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            da.SelectCommand.ExecuteNonQuery();
            DataSet dt = new DataSet();
            da.Fill(dt);
            return dt;
        }
        [WebMethod]
        public DataSet GetMakale(string baslik,string icerik)
        {
            
            string query = String.Format("SELECT * FROM Makale WHERE  Baslık Like '%"+baslik+"%' AND Icerik Like  '%"+icerik+ "%'  ");
            return ExecuteQuery2(query);
        }

        public DataSet ExecuteQuery2(string query)
        {
            SqlConnection con = new SqlConnection("workstation id=HaberDB.mssql.somee.com;packet size=4096;user id=senanurkiraz_SQLLogin_1;pwd=njas7u5ikz;data source=HaberDB.mssql.somee.com;persist security info=False;initial catalog=HaberDB");
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            da.SelectCommand.ExecuteNonQuery();
            DataSet dt = new DataSet();
            da.Fill(dt);
            return dt;
        }

        [WebMethod]
            public List<Üye> GetMembers()
            {
            HaberDBEntities2 db = new HaberDBEntities2();
                return db.Üye.ToList();
            }
        [WebMethod]
        public bool MemberDogrula(string kullaniciadi, string sifre)
        {
            Üye member = new Üye();


           
            member.KullaniciAdi = kullaniciadi;
            member.Sifre = sifre;
            bool result = false;

            try
            {
                HaberDBEntities2 db = new HaberDBEntities2();


            
                string query = String.Format("SELECT COUNT(*) FROM Üye WHERE KullaniciAdi Like  '%" + kullaniciadi + "%' AND Sifre Like  '%" + sifre + "%'  ");
                SqlConnection con = new SqlConnection("workstation id=HaberDB.mssql.somee.com;packet size=4096;user id=senanurkiraz_SQLLogin_1;pwd=njas7u5ikz;data source=HaberDB.mssql.somee.com;persist security info=False;initial catalog=HaberDB");
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = query;
                con.Open();
             

                Int32 dr = Convert.ToInt32(cmd.ExecuteScalar());
                if (dr == 0) 
                {
                    result = false;
                }
             

                else

                result = true;
            }
            catch (Exception)
            {
                return result;
            }

            return result;
          
        }
       


        [WebMethod]
            public bool AddMember(string ad, string soyad, string email, string kullaniciadi, string sifre)
            {

            Üye member = new Üye();


            member.Ad = ad;
            member.Soyad = soyad;
            member.Email = email;
            member.KullaniciAdi = kullaniciadi;
            member.Sifre = sifre;

            bool result = false;

                try
                {
                if (ad != "" && soyad != "" && email != "" && kullaniciadi != "" && sifre != "")
                {
                    HaberDBEntities2 db = new HaberDBEntities2();
                    db.Üye.Add(member);
                    db.SaveChanges();


                    result = true;
                }
                }
                catch (Exception)
                {
                    return result;
                }

                return result;
            }
        [WebMethod]
        public bool AddMakale(int yazarid, int kategoriid, string baslik, string icerik)
        {
            Makale member = new Makale();
           
           
            member.YazarID = yazarid;

            member.KategoriID = kategoriid;
            member.Baslık = baslik;
            member.Icerik = icerik;
           

            bool result = false;

            try
            {
                HaberDBEntities2 db = new HaberDBEntities2();
                db.Makale.Add(member);
                db.SaveChanges();


                result = true;
            }
            catch (Exception)
            {
                return result;
            }

            return result;
        }
    }
    }

