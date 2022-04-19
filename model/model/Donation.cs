using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_mpp.model
{
        [Serializable]
    public class Donation : Identifiable<long>
    {
        private long idCase;
        private string donorFirstName;
        private string donorLastName;
        private string donorAddress;
        private string phoneNumber;
        private float amountDonated;

        public Donation(long idCase, string firstName, string lastName, string address, string number, float sum)
        {
            this.idCase = idCase;
            this.DonorLastName = lastName;
            this.phoneNumber = number;
            this.amountDonated = sum;
            this.donorAddress = address;
            this.donorFirstName = firstName;
        }

        public long IDCase
        {
            get => idCase;
            set => idCase = value;
        }

        public string DonorFirstame
        {
            get => donorFirstName;
            set => donorFirstName = value;
        }

        public string PhoneNumber
        {
            get => phoneNumber;
            set => phoneNumber = value;
        }

        public float AmountDonated
        {
            get => amountDonated;
            set => amountDonated = value;
        }

        public string DonorAddress
        {
            get => donorAddress;
            set => donorAddress = value;
        }

        public long ID { get; set; }

        public string DonorLastName
        {
            get => donorLastName;
            set => donorLastName = value;
        }

        public override string ToString()
        {
            return "Donation id: " + ID + ", idCase: " + idCase + " " + DonorFirstame + " " + donorLastName + ", " +
                   donorAddress + ", " + amountDonated;
        }
    }
}