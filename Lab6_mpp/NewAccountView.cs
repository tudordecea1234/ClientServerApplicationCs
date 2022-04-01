using System;
using System.Windows.Forms;
using Lab6_mpp.service;

namespace Lab6_mpp
{
    public partial class NewAccountView : Form
    {
        private Service service;
        public NewAccountView(Service service)
        {
            InitializeComponent();
            this.service = service;
            this.CenterToScreen();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
          
            if ( service.addVolunteer(textBoxEmail.Text, textBoxFirstName.Text, textBoxLastName.Text,
                                maskedTextBox.Text)&&textBoxEmail.TextLength>0&&textBoxFirstName.TextLength>0
                                        &&textBoxLastName.TextLength>0&&maskedTextBox.TextLength>0)
            {
                MainView mainView = new MainView(service);
                mainView.Show();
                this.Hide();
                
            }
            else
            {
                MessageBox.Show("Invalid information!");
            }
            
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            var Form1= new Form1(service);
            Hide();
            Form1.ShowDialog();
            Close(); 
        }
    }
}