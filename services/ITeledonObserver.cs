using System.Collections.Generic;
using Lab6_mpp.model;

namespace services
{
    public interface ITeledonObserver
    {
        void donationReceived(Donation donation);
        void casesAmountUpdate(ICollection<CharityCase> case1);
        void donationsUpdate(Donation[] donations);
    }
}