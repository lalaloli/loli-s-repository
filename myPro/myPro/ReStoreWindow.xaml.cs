using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
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
    /// ReStoreWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ReStoreWindow : Window
    {
        public ReStoreWindow()
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
            GoodsPic.Source = bitmap;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if(GNumber.Text == null || GoodsName.Text == null)
            {
                MessageBox.Show("商品编号或名字不能为空！");
            }
            else
            {
                MySql my = new MySql();
                SqlConnection conn = my.GetConn();

                BitmapImage goodsPic = bitmap;
                String num = GNumber.Text.ToString();
                String name = GoodsName.Text.ToString();
                int count = Convert.ToInt32(GoodsCount.Text);

                my.AddGood(conn, bitmap, name, num, count);
                my.ConnClose(conn);
            }

        }


    }
}
