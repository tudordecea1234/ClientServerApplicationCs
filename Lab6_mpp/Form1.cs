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
using Lab6_mpp.model;
using Lab6_mpp.service;

namespace Lab6_mpp
{
    public partial class Form1 : Form
    {
        private Service service;
        public Form1(Service serv)
        {
            InitializeComponent();
            this.service = serv;
            this.StartPosition = FormStartPosition.CenterScreen;

        }
        
        private void loginButton_Click(object sender, EventArgs e)
        {
            if((service.loginUser(textBoxEmail.Text, textBoxPassword.Text)!=null))
            {
                MainView mainView = new MainView(service);
                            mainView.Show();
                            this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid email and/or password!", "Error");
            }
            
        }

        

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NewAccountView ne = new NewAccountView(service);
            ne.Show();
            this.Hide();
            
        }
    }
}