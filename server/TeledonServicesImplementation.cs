using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab6_mpp.model;
using Lab6_mpp.repository;
using services;

namespace server
{
    public class TeledonServicesImplementation:ITeledonService
    {
        public TeledonServicesImplementation(DonationDbRepository donationDbRepository, VolunteerDbRepository volunteerRepo, CharityCaseDbRepository caseRepo)
        {
            DonationDbRepository = donationDbRepository;
            this.volunteerRepo = volunteerRepo;
            this.caseRepo = caseRepo;
            loggedClients=new Dictionary<String, ITeledonObserver>();
        }

        private DonationDbRepository DonationDbRepository;
        private VolunteerDbRepository volunteerRepo;
        private CharityCaseDbRepository caseRepo;
        private readonly IDictionary <String, ITeledonObserver> loggedClients;
        public void loginUser(string email, string password, ITeledonObserver client)
        {   
            Volunteer vol=volunteerRepo.findByEmail(email);
            if(vol==null || vol.Password!= password)
            {
                throw new TeledonException("Authentification failed!");
            }
            else
            {
                loggedClients[vol.Email]= client;
            }
        }

        public Donation[] getAllDonations(string searchName)
        {
            Console.WriteLine("Getting donations for name: " + searchName);
            String name = searchName.Trim().Replace("[ ]+", " ").ToLower();
            List<Donation> donation = DonationDbRepository.findAll().Where(user =>
            {
                String lastNameFirstName = (user.DonorLastName + " " + user.DonorFirstame).ToLower();
                String firstNameLastName = (user.DonorFirstame + " " + user.DonorLastName).ToLower();
                return (lastNameFirstName.StartsWith(name)
                        || firstNameLastName.StartsWith(name));
            }).ToList();
            return donation.ToArray();
        }

        

        public void addDonation(Donation donation,ITeledonObserver client)
        { DonationDbRepository.Add(donation);
            CharityCase case1=caseRepo.findOne(donation.IDCase);
            case1.TotalAmount=(donation.AmountDonated+case1.TotalAmount);
            caseRepo.Update(case1,case1.ID);
            IEnumerable donations=DonationDbRepository.findAll();
            foreach (var vol in loggedClients)
            {
                try
                {
                    Task.Run(() => vol.Value.casesAmountUpdate((ICollection<CharityCase>) caseRepo.findAll()));

                }
                catch (TeledonException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

        }

        public ICollection<CharityCase> getAllCases()
        {
            return caseRepo.getAll();
        }

        public void logout()
        {
            
        }
    }
}