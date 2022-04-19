/*using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Lab6_mpp.model;
using Lab6_mpp.repository;

namespace Lab6_mpp.service
{
    public class Service
    {
        private VolunteerDbRepository volRepo;
        private DonationDbRepository donRepo;
        private CharityCaseDbRepository caseRepo;

        public Service(VolunteerDbRepository vol, DonationDbRepository don, CharityCaseDbRepository case1)
        {
            this.caseRepo = case1;
            this.donRepo = don;
            this.volRepo = vol;
        }

        public Volunteer loginUser(String email, String password)
        {
            Volunteer user = volRepo.findByEmail(email);
            if (user == null)
                return null;
            if (password.Equals(user.Password))
                return user;
            return null;
        }

        public ICollection<CharityCase> getAllCases()
        {
            return caseRepo.getAll();
        }

        public ICollection<Donation> getAllDonations()
        {
            return donRepo.getAll();
        }

        public ICollection<Donation> getAllDonations(String searchName)
        {
            String name = searchName.Trim().Replace("[ ]+", " ").ToLower();
            List<Donation> donation = donRepo.findAll().Where(user =>
            {
                String lastNameFirstName = (user.DonorLastName + " " + user.DonorFirstame).ToLower();
                String firstNameLastName = (user.DonorFirstame + " " + user.DonorLastName).ToLower();
                return (lastNameFirstName.StartsWith(name)
                        || firstNameLastName.StartsWith(name));
            }).ToList();
            return donation;
        }

        public Boolean addVolunteer(String email, String firstName, String lastName, String password)
        {
            Volunteer volunteer = new Volunteer(firstName, lastName, email, password);
            //volunteerValidator.validate(volunteer);
            volRepo.Add(volunteer);
            return true;
        }

        public Boolean addDonation(long idCase, String firstName, String lastName, String address, String phone,
            float amount)
        {
            Donation don = new Donation(idCase, firstName, lastName, address, phone, amount);
            //donationValidator.validate(don);
            CharityCase case1 = caseRepo.findOne(idCase);
            float totalAmount = case1.TotalAmount;
            case1.TotalAmount = (totalAmount + amount);
            donRepo.Add(don);
            caseRepo.Update(case1, case1.ID);
            return true;
        }

        public void addCharityCase(String name, float totalAmount)
        {
            CharityCase case1 = new CharityCase(name, totalAmount);
            //charityCaseValidator.validate(case1);
            caseRepo.Add(case1);
        }
    }
}*/