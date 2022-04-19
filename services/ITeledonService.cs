using System.Collections.Generic;
using Lab6_mpp.model;

namespace services
{
    public interface ITeledonService
    {
        void loginUser(string email, string password, ITeledonObserver client);
        Donation[] getAllDonations(string searchName);
        
        void addDonation(Donation donation,ITeledonObserver client);
        ICollection<CharityCase> getAllCases();
        void logout();
    }
}