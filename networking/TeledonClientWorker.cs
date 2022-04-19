using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using Lab6_mpp.model;
using services;

namespace ServerTemplate
{
    public class TeledonClientWorker:ITeledonObserver
    {
        private ITeledonService server;
        private TcpClient connection;

        private NetworkStream stream;
        private IFormatter formatter;
        private volatile bool connected;
        public TeledonClientWorker(ITeledonService server, TcpClient connection)
        {
            this.server = server;
            this.connection = connection;
            try
            {
				
                stream=connection.GetStream();
                formatter = new BinaryFormatter();
                connected=true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
        public virtual void run()
        {
            while(connected)
            {
                try
                {
                    object request = formatter.Deserialize(stream);
                    object response =handleRequest((Request)request);
                    if (response!=null)
                    {
                        sendResponse((Response) response);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
				
                try
                {
                    Thread.Sleep(1000);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }
            try
            {
                stream.Close();
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error "+e);
            }
        }

        public void donationReceived(Donation donation)
        {
            Console.WriteLine("Donation received..."+donation);
            try
            {
                sendResponse(new AddDonationResponse(donation));
            }
            catch (Exception e)
            {
                throw new TeledonException("Sending error: "+e);
            }
        }

        public void casesAmountUpdate(ICollection<CharityCase> case1)
        {
          Console.WriteLine("[CLIENT_WORKER] update cases...");
          try
          {
              sendResponse(new UpdateCasesResponse(case1));
          }
          catch(Exception e)
          {
              throw new TeledonException("SENDING ERROR: " + e);
          }
        }

        public void donationsUpdate(Donation[] donations)
        {
            Console.WriteLine("[CLIENT_WORKER] update donations...");
            try
            {
                sendResponse(new GetDonationsResponse(donations));
            }
            catch(Exception e)
            {
                throw new TeledonException("SENDING ERROR: " + e);
            }

        }

        private Response handleRequest(Request request)
        {
            Response response = null;
            if (request is LoginRequest)
            {
                Console.WriteLine("Login request ...");
                LoginRequest logReq = (LoginRequest) request;
                string email = logReq.Email;
                string pass = logReq.Password;
                try
                {
                    lock (server)
                    {
                        server.loginUser(email, pass, this);
                    }

                    return new OkResponse();
                }
                catch (TeledonException e)
                {
                    connected = false;
                    return new ErrorResponse(e.Message);
                }
            }

            if (request is LogoutRequest)
            {
                Console.WriteLine("Logout request");
                LogoutRequest logReq = (LogoutRequest) request;
                try
                {
                    lock (server)
                    {

                        server.logout();
                    }

                    connected = false;
                    return new OkResponse();

                }
                catch (TeledonException e)
                {
                    return new ErrorResponse(e.Message);
                }


            }

            if (request is GetCasesRequest)
            {
                Console.WriteLine("Getting cases...");
                GetCasesRequest req = (GetCasesRequest) request;
                try
                {
                    ICollection<CharityCase> cases;
                    lock (server)
                    {
                        cases = server.getAllCases();
                    }

                    return new GetCasesResponse(cases);
                }
                catch (TeledonException e)
                {
                    return new ErrorResponse(e.Message);
                }

            }

            if (request is AddDonationRequest)
            {
                Console.WriteLine("Getting donations...");
                AddDonationRequest req = (AddDonationRequest) request;
                Donation don = req.Donation;
                try
                {
                   
                    lock (server)
                    {
                        server.addDonation(don,this);
                    }

                    return new AddDonationResponse(don);
                }
                catch (TeledonException e)
                {
                    return new ErrorResponse(e.Message);
                } 
            }
            {
                Console.WriteLine("Getting donations...");
                GetDonationsRequest req = (GetDonationsRequest) request;
                string name = req.Name;
                try
                {
                    Donation[] cases;
                    lock (server)
                    {
                        cases = server.getAllDonations(name);
                    }

                    return new GetDonationsResponse(cases);
                }
                catch (TeledonException e)
                {
                    return new ErrorResponse(e.Message);
                }
            }
            if (request is GetDonationsRequest)
            {
                Console.WriteLine("Getting donations...");
                GetDonationsRequest req = (GetDonationsRequest) request;
                string name = req.Name;
                try
                {
                    Donation[] cases;
                    lock (server)
                    {
                        cases = server.getAllDonations(name);
                    }

                    return new GetDonationsResponse(cases);
                }
                catch (TeledonException e)
                {
                    return new ErrorResponse(e.Message);
                }
            }

            return response;
        }

        private void sendResponse(Response response)
        {
            Console.WriteLine("sending response "+response);
            lock (stream)
            {
                formatter.Serialize(stream, response);
                stream.Flush();
            }

        }
    }
}