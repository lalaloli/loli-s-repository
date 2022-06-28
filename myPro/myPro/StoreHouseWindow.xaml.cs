﻿using System;
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
    /// StoreHouseWindow.xaml 的交互逻辑
    /// </summary>
    /// 

    public class StoreGoods{
        public string Name { get; set; }
        public BitmapImage Img { get; set; }
        public string num { get; set; }
        public string count { get; set; }
    }

    public partial class StoreHouseWindow : Window
    {
        public string get_userID { get => _get_userID; set => _get_userID = value; }//得到用户使用的ID
        public string pass_num;//传递用户的编号
        private string _get_userID;

        public StoreHouseWindow(String User_ID)
        {
            get_userID = User_ID;
            InitializeComponent();
     
            List<StoreGoods> storeGoods = new List<StoreGoods>();
            User user = new User();
            MySql my = new MySql();
            SqlConnection conn = my.GetConn();

            storeGoods = my.GetGoods(conn);
            my.ConnClose(conn);

            SqlConnection conn1 = my.GetConn();
            user = my.FindUserMessage(conn1, User_ID);
            userHeadpic.Source = user.Headpic;
            User_Name.Content = user.Name;
            pass_num = user.UserNumber;
            my.ConnClose(conn1);

            List<StoreGoods> storeGoodss = new List<StoreGoods>();
            for (int i = 0; i < storeGoods.Count(); i++)
            {

                StoreGoods store = new StoreGoods();
                store.Name = storeGoods[i].Name;
                store.Img = storeGoods[i].Img;
                storeGoodss.Add(store);

            }

            listbox.ItemsSource = storeGoodss;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        public BitmapImage BitmapToBitmapImage(Bitmap bitmap)
        {
            Bitmap bitmapSource = new Bitmap(bitmap.Width, bitmap.Height);
            int i, j;
            for (i = 0; i < bitmap.Width; i++)
                for (j = 0; j < bitmap.Height; j++)
                {
                    System.Drawing.Color pixelColor = bitmap.GetPixel(i, j);
                    System.Drawing.Color newColor = System.Drawing.Color.FromArgb(pixelColor.R, pixelColor.G, pixelColor.B);
                    bitmapSource.SetPixel(i, j, newColor);
                }
            MemoryStream ms = new MemoryStream();
            bitmapSource.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = new MemoryStream(ms.ToArray());
            bitmapImage.EndInit();
            return bitmapImage;
        }

        private void ReStore_Click(object sender, RoutedEventArgs e)
        {
            ReStoreWindow reStoreWindow = new ReStoreWindow();
            reStoreWindow.Show();
        }

        private void UserMassge_Click(object sender, RoutedEventArgs e)
        {
            PeopleMessageWindow peopleMessageWindow = new PeopleMessageWindow(pass_num);
           // peopleMessageWindow.get_userNumber = pass_num;
            peopleMessageWindow.Show();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            StoreHouseWindow storeHouseWindow = new StoreHouseWindow(get_userID);
            storeHouseWindow.Show();
            this.Close();
        }
    }
}

