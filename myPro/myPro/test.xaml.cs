using System;
using System.Collections.Generic;
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
    /// test.xaml 的交互逻辑
    /// </summary>
    /// 

    public class Users
    {
        
        public string Name { get; set; }
        public BitmapImage Img { get; set ; }
    }



    public partial class test : Window
    {
        public test()
        {
            InitializeComponent();
            List<Users> users = new List<Users>();
             String a = "C:\\Users\\machenike\\source\\repos\\myPro\\myPro\\testopject\\1 (16).jpg";
            var ii = System.Drawing.Image.FromFile(a);
            Bitmap map = new Bitmap(ii);
            BitmapImage bitmap = BitmapToBitmapImage(map);
           

            //grid.DataContext = users;



            for (int i = 1; i < 5; i++)
            {
                Users user = new Users();
                user.Name= i.ToString();
                user.Img = bitmap;
                users.Add(user);
                
            }
           
            listbox.ItemsSource = users;
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
    }
}
