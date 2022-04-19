using System;
using System.Collections.Generic;
using Lab6_mpp.model;

namespace ServerTemplate
{
    public interface Response 
    {
    }

    [Serializable]
    public class OkResponse : Response
    {
		
    }
    [Serializable]
    public class ErrorResponse : Response
    {
        private string message;

        public ErrorResponse(string message)
        {
            this.message = message;
        }

        public virtual string Message
        {
            get
            {
                return message;
            }
        }
    }

    [Serializable]
    public class GetCasesResponse : Response
    {
        private ICollection<CharityCase> cases;

        public GetCasesResponse(ICollection<CharityCase> cases)
        {
            this.cases = cases;
        }

        public virtual ICollection<CharityCase> Cases
        {
            get
            {
                return cases;
            }
        }
    }

    [Serializable]
    public class GetDonationsResponse : Response
    {
        private Donation[] donations;

        public GetDonationsResponse(Donation[] donations)
        {
            this.donations = donations;
        }

        public virtual Donation[] Donations
        {
            get
            {
                return donations;
            }
        }
    }

    [Serializable]
    public class AddDonationResponse : Response
    {
        private Donation donation;

        public AddDonationResponse(Donation donation)
        {
            this.donation = donation;
        }

        public virtual Donation Donation
        {
            get
            {
                return donation;
            }
        }
    }
    public interface UpdateResponse : Response
    {
    }
    
    [Serializable]
    public class UpdateDonationsResponse : UpdateResponse
    {
        private Donation[] donations;

        public UpdateDonationsResponse(Donation[] donations)
        {
            this.donations = donations;
        }

        public virtual Donation[] Donations
        {
            get
            {
                return donations;
            }
        }
    }
    [Serializable]
    public class UpdateCasesResponse : UpdateResponse
    {
        private ICollection<CharityCase> cases;

        public UpdateCasesResponse(ICollection<CharityCase> cases)
        {
            this.cases = cases;
        }

        public virtual ICollection<CharityCase> Cases
        {
            get
            {
                return cases;
            }
        }
    }
}