using System.ComponentModel;

namespace Lab6_mpp
{
    partial class MainView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewCases = new System.Windows.Forms.DataGridView();
            this.dataGridViewDonations = new System.Windows.Forms.DataGridView();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.textBoxFirstName = new System.Windows.Forms.TextBox();
            this.textBoxLastName = new System.Windows.Forms.TextBox();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.textBoxPhone = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxAmount = new System.Windows.Forms.TextBox();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.Button();
            this.logoutButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridViewCases)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridViewDonations)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewCases
            // 
            this.dataGridViewCases.AllowUserToAddRows = false;
            this.dataGridViewCases.AllowUserToDeleteRows = false;
            this.dataGridViewCases.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCases.Location = new System.Drawing.Point(12, 81);
            this.dataGridViewCases.Name = "dataGridViewCases";
            this.dataGridViewCases.ReadOnly = true;
            this.dataGridViewCases.RowTemplate.Height = 28;
            this.dataGridViewCases.Size = new System.Drawing.Size(531, 338);
            this.dataGridViewCases.TabIndex = 0;
            this.dataGridViewCases.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCases_CellClick);
            this.dataGridViewCases.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCases_CellContentClick);
            // 
            // dataGridViewDonations
            // 
            this.dataGridViewDonations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDonations.Location = new System.Drawing.Point(596, 83);
            this.dataGridViewDonations.Name = "dataGridViewDonations";
            this.dataGridViewDonations.RowTemplate.Height = 28;
            this.dataGridViewDonations.Size = new System.Drawing.Size(901, 336);
            this.dataGridViewDonations.TabIndex = 1;
            this.dataGridViewDonations.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDonations_CellClick);
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(790, 454);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(360, 26);
            this.textBoxID.TabIndex = 2;
            // 
            // textBoxFirstName
            // 
            this.textBoxFirstName.Location = new System.Drawing.Point(790, 501);
            this.textBoxFirstName.Name = "textBoxFirstName";
            this.textBoxFirstName.Size = new System.Drawing.Size(358, 26);
            this.textBoxFirstName.TabIndex = 3;
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.Location = new System.Drawing.Point(789, 547);
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(361, 26);
            this.textBoxLastName.TabIndex = 4;
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Location = new System.Drawing.Point(789, 592);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(361, 26);
            this.textBoxAddress.TabIndex = 5;
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.Location = new System.Drawing.Point(790, 633);
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(360, 26);
            this.textBoxPhone.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(462, 462);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "ID";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(463, 506);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(238, 21);
            this.label2.TabIndex = 8;
            this.label2.Text = "First Name";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(462, 550);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(253, 26);
            this.label3.TabIndex = 9;
            this.label3.Text = "Last Name";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(460, 596);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(254, 22);
            this.label4.TabIndex = 10;
            this.label4.Text = "Address";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(460, 633);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(254, 30);
            this.label5.TabIndex = 11;
            this.label5.Text = "Phone number";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(333, 713);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(239, 48);
            this.button1.TabIndex = 12;
            this.button1.Text = "Add donation";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label6.Location = new System.Drawing.Point(426, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(376, 65);
            this.label6.TabIndex = 13;
            this.label6.Text = "Add a donation";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(465, 674);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(272, 30);
            this.label7.TabIndex = 14;
            this.label7.Text = "Amount";
            // 
            // textBoxAmount
            // 
            this.textBoxAmount.Location = new System.Drawing.Point(790, 674);
            this.textBoxAmount.Name = "textBoxAmount";
            this.textBoxAmount.Size = new System.Drawing.Size(360, 26);
            this.textBoxAmount.TabIndex = 15;
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(37, 566);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(322, 26);
            this.searchBox.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(37, 526);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(321, 24);
            this.label8.TabIndex = 17;
            this.label8.Text = "Search donor by name";
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(107, 614);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(169, 44);
            this.searchButton.TabIndex = 18;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // logoutButton
            // 
            this.logoutButton.Location = new System.Drawing.Point(1025, 713);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(228, 48);
            this.logoutButton.TabIndex = 19;
            this.logoutButton.Text = "Logout";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1523, 784);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.textBoxAmount);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxPhone);
            this.Controls.Add(this.textBoxAddress);
            this.Controls.Add(this.textBoxLastName);
            this.Controls.Add(this.textBoxFirstName);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.dataGridViewDonations);
            this.Controls.Add(this.dataGridViewCases);
            this.Name = "MainView";
            this.Text = "MainView";
            ((System.ComponentModel.ISupportInitialize) (this.dataGridViewCases)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridViewDonations)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button logoutButton;

        private System.Windows.Forms.Button searchButton;

        private System.Windows.Forms.Label label8;

        private System.Windows.Forms.TextBox searchBox;

        private System.Windows.Forms.DataGridView dataGridViewDonations;

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxAmount;
        private System.Windows.Forms.DataGridView dataGridViewCases;

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;

        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.TextBox textBoxFirstName;
        private System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.TextBox textBoxPhone;

        //private System.Windows.Forms.DataGridView dataGridView2;

        //private System.Windows.Forms.DataGridView dataGridView1;

        #endregion
    }
}