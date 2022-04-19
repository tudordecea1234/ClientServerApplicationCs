using System;
using System.Collections.Generic;
using Lab6_mpp.model;
using services;

namespace client
{
    public class TeledonClientCtrl:ITeledonObserver
    {    public event EventHandler<TeledonUserEventArgs> updateEvent; //ctrl calls it when it has received an update
        private readonly ITeledonService server;
        private String currentUser;
        public TeledonClientCtrl(ITeledonService server)
        {
            this.server = server;
            currentUser = null;
        }
        public void login(String userId, String pass)
        {   
            server.loginUser(userId, pass, this);
            Console.WriteLine("Login succeeded ....");
            currentUser = userId;
            Console.WriteLine("Current user {0}", userId);
            
        }
        public void donationReceived(Donation donation)
        {
           server.addDonation(donation,this);
           Console.WriteLine("Adding donation... ");
           TeledonUserEventArgs userArgs = new TeledonUserEventArgs(TeledonUserEvent.UpdateCases,this);
           OnUserEvent(userArgs); 
        }

        public void casesAmountUpdate(ICollection<CharityCase> case1)
        {
            Console.WriteLine("Updating Cases... ");
            TeledonUserEventArgs userArgs = new TeledonUserEventArgs(TeledonUserEvent.UpdateCases,this);
//            updateEvent?.Invoke(null,userArgs);
            updateEvent(this, userArgs);
        }
        public void logout()
        {
            Console.WriteLine("Ctrl logout");
            server.logout();
            currentUser = null;
        }
        public void donationsUpdate(Donation[] donations)
        {
            throw new System.NotImplementedException();
        }
        protected virtual void OnUserEvent(TeledonUserEventArgs e)
        {
            if (updateEvent == null) return;
            updateEvent(this, e);
            Console.WriteLine("Update Event called");
        }
    }
}