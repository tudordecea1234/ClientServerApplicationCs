using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;
using Lab6_mpp.model;
using Lab6_mpp.repository;
using Lab6_mpp.service;
using log4net.Config;

namespace Lab6_mpp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {   
            XmlConfigurator.Configure(new System.IO.FileInfo("log4j.xml"));
            Console.WriteLine("Configuration Settings for tasksDB {0}", GetConnectionStringByName("teledonDB"));
            IDictionary<String, string> props = new SortedList<String, String>();
            props.Add("ConnectionString", GetConnectionStringByName("teledonDB"));

            VolunteerDbRepository volunteerDbRepository = new VolunteerDbRepository(props);
            DonationDbRepository donationDbRepository = new DonationDbRepository(props);
                Volunteer vol = new Volunteer("Ana", "Maria", "anamaria@yahoo.com", "mor");
            Volunteer vol2 = new Volunteer("Ovidiu", "Carla", "looooooool@yahoo.com", "samsung");
            volunteerDbRepository.Add(vol);
            foreach(Volunteer v in volunteerDbRepository.findAll())
            {
                Console.WriteLine(v.ToString());
            }
            volunteerDbRepository.Update(vol2,33);
            volunteerDbRepository.Delete(31);
            Console.WriteLine("Dupa delete si update");
            foreach(Volunteer v in volunteerDbRepository.findAll())
            {
                Console.WriteLine(v.ToString());
            }
            Console.WriteLine(volunteerDbRepository.findOne(33));

            CharityCaseDbRepository caseDbRepository = new CharityCaseDbRepository(props);
            caseDbRepository.Add(new CharityCase("Mircea",1400));
            foreach (CharityCase c in caseDbRepository.findAll())
            {
                Console.WriteLine(c.ToString());
            }
            caseDbRepository.Delete(6);
            caseDbRepository.Update(new CharityCase("Cristina Mirela",700),7);
            foreach (CharityCase c in caseDbRepository.findAll())
            {
                Console.WriteLine(c.ToString());
            }
            Console.WriteLine(caseDbRepository.findOne(7));


            Donation don1 = new Donation(1, "Miron", "Costin", "Rucar",  "5553943", 1300);
            donationDbRepository.Add(don1);
            foreach (Donation d in donationDbRepository.findAll())
            {
                Console.WriteLine(d.ToString());
            }
            Donation don2 = new Donation(1, "Miriam", "Lola", "AAAAA",  "231253943", 1200);
            donationDbRepository.Update(don2,20);
            donationDbRepository.Delete(19);
            foreach (Donation d in donationDbRepository.findAll())
            {
                Console.WriteLine(d.ToString());
            }
            Console.WriteLine();
            Console.WriteLine(donationDbRepository.findOne(20));
            Service service = new Service(volunteerDbRepository, donationDbRepository, caseDbRepository); 
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(service));
        }
        static string GetConnectionStringByName(string name)
        {
            // Assume failure.
            string returnValue = null;

            // Look for the name in the connectionStrings section.
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[name];

            // If found, return the connection string.
            if (settings != null)
                returnValue = settings.ConnectionString;

            return returnValue;
        }
    }
}