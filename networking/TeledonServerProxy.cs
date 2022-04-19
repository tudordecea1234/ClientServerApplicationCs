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
    public class TeledonServerProxy: ITeledonService
    {   private string host;
        private int port;

        private ITeledonObserver client;

        private NetworkStream stream;
		
        private IFormatter formatter;
        private TcpClient connection;

        private Queue<Response> responses;
        private volatile bool finished;
        private EventWaitHandle _waitHandle;
        public TeledonServerProxy(string host, int port)
        {
            this.host = host;
            this.port = port;
            responses=new Queue<Response>();
        }
        public void loginUser(string email, string password, ITeledonObserver client)
        {
            initializeConnection();
            sendRequest((new LoginRequest(email,password)));
            Response response = readResponse();
            if (response is OkResponse)
            {
                this.client=client;
                return;
            }
            if (response is ErrorResponse)
            {
                ErrorResponse err =(ErrorResponse)response;
                closeConnection();
                throw new TeledonException(err.Message);
            }

        }

        public Donation[] getAllDonations(string searchName)
        {
            sendRequest(new GetDonationsRequest(searchName));
            Response response = readResponse();
            if (response is ErrorResponse)
            {
                ErrorResponse err =(ErrorResponse)response;
                throw new TeledonException(err.Message);
            }

            GetDonationsResponse resp = (GetDonationsResponse) response;
            Donation[] donations = resp.Donations;
            return donations;
        }

        public void addDonation(Donation donation,ITeledonObserver client)
        {
           sendRequest(new AddDonationRequest(donation));
           Response response = readResponse();
           if (response is ErrorResponse)
           {
               ErrorResponse err =(ErrorResponse)response;
               throw new TeledonException(err.Message);
           }
           
        }

        public ICollection<CharityCase> getAllCases()
        {
           sendRequest(new GetCasesRequest());
           Response response = readResponse();
           if (response is ErrorResponse)
           {
               ErrorResponse err =(ErrorResponse)response;
               throw new TeledonException(err.Message);
           }

           GetCasesResponse resp = (GetCasesResponse) response;
           ICollection<CharityCase> cases = resp.Cases;
           return cases;

        }

        public void logout()
        {
           sendRequest(new LogoutRequest()); 
           Response response =readResponse();
           closeConnection();
           if (response is ErrorResponse)
           {
               ErrorResponse err =(ErrorResponse)response;
               throw new TeledonException(err.Message);
           }
        }
        private void closeConnection()
        {
            finished=true;
            try
            {
                stream.Close();
			
                connection.Close();
                _waitHandle.Close();
                client=null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

        }

        private void sendRequest(Request request)
        {
            try
            {
                formatter.Serialize(stream, request);
                stream.Flush();
            }
            catch (Exception e)
            {
                throw new TeledonException("Error sending object "+e);
            }

        }

        private Response readResponse()
        {
            Response response =null;
            try
            {
                _waitHandle.WaitOne();
                lock (responses)
                {
                    //Monitor.Wait(responses); 
                    response = responses.Dequeue();
                
                }
				

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            return response;
        }
        private void initializeConnection()
        {
            try
            {
                connection=new TcpClient(host,port);
                stream=connection.GetStream();
                formatter = new BinaryFormatter();
                finished=false;
                _waitHandle = new AutoResetEvent(false);
                startReader();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
        private void startReader()
        {
            Thread tw =new Thread(run);
            tw.Start();
        }

        private void handleUpdate(UpdateResponse update)
        {
            if (update is UpdateCasesResponse)
            {
                UpdateCasesResponse upd = (UpdateCasesResponse) update;
                ICollection<CharityCase> cases = upd.Cases;
                Console.WriteLine("Updating Cases....");
                try
                {
                    client.casesAmountUpdate(cases);
                }
                catch (TeledonException e)
                {
                    Console.WriteLine(e.StackTrace); 
                }
            }

            if (update is UpdateDonationsResponse)
            {
                UpdateDonationsResponse upd = (UpdateDonationsResponse) update;
                Donation[] donations = upd.Donations;
                Console.WriteLine("Updating Donations....");
                try
                {
                    client.donationsUpdate(donations);
                }
                catch (TeledonException e)
                {
                    Console.WriteLine(e.StackTrace); 
                } 
            }
        }
        public virtual void run()
        {
            while(!finished)
            {
                try
                {
                    object response = formatter.Deserialize(stream);
                    Console.WriteLine("response received... "+response);
                    if (response is UpdateResponse)
                    {
                        handleUpdate((UpdateResponse)response);
                    }
                    else
                    {
							
                        lock (responses)
                        {
                                					
								 
                            responses.Enqueue((Response)response);
                               
                        }
                        _waitHandle.Set();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Reading error "+e);
                }
					
            }
        }
        //}
    }
}