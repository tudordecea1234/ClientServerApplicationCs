using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Sockets;
using System.Threading;
using ServerTemplate;
using System.Threading;
using Lab6_mpp.repository;
using services;

namespace server
{
    public class StartServer
    {
       
        static void Main(string[] args)
        {
            
            // IUserRepository userRepo = new UserRepositoryMock();
            //  IUserRepository userRepo=new UserRepositoryDb();
            // IMessageRepository messageRepository=new MessageRepositoryDb();
            Console.WriteLine("Configuration Settings for tasksDB {0}", GetConnectionStringByName("teledonDB"));
            IDictionary<String, string> props = new SortedList<String, String>();
            props.Add("ConnectionString", GetConnectionStringByName("teledonDB"));
            DonationDbRepository donationDbRepository = new DonationDbRepository(props);
            CharityCaseDbRepository caseRepo = new CharityCaseDbRepository(props);
            VolunteerDbRepository volunteerRepo = new VolunteerDbRepository(props);
            ITeledonService serviceImpl = new TeledonServicesImplementation(donationDbRepository,volunteerRepo,caseRepo);

            // IChatServer serviceImpl = new ChatServerImpl();
            SerialChatServer server = new SerialChatServer("127.0.0.1", 55556, serviceImpl);
            server.Start();
            Console.WriteLine("Server started ...");
            //Console.WriteLine("Press <enter> to exit...");
            Console.ReadLine();
            
            
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

    public class SerialChatServer: ConcurrentServer 
    {
        private ITeledonService server;
        private TeledonClientWorker worker;
        public SerialChatServer(string host, int port, ITeledonService server) : base(host, port)
        {
            this.server = server;
            Console.WriteLine("SerialChatServer...");
        }
        protected override Thread createWorker(TcpClient client)
        {
            worker = new TeledonClientWorker(server, client);
            return new Thread(new ThreadStart(worker.run));
        }
    }

    }
