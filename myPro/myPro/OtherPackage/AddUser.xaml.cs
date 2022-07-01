using Microsoft.Win32;
using MyPro.Class;
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

namespace MyPro
{
    /// <summary>
    /// AddUser.xaml 的交互逻辑
    /// </summary>
    public partial class AddUser : Window
    {
        public AddUser()
        {
            InitializeComponent();
        }
        BitmapImage bitmap;
        private void BtnAddPic_Click(object sender, RoutedEventArgs e)
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
            Im.Source = bitmap;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MySql my = new MySql();
            SqlConnection conn = my.GetConn();
            my.AddUser(conn, bitmap, UserName.Text, UserNum.Text, UserMail.Text, UserPW.Text, Userjob.Text);
            my.ConnClose(conn);
            MessageBox.Show("添加成功！");
            this.Close();
        }
    }
}
