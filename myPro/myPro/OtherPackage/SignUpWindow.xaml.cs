using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
//using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
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
    /// SignUpWindow.xaml 的交互逻辑
    /// </summary>
    /// 

    public class User
    {
        String userMail;
        String userNumber;
        String passWord;
        String userJob;
        private string name;
        private BitmapImage headpic;
        String age;
        string jobage;
        string tel;

        public string UserMail { get => userMail; set => userMail = value; }
        public string UserNumber { get => userNumber; set => userNumber = value; }
        public string PassWord { get => passWord; set => passWord = value; }
        public string UserJob { get => userJob; set => userJob = value; }
        public string Name { get => name; set => name = value; }
        public BitmapImage Headpic { get => headpic; set => headpic = value; }
        public string Age { get => age; set => age = value; }
        public string Jobage { get => jobage; set => jobage = value; }
        public string Tel { get => tel; set => tel = value; }

        public User() { }

        public User(String mail, String number, String password, String job)
        {
            this.userMail = mail;
            this.userNumber = number;
            this.passWord = password;
            this.userJob = job;
        }
        public User(String mail, String number, String password, String job, String Name, BitmapImage bitmapImage)
        {
            this.userMail = mail;
            this.userNumber = number;
            this.passWord = password;
            this.userJob = job;
            this.Name = Name;
            this.Headpic = bitmapImage;

        }
    }
    public partial class SignUpWindow : Window
    {
        private System.Threading.Timer CountDown = null;
        public SignUpWindow()
        {
            InitializeComponent();
            CountDown = new Timer(CountDown_Tick, this, Timeout.Infinite, Timeout.Infinite);
        }

        int CountDownNum = 60;
        private void CountDown_Tick(object state)
        {
            //限制60秒内不能重复点击发送验证码
            this.Dispatcher.BeginInvoke(new Action(() =>
            {
                SendVerCode.Content = $"{CountDownNum}秒后重试";
                CountDownNum--;
                if (CountDownNum < 0)
                {
                    CountDown.Change(Timeout.Infinite, Timeout.Infinite);
                    CountDownNum = 60;
                    SendVerCode.Content = "获取验证码";
                    SendVerCode.IsEnabled = true;
                }
            }));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (Usermail.Text == "" || UserPassword.Password == "")
            {
                MessageBox.Show("请输入邮箱或密码！");
            }
            else if (UserPassword.Password != UPassword.Password)
            {
                MessageBox.Show("两次输入的密码不一致！");
            }
            else
            {
                User user = new User(Usermail.Text, Usernumber.Text, UserPassword.Password, Userjob.Text);

                Random random = new Random();
                String ranPassword = "";
                for (int i = 0; i < 4; i++)
                {
                    ranPassword += random.Next(9).ToString();
                }

                SmtpClient client = new SmtpClient();
                MailMessage mailMessage = new MailMessage();

                mailMessage.From = new MailAddress("779429379@qq.com");

                try
                {
                    mailMessage.To.Add(new MailAddress(user.UserMail));
                    mailMessage.Subject = "注册验证码！";

                    mailMessage.Body = "验证码为：" + ranPassword;


                    client.Host = "smtp.qq.com";
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential("779429379@qq.com", "aqtenuawrriibecg");
                    client.Send(mailMessage);
                    MessageBox.Show("发送成功！");
                    SendVerCode.IsEnabled = false;
                    CountDown.Change(0, 1000);
                }
                catch (Exception t)
                {
                    //MessageBox.Show(t.Message);

                }
                finally
                {

                }
            }


        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            if (Testpass.Text == "")
            {
                MessageBox.Show("请进行邮箱验证！");
            }
            else
            {
                MySql my = new MySql();
                SqlConnection conn = my.GetConn();

                if (my.FindUserTrueOrNot(conn, Usermail.Text))
                {
                    MessageBox.Show("该邮箱已注册！");
                }
                else
                {
                    conn.Close();
                    conn = my.GetConn();
                    User user = new User(Usermail.Text, Usernumber.Text, UserPassword.Password, Userjob.Text, null, null);

                    my.AddUser(conn, null, user.Name, user.UserNumber, user.UserMail, user.PassWord, user.UserJob);
                    my.ConnClose(conn);
                    MessageBox.Show("注册成功！");
                    this.Close();
                }


            }


            // mySql.FindAutoInfo();
        }
    }
}
