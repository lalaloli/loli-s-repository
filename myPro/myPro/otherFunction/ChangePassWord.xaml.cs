using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
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

namespace myPro
{
    /// <summary>
    /// ChangePassWord.xaml 的交互逻辑
    /// </summary>
    public partial class ChangePassWord : Window
    {
        private System.Threading.Timer CountDown = null;

        public ChangePassWord()
        {
            InitializeComponent();
            CountDown = new Timer(CountDown_Tick, this, Timeout.Infinite, Timeout.Infinite);
        }
        public String ranPassword = "";

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

        private void Send_Click(object sender, RoutedEventArgs e)
        {

            User user = new User();
                user.UserMail = Mail.Text;
                Random random = new Random();

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
                    CountDown.Change(0, 1000);
                    SendVerCode.IsEnabled = false;
            }
                catch (Exception t)
                {
                    MessageBox.Show(t.Message);
                }
                finally
                {
                    MessageBox.Show("输入正确的邮箱格式！");
                }
            

        }

        private void ChangePW_Click(object sender, RoutedEventArgs e)
        {
            if(SendPassword.Text == ranPassword)
            {
                MySql my = new MySql();
                SqlConnection conn = my.GetConn();

                my.UpDatePW(conn, Mail.Text, NewPassword.Password);

                my.ConnClose(conn);
                MessageBox.Show("修改完成！");
                this.Close();
            }
            else
            {
                MessageBox.Show("验证码错误！");
            }
        }
    }
}
