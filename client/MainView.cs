using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using client;
using Lab6_mpp.model;
using services;

namespace Lab6_mpp
{
    public partial class MainView : Form
    {
        private ITeledonService service;
        private long id;
        private TeledonClientCtrl client;
        private static bool update = true;

        public MainView(ITeledonService service,TeledonClientCtrl client)
        {
            this.client = client;
            InitializeComponent();
            CenterToScreen();
            this.service = service;
            
            
            this.client.updateEvent += ClientOnupdateEvent;
            
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

        private void ClientOnupdateEvent(object sender, TeledonUserEventArgs e)
        {
            if (update)
            {
                update = false;
                Task.Run(() =>
                {
                    // Thread.Sleep(5000);
                    dataGridViewCases.Rows.Clear(); 
                    loadCases();
                    update = true;
                });
                
            }
        }

        public void loadCases()
        {
            foreach (var case1 in service.getAllCases())
            {
                var tempRow = new DataGridViewRow();

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
            var row = dataGridViewDonations.Rows[dataGridViewDonations.CurrentRow.Index] as DataGridViewRow;
            textBoxID.Text = row.Cells["Id"].Value.ToString();
            textBoxFirstName.Text = (string) row.Cells["Donor first name"].Value;
            textBoxLastName.Text = (string) row.Cells["Donor last name"].Value;
            textBoxAddress.Text = (string) row.Cells["Address"].Value;
            textBoxPhone.Text = (string) row.Cells["Phone number"].Value;
            loadCases();
        }

        private void dataGridViewCases_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewDonations.Rows.Clear();
            var row = dataGridViewCases.Rows[dataGridViewCases.CurrentRow.Index] as DataGridViewRow;
            var id = (long) row.Cells["Id"].Value;
            this.id = id;
            ICollection<Donation> donations = service.getAllDonations(searchBox.Text);
            foreach (var don in donations)
            {
                dataGridViewDonations.ClearSelection();
                var tempRow = new DataGridViewRow();

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
            var row = dataGridViewCases.Rows[dataGridViewCases.CurrentRow.Index] as DataGridViewRow;
            var id = (long) row.Cells["Id"].Value;
            ICollection<Donation> donations = service.getAllDonations(searchBox.Text);
            foreach (var don in donations)
            {
                dataGridViewDonations.ClearSelection();
                var tempRow = new DataGridViewRow();

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
            throw new NotImplementedException();
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
                client.donationReceived(new Donation(id, textBoxFirstName.Text, textBoxLastName.Text,
                    textBoxAddress.Text,
                    textBoxPhone.Text, Convert.ToSingle(textBoxAmount.Text)));
                var row = dataGridViewCases.Rows[dataGridViewCases.CurrentRow.Index];
                row.Cells["Total Amount"].Value =
                    float.Parse(textBoxAmount.Text) + (float) row.Cells["Total Amount"].Value;
                
                clear();
                /*if (result)
                {
                    MessageBox.Show("Donation added successfully!");
                }
                else
                {
                    MessageBox.Show("There was a problem adding the donation!");
                }*/
            }
        }

        private void casesUpdate(object sender, TeledonUserEventArgs e)
        {
            if (e.UserEventType== TeledonUserEvent.UpdateCases)
            {
                loadCases();
            }
        }
        private void logoutButton_Click(object sender, EventArgs e)
        {
            client.logout();
            var Form1 = new Form1(service,client);
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