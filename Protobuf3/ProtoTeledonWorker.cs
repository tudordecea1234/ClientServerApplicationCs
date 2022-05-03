using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;
using Google.Protobuf;
using services;

namespace Proto.ProtoBuffProtocol
{
    public class ProtoTeledonWorker:ITeledonObserver
    { private ITeledonService server;
        private TcpClient connection;

        private NetworkStream stream;
        private volatile bool connected;

        public ProtoTeledonWorker(ITeledonService service, TcpClient connection)
        {
            this.server = service;
            this.connection = connection;
            try
            {
				
                stream=connection.GetStream();
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
					
                    TeledonRequest request = TeledonRequest.Parser.ParseDelimitedFrom(stream);
                    TeledonResponse response =handleRequest(request);
                    if (response!=null)
                    {
                        sendResponse(response);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                    Console.WriteLine(e.Message);
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
        public void donationReceived(Lab6_mpp.model.Donation donation)
        {
	        Console.WriteLine("Donation received..."+donation);
	        try
	        {
		        sendResponse(ProtoUtils.addDonationResponse(donation));
	        }
	        catch (Exception e)
	        {
		        throw new TeledonException("Sending error: "+e);
	        }
        }

        public void casesAmountUpdate(ICollection<Lab6_mpp.model.CharityCase> case1)
        {
	        Console.WriteLine("Updating cases... ");
	        try
	        {
		        sendResponse(ProtoUtils.UpdateCasesResponse(case1));
	        }
	        catch (Exception e)
	        {
		        Console.WriteLine(e.StackTrace);
	        } 
        }

        public void donationsUpdate(Lab6_mpp.model.Donation[] donations)
        {
            throw new System.NotImplementedException();
        }
        private TeledonResponse handleRequest(TeledonRequest request)
		{
			TeledonResponse response =null;
            TeledonRequest.Types.Type reqType=request.Type;
            switch(reqType){
                case TeledonRequest.Types.Type.Login:
			{
				Console.WriteLine("Login request ...");
				Lab6_mpp.model.Volunteer user =ProtoUtils.getUser(request);
				try
                {
                    lock (server)
                    {
                        server.loginUser(user.Email,user.Password, this);
                    }
					return ProtoUtils.createOkResponse();
				}
				catch (TeledonException e)
				{
					connected=false;
					return ProtoUtils.createErrorResponse(e.Message);
				}
			}
                case TeledonRequest.Types.Type.Logout:
			{
				Console.WriteLine("Logout request");
				try
				{
                    lock (server)
                    {

                        server.logout();
                    }
					connected=false;
					return ProtoUtils.createOkResponse();

				}
				catch (TeledonException e)
				{
				   return ProtoUtils.createErrorResponse(e.Message);
				}
			}
                case TeledonRequest.Types.Type.AddDonation:
			{
				Console.WriteLine("AddDonationRequest ...");
                Lab6_mpp.model.Donation message = ProtoUtils.getNewDonation(request);
				try
				{ 
                    lock (server)
                    {
                       server.addDonation(message,this);
                    }
                        return ProtoUtils.addDonationResponse(message);
				}
				catch (TeledonException e)
				{
					return ProtoUtils.createErrorResponse(e.Message);
				}
			}

                case TeledonRequest.Types.Type.GetDonations:
			{
				Console.WriteLine("GetAllDonations Request ..."); //DTOUtils.getFromDTO(udto);
				try
				{
                    Lab6_mpp.model.Donation[] dons;
                    lock (server)
                    {

                         dons = server.getAllDonations(request.SearchName);
                    }
					return ProtoUtils.createGetDonationsResponse(dons);
				}
				catch (TeledonException e)
				{
					return ProtoUtils.createErrorResponse(e.Message);
				}
			}
                case TeledonRequest.Types.Type.GetCharityCases:
                {
	                Console.WriteLine("GetAllCases Request ..."); //DTOUtils.getFromDTO(udto);
	                try
	                {
		                ICollection<Lab6_mpp.model.CharityCase> cases;
		                lock (server)
		                {

			                cases = server.getAllCases();
		                }
		                return ProtoUtils.createCasesResponse(cases);
	                }
	                catch (TeledonException e)
	                {
		                return ProtoUtils.createErrorResponse(e.Message);
	                }
                }
            }
			return response;
		}

	private void sendResponse(TeledonResponse response)
		{
			Console.WriteLine("sending response "+response);
			lock (stream)
			{
				response.WriteDelimitedTo(stream);
				stream.Flush();
			}

		}
    }
}