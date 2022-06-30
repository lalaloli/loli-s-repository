using ChatClient.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.view
{
    public class MainViewModel
    {
        public RelayCommand ConnectToServerCommand { get; set; }

        private Server server;
        public MainViewModel()
        {
            server = new Server();
            ConnectToServerCommand = new RelayCommand(o => server.ConnectToServer());
        }
    }
}
