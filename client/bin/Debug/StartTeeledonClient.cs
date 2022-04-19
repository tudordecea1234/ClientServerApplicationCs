using System;
using System.Windows.Forms;
using Lab6_mpp;
using Lab6_mpp.model;
using ServerTemplate;
using services;
namespace client
{
    public class StartTeeledonClient
    {
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
           
            //IChatServer server=new ChatServerMock();          
            ITeledonService server = new TeledonServerProxy("127.0.0.1", 55556);
            TeledonClientCtrl ctrl = new TeledonClientCtrl(server);
            Form1 win=new Form1(server,ctrl);
            Application.Run(win);
        }
    }
}