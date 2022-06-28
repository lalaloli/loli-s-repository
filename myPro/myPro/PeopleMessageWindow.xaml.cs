using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace myPro
{
    /// <summary>
    /// PeopleMessageWindow.xaml 的交互逻辑
    /// </summary>
    public partial class PeopleMessageWindow : Window
    {
       

        public PeopleMessageWindow(String get_userNumber)
        {
            InitializeComponent();

            MySql my = new MySql();
            Pic p = new Pic();
            User user = new User();

            SqlConnection conn = my.GetConn();
            user = my.GetUser(conn, get_userNumber);
            my.ConnClose(conn);

            UserName.Text = user.Name;
            UserAge.Text = user.Age;
            UserMail.Text = user.UserMail;
            Tel.Text = user.Tel;
            ID.Text = user.UserNumber;
            Job.Text = user.UserJob;
            JobAge.Text = user.Jobage;
            HeadPic.Source = user.Headpic;
            
        }
        BitmapImage bitmap;
        private void AddPic_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "图像文件(jpg,jpeg,bmp,gif,ico,pen,tif)|*.jpg;*.jpeg;*.bmp;*.gif;*.ico;*.png;*.tif;*.wmf";
            openFileDialog.Title = "打开`图片`:";
            openFileDialog.ShowDialog();

            String PicPath = openFileDialog.FileName;
            var PicBitmap = System.Drawing.Image.FromFile(PicPath);
            Bitmap map = new Bitmap(PicBitmap);
            Pic pic = new Pic();
            bitmap = pic.BitmapToBitmapImage(map);
            HeadPic.Source = bitmap;
        }

 

        private void KeppMessage_Click_1(object sender, RoutedEventArgs e)
        {
            MySql my = new MySql();
            SqlConnection conn = my.GetConn();

            my.UpDateUser(conn,bitmap,UserName.Text,ID.Text,UserMail.Text,Job.Text, Convert.ToInt32(UserAge.Text), Convert.ToInt32(JobAge.Text), Tel.Text);
            my.ConnClose(conn);
        }
    }
}
