using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows;
using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;

namespace myPro
{
    public class MySql
    {
        public SqlConnection GetConn()
        {
            String SinSql = "Server=.;DataBase=storehouse;User ID=sa;Pwd=123456";

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = SinSql;
            conn.Open();

            return conn;
        }

        public void ConnClose(SqlConnection conn)
        {
            conn.Close();
            MessageBox.Show("数据库已连接现在已断开！");
            return;
        }

        public List<StoreGoods> GetGoods(SqlConnection conn)
        {
            List<StoreGoods> goodss = new List<StoreGoods>();

            string sql = "select * from goods ;";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                StoreGoods goods = new StoreGoods();

                goods.Name = reader["name"].ToString();
                goods.num = reader["num"].ToString();
                goods.count = reader["count"].ToString();


                long len = reader.GetBytes(reader.GetOrdinal("picture"), 0, null, 0, 0);
                byte[] pic = new byte[len];
                len = reader.GetBytes(reader.GetOrdinal("picture"), 0, pic, 0, (int)len);
                Pic bitpic = new Pic();
                goods.Img = bitpic.ByteArrayToBitmapImage(pic);
                goodss.Add(goods);
            }
            return goodss;
        }

        public List<User> GetUsers(SqlConnection conn)
        {
            List<User> users = new List<User>();

            string sql = "select * from myuser ;";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                User user = new User();

                user.Name = reader["name"].ToString();
            //    user.num = reader["num"].ToString();
             //   user.count = reader["count"].ToString();


                long len = reader.GetBytes(reader.GetOrdinal("headpic"), 0, null, 0, 0);
                byte[] pic = new byte[len];
                len = reader.GetBytes(reader.GetOrdinal("headpic"), 0, pic, 0, (int)len);
                Pic bitpic = new Pic();
                user.Headpic = bitpic.ByteArrayToBitmapImage(pic);
                users.Add(user);
            }
            return users;
        }

        public void AddGood(SqlConnection conn, BitmapImage picture, String name, String num, int count)
        {
            String sql = "insert into goods (num,name,picture,count) values(" + num + " ," + "'" + name + "'" + " ,@Pic," + count + ");";
            Pic p = new Pic();
            byte[] BP = p.BitmapImageToByteArray(picture);

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@Pic", SqlDbType.Image).Value = BP;
                cmd.ExecuteNonQuery();
            }

        }

        public void AddUser(SqlConnection conn, BitmapImage picture, String name, String num, String mail, String password, String job)
        {
            String sql;
            if (picture == null)
            {
                sql = "insert into myuser (number,mail,pword,job) values(" + num + " ," + "'" + mail + "'" + "," + "'" + password + "'" + "," + "'" + job + "'" + "); ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            else
            {
                sql = "insert into user (number,name,headpic,mail,pword,job) values(" + num + " ," + "'" + name + "'" + " ,@Pic," + "'" + mail + "'" + "," + "'" + password + "'" + "," + "," + "'" + job + "'" + ");";
                Pic p = new Pic();
                byte[] BP = p.BitmapImageToByteArray(picture);

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@Pic", SqlDbType.Image).Value = BP;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpDateUser(SqlConnection conn, BitmapImage picture, String name, String num, String mail, String job,int age,int jobage,String tel) 
        {
            String sql;
            Pic p = new Pic();
            byte[] BP = p.BitmapImageToByteArray(picture);
            sql = "update myuser set name="+"'"+name+"'"+",headpic=@pic,tel="+"'"+tel+"'"+",age="+"'"+age+"'"+",job="+"'"+job+"'"+",jobage="+"'"+jobage+"'"+" where number="+"'"+num+"'"+";";

           // sql = String.Format(sql, name, BP, tel, age, jobage,num);
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@Pic", SqlDbType.Image).Value = BP;
            cmd.ExecuteNonQuery();
        }

        public  String FindUser(SqlConnection conn, String ID)
        {
            String password = "";
            String sql = "select pword from myuser where mail =" + "'" + ID + "'" + ";";

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
  
                if (reader.HasRows)
                {
                    reader.Read();
                    password = reader["pword"].ToString();
                }
                else
                {
                    MessageBox.Show("用户名或密码错误！");
                }
            
            reader.Close();
            
            return password;
        }//密码判定

        public User FindUserMessage(SqlConnection conn, String ID)
        {
            User user = new User();
            Pic p = new Pic();

            String sql = "select * from myuser where mail =" + "'" + ID + "'" + ";";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
    
                if (reader.HasRows)
                {
                    reader.Read();
                    user.Name = reader["Name"].ToString().Split(' ').FirstOrDefault();
                    user.UserNumber = reader["number"].ToString().Split(' ').FirstOrDefault();
                try
                {
                    long len = reader.GetBytes(reader.GetOrdinal("headpic"), 0, null, 0, 0);
                    byte[] pic = new byte[len];
                    len = reader.GetBytes(reader.GetOrdinal("headpic"), 0, pic, 0, (int)len);
                    Pic bitpic = new Pic();
                    user.Headpic = bitpic.ByteArrayToBitmapImage(pic);
                }
                catch (Exception e)
                {

                }


                }
                else
                {
                    user.Headpic = null;
                    user.Name = null;
                }
            
            
            return user;
        }//获得头像和名字

        public User GetUser(SqlConnection conn, String ID)
        {
            User user = new User();
            Pic bitpic = new Pic();
            String sql = "select * from myuser where number='{0}';";
            sql = String.Format(sql, ID);
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            user.UserNumber = reader["number"].ToString().Split(' ').FirstOrDefault();
            user.Name = reader["name"].ToString().Split(' ').FirstOrDefault();
            user.Age = reader["age"].ToString().Split(' ').FirstOrDefault();
            user.UserJob = reader["job"].ToString().Split(' ').FirstOrDefault();
            user.UserMail = reader["mail"].ToString().Split(' ').FirstOrDefault();
            user.Tel = reader["tel"].ToString().Split(' ').FirstOrDefault();
            user.Jobage = reader["jobage"].ToString().Split(' ').FirstOrDefault();
            try
            {
                long len = reader.GetBytes(reader.GetOrdinal("headpic"), 0, null, 0, 0);
                byte[] pic = new byte[len];
                len = reader.GetBytes(reader.GetOrdinal("headpic"), 0, pic, 0, (int)len);

                user.Headpic = bitpic.ByteArrayToBitmapImage(pic);
            }
            catch(Exception e)
            {

            }


            return user;
        }
    }

}