using Microsoft.Win32;
using MyPro.Class;
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

namespace MyPro
{
    /// <summary>
    /// ReStoreWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ReStoreWindow : Window
    {

        public List<StoreGoods> StoreGoodss;
        public ReStoreWindow(List<StoreGoods> Goods_s)
        {
            StoreGoodss = Goods_s;
            
            InitializeComponent();
        }
        BitmapImage bitmap = null;
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
            if (GNumber.Text == null || GoodsName.Text == null)
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
                int scount = Convert.ToInt32(StorageGoodsCount.Text);
                my.AddGood(conn, bitmap, name, num, count, scount);
                my.ConnClose(conn);
                this.Close();
            }

        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            if (CB.Content.ToString() == "修改")
            {

                bool a = true;
                int n = 0;
               
                for (int i = 0; i < StoreGoodss.Count(); i++)
                {
                   
                    if (StoreGoodss[i].num == GNumber.Text)
                    {
                       
                        a = false;
                        n = i;
                        break;
                    }
                }

                if (a)
                {
                    MessageBox.Show("此编号货物不存在！");
                }
                else
                {
                   
                    GoodsName.Text = StoreGoodss[n].Name.Split(':')[1];
                    MessageBox.Show(n.ToString());
                    GoodsPic.Source = StoreGoodss[n].Img;
                    GNumber.Text = StoreGoodss[n].num;
                    GoodsCount.Text = StoreGoodss[n].count.ToString();
                    StorageGoodsCount.Text = StoreGoodss[n].storagecount.ToString();
                    if (bitmap == null)
                    {
                        bitmap = StoreGoodss[n].Img;
                    }
                    CB.Content = "保存";
                }

            }
            else
            {
                MySql my = new MySql();
                SqlConnection conn = my.GetConn();


                my.UpdateGoods(conn, bitmap, GoodsName.Text, GNumber.Text, Convert.ToInt32(GoodsCount.Text), Convert.ToInt32(StorageGoodsCount.Text));

                my.ConnClose(conn);
                this.Close();
            }
        }
    }
}
