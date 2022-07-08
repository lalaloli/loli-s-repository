using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyPro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // SignUpWindow signUpWindow = new SignUpWindow();
            //signUpWindow.Show();
            ChangePassWord changePassWord = new ChangePassWord();
            changePassWord.Show();

        }

        private void Label2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MySql mySql = new MySql();
            mySql.AddDateBasse();
           

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StoreUserSignIn storeUserSign = new StoreUserSignIn();
            storeUserSign.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ManagerSignIn managerSignIn = new ManagerSignIn();
            managerSignIn.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            StorageUserSignIn storageUSerSignIn = new StorageUserSignIn();
            storageUSerSignIn.Show();
            this.Close();
          
        }
    }
}
