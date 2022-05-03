using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_mpp.model
{
    [Serializable]
    public class Volunteer : Identifiable<long>
    {
        private string firstName;
        private string lastName;
        private string email;
        private string password;

        public Volunteer(string firstName, string lastName, string email, string password)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.password = password;
        }

        public Volunteer()
        {
        }

        public long ID { get; set; }

        public String FirstName
        {
            get => firstName;
            set => firstName = value;
        }

        public string LastName
        {
            get => lastName;
            set => lastName = value;
        }

        public String Email
        {
            get => email;
            set => email = value;
        }

        public String Password
        {
            get => password;
            set => password = value;
        }

        public override string ToString()
        {
            return "Volunteer id: " + ID + ", " + firstName + " " + lastName + ", with email: " + email;
        }
    }
}