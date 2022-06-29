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
    /// StorageWindow.xaml 的交互逻辑
    /// </summary>
    public partial class StorageWindow : Window
    {
        public string get_userID { get => _get_userID; set => _get_userID = value; }//得到用户使用的ID
        public string pass_num;//传递用户的编号
        private string _get_userID;
        public List<StoreGoods> storeGoodss;
        public StorageWindow(String User_ID)
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
            user = my.FindUserMessage(conn1, get_userID);
            userHeadpic.Source = user.Headpic;
            User_Name.Content = user.Name;
            pass_num = user.UserNumber;

            my.ConnClose(conn1);

            storeGoodss = new List<StoreGoods>();
            for (int i = 0; i < storeGoods.Count(); i++)
            {

                StoreGoods store = new StoreGoods();
                store.Name = storeGoods[i].num + "号:" + storeGoods[i].Name;
                store.Img = storeGoods[i].Img;
                store.num = storeGoods[i].num;
                store.count = storeGoods[i].count;
                store.storagecount = storeGoods[i].storagecount;
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
            ReStoreWindow reStoreWindow = new ReStoreWindow(storeGoodss);
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
            List<StoreGoods> storeGoods = new List<StoreGoods>();
            User user = new User();
            MySql my = new MySql();
            SqlConnection conn = my.GetConn();

            storeGoods = my.GetGoods(conn);
            my.ConnClose(conn);

            SqlConnection conn1 = my.GetConn();
            user = my.FindUserMessage(conn1, get_userID);
            userHeadpic.Source = user.Headpic;
            User_Name.Content = user.Name;
            pass_num = user.UserNumber;
            my.ConnClose(conn1);

            storeGoodss = new List<StoreGoods>();
            for (int i = 0; i < storeGoods.Count(); i++)
            {

                StoreGoods store = new StoreGoods();
                store.Name = storeGoods[i].num + "号:" + storeGoods[i].Name;
                store.Img = storeGoods[i].Img;
                store.num = storeGoods[i].num;
                store.count = storeGoods[i].count;
                store.storagecount = storeGoods[i].storagecount;
                storeGoodss.Add(store);

            }

            listbox.ItemsSource = storeGoodss;
        }

        private void Image_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            ContextMenu contextMenu = new ContextMenu();
            MenuItem DateMenu = new MenuItem();
            DateMenu.Header = "详细信息";
            ContextMenu.Items.Add(DateMenu);
            MenuItem DeleMenu = new MenuItem();
            DeleMenu.Header = "删除";
            ContextMenu.Items.Add(DeleMenu);
            ContextMenu.IsOpen = true;
        }
    }
}
