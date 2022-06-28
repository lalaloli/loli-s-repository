using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// StorageUSerSignIn.xaml 的交互逻辑
    /// </summary>
    public partial class StorageUSerSignIn : Window
    {
        public StorageUSerSignIn()
        {
            InitializeComponent();
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            MySql my = new MySql();
            SqlConnection conn = my.GetConn();
            String Id = ID.Text;
            string pw = my.FindUser(conn, Id);
            pw = pw.Split(' ').FirstOrDefault();
            if ( pw == PassWord.Password)
            {
                StoreHouseWindow storeHouseWindow = new StoreHouseWindow(Id);
                storeHouseWindow.get_userID = Id;
                MessageBox.Show(storeHouseWindow.get_userID+"!");
                storeHouseWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("用户名或密码错误！");
               
                
            }
            
            my.ConnClose(conn);
        }
    }
}
