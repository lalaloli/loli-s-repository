
using myPro.Net;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace myPro.view
{
    internal class MainViewModel
    {
        public ObservableCollection<CUser> Users { get; set; }

        public ObservableCollection<string> Messages { get; set; }
        public RelayCommand ConnectToServerCommand { get; set; }
        public RelayCommand SendMessageCommand { get; set; }
        public string Username { get; set; }
        public string Message { get; set; }

        private Server server;
        public MainViewModel()
        {
            Users = new ObservableCollection<CUser>();
            Messages = new ObservableCollection<string>();
            server = new Server();
            server.connetcedEvent += UserConnected;
            server.messageReceivedEvent += MessageReceive;
            server.DisconnectedEvent += RemoveUser;
            ConnectToServerCommand = new RelayCommand(o => server.ConnectToServer(Username), o => !string.IsNullOrEmpty(Username));
            SendMessageCommand = new RelayCommand(o => server.SendMessageServer(Message), o => !string.IsNullOrEmpty(Message));
        }

        private void RemoveUser()
        {
            var uid = server.reader.ReadMeaasge();
            var user = Users.Where(x => x.UID == uid).FirstOrDefault();
            Application.Current.Dispatcher.Invoke(() => Users.Remove(user));
        }
        private void MessageReceive()
        {
            var msg = server.reader.ReadMeaasge();
            Application.Current.Dispatcher.Invoke(() => Messages.Add(msg));
        }

        private void UserConnected()
        {
            var user = new CUser
            {
                UserName = server.reader.ReadMeaasge(),
                UID = server.reader.ReadMeaasge(),
            };
            if (!Users.Any(x => x.UID == user.UID))
            {
                Application.Current.Dispatcher.Invoke(() => Users.Add(user));
            }
        }
    }
}
