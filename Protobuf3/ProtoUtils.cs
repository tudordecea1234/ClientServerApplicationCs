using System;
using System.Collections.Generic;
using System.Linq;

namespace Proto.ProtoBuffProtocol
{
    public class ProtoUtils
    {
        public static TeledonRequest createLoginRequest(string email,string pass)
        {
            //new proto.User {Id = user.Id, Passwd = user.Password};
            Volunteer userDTO = new Volunteer() {Email = email, Password= pass};
             TeledonRequest request = new TeledonRequest(){Type = TeledonRequest.Types.Type.Login, User = userDTO};
              
            return request;
        }
        

        public static TeledonRequest createLogoutRequest()
        {  
            TeledonRequest request= new TeledonRequest(){Type=TeledonRequest.Types.Type.Logout};
            return request;
        } 
        public static TeledonRequest createAddDonationRequest(Lab6_mpp.model.Donation donation)
        {
            Donation donDTO = new Donation
            {
                DonorFirstName = donation.DonorFirstame,
                DonorLastName = donation.DonorLastName,
                Address = donation.DonorAddress,
                Phone = donation.DonorAddress,
                IdCase = donation.IDCase.ToString(),
                AmountDonated = donation.AmountDonated.ToString()
            };
               
            TeledonRequest request = new TeledonRequest(){  Type=TeledonRequest.Types.Type.AddDonation, Donation = donDTO};
            return request;
        }

        public static TeledonRequest createGetDonationsRequest(string searchName)
        {
            TeledonRequest request = new TeledonRequest
            {
                Type=TeledonRequest.Types.Type.GetDonations,
                SearchName = searchName
            };
            return request;
        }
        public static TeledonRequest createGetCasesRequest()
        {
            TeledonRequest request = new TeledonRequest
            {
                Type=TeledonRequest.Types.Type.GetCharityCases
            };
            return request;
        }
        public static TeledonResponse createOkResponse()
        {
            TeledonResponse response = new TeledonResponse(){ Type=TeledonResponse.Types.Type.Ok};
            return response;
        }

        
        public static TeledonResponse createErrorResponse(string text)
        {
            TeledonResponse response = new TeledonResponse(){
                Type=TeledonResponse.Types.Type.Error, Error=text};
            return response;
        }

        public static TeledonResponse addDonationResponse(Lab6_mpp.model.Donation don)
        {
            Donation donDTO = new Donation()
            {
                IdCase = don.IDCase.ToString(),
                DonorFirstName = don.DonorFirstame,
                DonorLastName = don.DonorLastName,
                Address = don.DonorAddress,
                Phone = don.PhoneNumber,
                AmountDonated = don.AmountDonated.ToString()
            };
            TeledonResponse response = new TeledonResponse{Type=TeledonResponse.Types.Type.NewDonation, Donation = donDTO};
            return response;
        }
        public static TeledonResponse createGetDonationsResponse(Lab6_mpp.model.Donation[] donations)
        {
            TeledonResponse response = new TeledonResponse { 
                Type=TeledonResponse.Types.Type.GetDonations
            };
            foreach (Lab6_mpp.model.Donation donation in donations)
            {
                Donation donDTO = new Donation()
                {
                    Address = donation.DonorAddress,
                    AmountDonated = donation.AmountDonated.ToString(),
                    DonorFirstName = donation.DonorFirstame,
                    DonorLastName = donation.DonorLastName,
                    IdCase = donation.IDCase.ToString(),
                    Phone = donation.PhoneNumber
                };

                response.Donations.Add(donDTO);
            }

            return response;
        }

        public static TeledonResponse createCasesResponse(ICollection<Lab6_mpp.model.CharityCase> cases)
        {
            TeledonResponse response = new TeledonResponse
            {
                Type = TeledonResponse.Types.Type.GetCharityCases
            };
            foreach (Lab6_mpp.model.CharityCase case1 in cases)
            {
                CharityCase caseDTO = new CharityCase()
                {   Id = case1.ID,
                    CaseName = case1.CaseName,
                    TotalAmount = case1.TotalAmount
                };

                response.Cases.Add(caseDTO);
            }

            return response;
        }
        public static TeledonResponse UpdateCasesResponse(ICollection<Lab6_mpp.model.CharityCase> cases)
        {
            TeledonResponse response = new TeledonResponse
            {
                Type = TeledonResponse.Types.Type.UpdateCases
            };
            foreach (Lab6_mpp.model.CharityCase case1 in cases)
            {
                CharityCase caseDTO = new CharityCase()
                {   Id = case1.ID,
                    CaseName = case1.CaseName,
                    TotalAmount = case1.TotalAmount
                };

                response.Cases.Add(caseDTO);
            }

            return response;
        }

        public static Lab6_mpp.model.Donation getNewDonation(TeledonRequest request)
        {
            Lab6_mpp.model.Donation don = new Lab6_mpp.model.Donation(Convert.ToInt64(request.Donation.IdCase),
                request.Donation.DonorFirstName, request.Donation.DonorLastName,
                request.Donation.Address, request.Donation.Phone, Convert.ToSingle(request.Donation.AmountDonated));
            return don;
        }

        public static Lab6_mpp.model.Donation[] getAllDonations(TeledonResponse response)
        {
            Lab6_mpp.model.Donation[] donations = new Lab6_mpp.model.Donation[response.Donations.Count];
            for (int i = 0; i < response.Donations.Count; i++)
            {
                Lab6_mpp.model.Donation don = new Lab6_mpp.model.Donation(Convert.ToInt64(response.Donations[i].IdCase),
                    response.Donations[i].DonorFirstName,
                    response.Donations[i].DonorLastName,
                    response.Donations[i].Address,
                    response.Donations[i].Phone,
                    Convert.ToSingle(response.Donations[i].AmountDonated));
                donations[i] = don;
            }
            return donations;
        }
        
        public static Lab6_mpp.model.CharityCase[] getAllCases(TeledonResponse response)
        {
            Lab6_mpp.model.CharityCase[] cases = new Lab6_mpp.model.CharityCase[response.Cases.Count];
            for (int i = 0; i < response.Cases.Count; i++)
            {
                Lab6_mpp.model.CharityCase case1 =
                    new Lab6_mpp.model.CharityCase(response.Cases[i].CaseName, response.Cases[i].TotalAmount);
                cases[i] = case1;
            }
            return cases;
        }
        public static Lab6_mpp.model.Volunteer getUser(TeledonRequest request)
        {
            Lab6_mpp.model.Volunteer user = new Lab6_mpp.model.Volunteer();
            user.Email = request.User.Email;
            user.Password = request.User.Password;
            return user;
        }
         
    }
}
