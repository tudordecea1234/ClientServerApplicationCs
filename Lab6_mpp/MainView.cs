using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;
using Lab6_mpp.model;
using Lab6_mpp.service;

namespace Lab6_mpp
{
    public partial class MainView : Form
    {
        private Service service;
        private long id;
        public MainView(Service service)
        {
            InitializeComponent();
            this.CenterToScreen();
            this.service = service;
            dataGridViewCases.AutoGenerateColumns = false;
            dataGridViewCases.ColumnCount = 3;
            dataGridViewCases.Columns[0].Name = "Id";
            dataGridViewCases.Columns[1].Name = "Name";
            dataGridViewCases.Columns[2].Name = "Total Amount";

            dataGridViewDonations.AutoGenerateColumns = false;
            dataGridViewDonations.ColumnCount = 7;
            dataGridViewDonations.Columns[0].Name = "Id";
            dataGridViewDonations.Columns[1].Name = "Id Case";
            dataGridViewDonations.Columns[2].Name = "Donor first name";
            dataGridViewDonations.Columns[3].Name = "Donor last name";
            dataGridViewDonations.Columns[4].Name = "Address";
            dataGridViewDonations.Columns[5].Name = "Phone number";
            dataGridViewDonations.Columns[6].Name = "Amount";
            
            loadCases();
        }

        public void loadCases()
        {
            foreach (CharityCase case1 in service.getAllCases())
            {
                DataGridViewRow tempRow = new DataGridViewRow();
                    
                DataGridViewCell cellID = new DataGridViewTextBoxCell();
                cellID.Value = case1.ID;
                tempRow.Cells.Add(cellID);
                
                DataGridViewCell cellName = new DataGridViewTextBoxCell();
                cellName.Value = case1.CaseName;
                tempRow.Cells.Add(cellName);

                DataGridViewCell cellTotalAmount = new DataGridViewTextBoxCell();
                cellTotalAmount.Value = case1.TotalAmount;
                tempRow.Cells.Add(cellTotalAmount);

                tempRow.Tag = case1.ID;
                dataGridViewCases.Rows.Add(tempRow);
            }
        }
        private void dataGridViewCases_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridViewDonations_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridViewDonations.Rows[dataGridViewDonations.CurrentRow.Index] as DataGridViewRow;
            textBoxID.Text =  row.Cells["Id"].Value.ToString();
            textBoxFirstName.Text = (string)row.Cells["Donor first name"].Value;
            textBoxLastName.Text = (string)row.Cells["Donor last name"].Value;
            textBoxAddress.Text = (string)row.Cells["Address"].Value;
            textBoxPhone.Text = (string)row.Cells["Phone number"].Value;
            loadCases();
            
        }

