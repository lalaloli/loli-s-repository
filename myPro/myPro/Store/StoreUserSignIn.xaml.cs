using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// StoreUserSignIn.xaml 的交互逻辑
    /// </summary>
    public partial class StoreUserSignIn : Window
    {
        public StoreUserSignIn()
        {
            InitializeComponent();
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            MySql my = new MySql();
            User user = new User();
            SqlConnection conn = my.GetConn();
            String Id = ID.Text;
            user = my.FindUser(conn, Id);
            if ("货架管理员" != user.UserJob)
            {
                MessageBox.Show("权限不足！");
            }
            else
            {
                if (user.PassWord == PassWord.Password)
                {
                    StoreHouseWindow storeHouseWindow = new StoreHouseWindow(Id);
                    storeHouseWindow.get_userID = Id;
                    MessageBox.Show(storeHouseWindow.get_userID + "!");
                    storeHouseWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("用户名或密码错误！");


                }
            }

            my.ConnClose(conn);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SignUpWindow signUpWindow = new SignUpWindow();
            signUpWindow.Show();
        }
    }
}
