using System;
using Lab6_mpp.model;

namespace ServerTemplate
{
    public interface Request 
    {
        
    }
    [Serializable]
    public class LoginRequest : Request
    {
        private string email;
        private string password;

        public LoginRequest(string email,string password)
        {
            this.email = email;
            this.password = password;
        }

        public virtual string Email 
        {
            get
            {
                return email;
            }
        }
        public virtual string Password
        {
            get
            {
                return password;
            }
            
        }
    }
    [Serializable]
    public class LogoutRequest : Request
    {
        public LogoutRequest()
        {
            
        }
    }

    [Serializable]
    public class AddDonationRequest : Request
    {
        private Donation donation;

        public AddDonationRequest(Donation don)
        {
            this.donation = don;
        }
        public virtual Donation Donation
        {
            get
            {
                return donation;
            } 
        }
    }
    [Serializable]
    public class GetCasesRequest : Request
    {
        public GetCasesRequest()
        {
            
        }
    }

    [Serializable]
    public class GetDonationsRequest : Request
    {
        private string name;

        public GetDonationsRequest(string name)
        {
            this.name = name;
        }

        public virtual string Name
        {
            get
            {
                return name;
            }
        }
    }
    
}