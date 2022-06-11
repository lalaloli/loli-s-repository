using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.Remoting.Contexts;
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

public class User
{
    String userMail;
    String userNumber;
    String passWord;
    String userJob;

    public string UserMail { get => userMail; set => userMail = value; }
    public string UserNumber { get => userNumber; set => userNumber = value; }
    public string PassWord { get => passWord; set => passWord = value; }
    public string UserJob { get => userJob; set => userJob = value; }

    public  User() { }

    public User(String mail, String number,String password,String job)
    {
        this.userMail = mail;
        this.userNumber = number;
        this.passWord = password;
        this.userJob = job;
    }
}
namespace myPro
{
    /// <summary>
    /// SignUpWindow.xaml 的交互逻辑
    /// </summary>
    public partial class SignUpWindow : Window
    {
        public SignUpWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            User user = new User(Usermail.Text,Usernumber.Text,UserPassword.Password,Userjob.Text);

            Random random = new Random();
            String ranPassword = "";
            for (int i = 0; i < 4; i++)
            {
               ranPassword += random.Next(9).ToString();
            }

            SmtpClient client = new SmtpClient();
            MailMessage mailMessage = new MailMessage();

            mailMessage.From = new MailAddress("779429379@qq.com");
            mailMessage.To.Add(new MailAddress(user.UserMail));
            mailMessage.Subject = "注册验证码！";

            mailMessage.Body = "验证码为：" + ranPassword;

         
            client.Host = "smtp.qq.com";
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("779429379@qq.com", "aqtenuawrriibecg");
            client.Send(mailMessage);
            MessageBox.Show("发送成功！");
            
        }
    }
}
