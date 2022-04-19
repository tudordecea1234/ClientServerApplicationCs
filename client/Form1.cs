using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using client;
using services;


namespace Lab6_mpp
{
    public partial class Form1 : Form
    {
        private ITeledonService service;
        private TeledonClientCtrl client;
        public Form1(ITeledonService serv,TeledonClientCtrl client)
        {
            InitializeComponent();
            service = serv;
            StartPosition = FormStartPosition.CenterScreen;
            this.client = client;

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            
            this.client.login(textBoxEmail.Text, textBoxPassword.Text);
            var mainView = new MainView(service,client);
            mainView.Show();
            Hide();
            
        
                    //MessageBox.Show("Invalid email and/or password!", "Error");
            
        }


        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {/*
            var ne = new NewAccountView(service);
            ne.Show();
            Hide();*/
        }
    }
}