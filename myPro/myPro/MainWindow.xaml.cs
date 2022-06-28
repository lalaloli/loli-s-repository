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

namespace myPro
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SignUpWindow signUpWindow = new SignUpWindow();
            signUpWindow.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StoreUserSignIn storeUserSign = new StoreUserSignIn();
            storeUserSign.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ManagerSignIn managerSignIn = new ManagerSignIn();
            managerSignIn.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
              StorageUSerSignIn storageUSerSignIn = new StorageUSerSignIn();
              storageUSerSignIn.Show();
            //test test = new test();
            // test.Show();
          // StoreHouseWindow storeHouseWindow = new StoreHouseWindow();
          // storeHouseWindow.Show();
        }
    }
}