        private void dataGridViewCases_CellClick(object sender, DataGridViewCellEventArgs e)
        {   
            dataGridViewDonations.Rows.Clear();
            DataGridViewRow row = dataGridViewCases.Rows[dataGridViewCases.CurrentRow.Index] as DataGridViewRow; 
            long id = (long)row.Cells["Id"].Value;
            this.id = id;
            ICollection<Donation> donations = service.getAllDonations(searchBox.Text);
            foreach (Donation don in donations)
            {   dataGridViewDonations.ClearSelection();
                DataGridViewRow tempRow = new DataGridViewRow();
                
                DataGridViewCell cellId = new DataGridViewTextBoxCell();
                cellId.Value = don.ID;
                tempRow.Cells.Add(cellId);
                
                DataGridViewCell cellIdCase = new DataGridViewTextBoxCell();
                cellIdCase.Value = don.IDCase;
                tempRow.Cells.Add(cellIdCase);
                
                DataGridViewCell cellFirst = new DataGridViewTextBoxCell();
                cellFirst.Value = don.DonorFirstame;
                tempRow.Cells.Add(cellFirst);
                
                DataGridViewCell cellLast = new DataGridViewTextBoxCell();
                cellLast.Value = don.DonorLastName;
                tempRow.Cells.Add(cellLast);

                DataGridViewCell cellAddress = new DataGridViewTextBoxCell();
                cellAddress.Value = don.DonorAddress;
                tempRow.Cells.Add(cellAddress);
                
                DataGridViewCell cellPhone = new DataGridViewTextBoxCell();
                cellPhone.Value = don.PhoneNumber;
                tempRow.Cells.Add(cellPhone);
                
                DataGridViewCell cellAmount = new DataGridViewTextBoxCell();
                cellAmount.Value = don.AmountDonated;
                tempRow.Cells.Add(cellAmount);

                tempRow.Tag = don.ID;
                dataGridViewDonations.Rows.Add(tempRow); 
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            dataGridViewDonations.Rows.Clear();
            DataGridViewRow row = dataGridViewCases.Rows[dataGridViewCases.CurrentRow.Index] as DataGridViewRow; 
            long id = (long)row.Cells["Id"].Value;
            ICollection<Donation> donations = service.getAllDonations(searchBox.Text);
            foreach (Donation don in donations)
            {   dataGridViewDonations.ClearSelection();
                DataGridViewRow tempRow = new DataGridViewRow();
                    
                DataGridViewCell cellId = new DataGridViewTextBoxCell();
                cellId.Value = don.ID;
                tempRow.Cells.Add(cellId);
                
                DataGridViewCell cellIdCase = new DataGridViewTextBoxCell();
                cellIdCase.Value = don.IDCase;
                tempRow.Cells.Add(cellIdCase);
                
                DataGridViewCell cellFirst = new DataGridViewTextBoxCell();
                cellFirst.Value = don.DonorFirstame;
                tempRow.Cells.Add(cellFirst);
                
                DataGridViewCell cellLast = new DataGridViewTextBoxCell();
                cellLast.Value = don.DonorLastName;
                tempRow.Cells.Add(cellLast);

                DataGridViewCell cellAddress = new DataGridViewTextBoxCell();
                cellAddress.Value = don.DonorAddress;
                tempRow.Cells.Add(cellAddress);
                
                DataGridViewCell cellPhone = new DataGridViewTextBoxCell();
                cellPhone.Value = don.PhoneNumber;
                tempRow.Cells.Add(cellPhone);
                
                DataGridViewCell cellAmount = new DataGridViewTextBoxCell();
                cellAmount.Value = don.AmountDonated;
                tempRow.Cells.Add(cellAmount);
                tempRow.Tag = don.ID;
                dataGridViewDonations.Rows.Add(tempRow); 
            } 
        }

        private void label1_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxFirstName.Text.Length == 0 || textBoxLastName.Text.Length == 0 ||
                textBoxAddress.Text.Length == 0 ||
                textBoxPhone.Text.Length == 0 || textBoxAmount.Text.Length == 0)
            {
                MessageBox.Show("You must complete all fields!");
            }
            else
            {
                Boolean result = service.addDonation(id, textBoxFirstName.Text, textBoxLastName.Text,
                    textBoxAddress.Text,
                    textBoxPhone.Text, Convert.ToSingle(textBoxAmount.Text));
                DataGridViewRow row = dataGridViewCases.Rows[dataGridViewCases.CurrentRow.Index];
                row.Cells["Total Amount"].Value=float.Parse(textBoxAmount.Text)+(float)row.Cells["Total Amount"].Value;
                clear();
                if (result)
                {
                    MessageBox.Show("Donation added successfully!");
                }
                else
                {
                    MessageBox.Show("There was a problem adding the donation!");
                }
            }
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            var Form1= new Form1(service);
            Hide();
            Form1.ShowDialog();
            Close(); 
        }

        private void clear()
        {
            textBoxAddress.Clear();
            textBoxAmount.Clear();
            textBoxPhone.Clear();
            textBoxFirstName.Clear();
            textBoxLastName.Clear();
        }
    }
}