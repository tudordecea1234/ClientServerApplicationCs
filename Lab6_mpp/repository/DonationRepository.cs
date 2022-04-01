using System;
using System.Collections.Generic;
using System.Data;
using Lab6_mpp.model;
using log4net;


namespace Lab6_mpp.repository
{

    public class DonationDbRepository : IRepository<Donation, long>
    {
        private static readonly ILog log = LogManager.GetLogger("VolunteerDbRepository");

        IDictionary<String, string> props;

        public DonationDbRepository(IDictionary<String, string> props)
        {
            log.Info("Creating CharityCaseDbRepository... ");
            this.props = props;
        }

        public void Add(Donation entity)
        {
            var con = DBUtils.getConnection(props);

            using (var comm = con.CreateCommand())
            {
                comm.CommandText =
                    "insert into Donation (idCase,donorFirstName,donorLastName,address,phoneNumber,amountDonated) values (@idCase,@first,@last,@address,@phone,@amount)";
                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@idCase";
                paramId.Value = entity.IDCase;
                comm.Parameters.Add(paramId);

                var paramAddress = comm.CreateParameter();
                paramAddress.ParameterName = "@address";
                paramAddress.Value = entity.DonorAddress;
                comm.Parameters.Add(paramAddress);

                var paramFirst = comm.CreateParameter();
                paramFirst.ParameterName = "@first";
                paramFirst.Value = entity.DonorFirstame;
                comm.Parameters.Add(paramFirst);

                var paramLast = comm.CreateParameter();
                paramLast.ParameterName = "@last";
                paramLast.Value = entity.DonorLastName;
                comm.Parameters.Add(paramLast);

                var paramPhone = comm.CreateParameter();
                paramPhone.ParameterName = "@phone";
                paramPhone.Value = entity.PhoneNumber;
                comm.Parameters.Add(paramPhone);

                var paramAmount = comm.CreateParameter();
                paramAmount.ParameterName = "@amount";
                paramAmount.Value = entity.AmountDonated;
                comm.Parameters.Add(paramAmount);


                var result = comm.ExecuteNonQuery();
                if (result == 0)
                    throw new Exception("No Donation added !");
            }

            log.Info("Donation added successfully!");
        }

        public void Update(Donation entity, long id)
        {
            var con = DBUtils.getConnection(props);

            using (var comm = con.CreateCommand())
            {
                comm.CommandText =
                    "update Donation set idCase=@idCase,donorFirstName=@first,donorLastName=@last,address=@address,phoneNumber=@phone,amountDonated=@amount where id=@id";
                var paramIdCase = comm.CreateParameter();
                paramIdCase.ParameterName = "@idCase";
                paramIdCase.Value = entity.IDCase;
                comm.Parameters.Add(paramIdCase);

                var paramAddress = comm.CreateParameter();
                paramAddress.ParameterName = "@address";
                paramAddress.Value = entity.DonorAddress;
                comm.Parameters.Add(paramAddress);

                var paramFirst = comm.CreateParameter();
                paramFirst.ParameterName = "@first";
                paramFirst.Value = entity.DonorFirstame;
                comm.Parameters.Add(paramFirst);

                var paramLast = comm.CreateParameter();
                paramLast.ParameterName = "@last";
                paramLast.Value = entity.DonorLastName;
                comm.Parameters.Add(paramLast);

                var paramPhone = comm.CreateParameter();
                paramPhone.ParameterName = "@phone";
                paramPhone.Value = entity.PhoneNumber;
                comm.Parameters.Add(paramPhone);

                var paramAmount = comm.CreateParameter();
                paramAmount.ParameterName = "@amount";
                paramAmount.Value = entity.AmountDonated;
                comm.Parameters.Add(paramAmount);

                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);

                var result = comm.ExecuteNonQuery();
                if (result == 0)
                    throw new Exception("No Donation updated!");
            }

            log.Info("Donation updated successfully");
        }

        public void Delete(long id)
        {
            IDbConnection con = DBUtils.getConnection(props);
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "delete from Donation where id=@id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);
                var dataR = comm.ExecuteNonQuery();
                /*if (dataR == 0)
                    throw new Exception("No task deleted!");*/
            }

            log.Info("Donation deleted successfully!");
        }

        public Donation findOne(long id)
        {
            log.InfoFormat("Entering findOne with value {0}", id);
            IDbConnection con = DBUtils.getConnection(props);

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from Donation where id=@id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);

                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        long idCase = dataR.GetInt64(1);
                        String first = dataR.GetString(2);
                        String last = dataR.GetString(3);
                        String address = dataR.GetString(4);
                        String phone = dataR.GetString(5);
                        float amount = dataR.GetFloat(6);
                        Donation don = new Donation(idCase, first, last, address, phone, amount);
                        don.ID = id;
                        log.InfoFormat("Exiting findOne with value {0}", don);
                        return don;
                    }
                }
            }

            log.InfoFormat("Exiting findOne with value {0}", null);
            return null;
        }

        public IEnumerable<Donation> findAll()
        {
            var con = DBUtils.getConnection(props);
            IList<Donation> dons = new List<Donation>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from Donation";

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        long id = dataR.GetInt64(0);
                        long idCase = dataR.GetInt64(1);
                        String first = dataR.GetString(2);
                        String last = dataR.GetString(3);
                        String address = dataR.GetString(4);
                        String phone = dataR.GetString(5);
                        float amount = dataR.GetFloat(6);
                        Donation don = new Donation(idCase, first, last, address, phone, amount);
                        don.ID = id;
                        dons.Add(don);
                    }
                }
            }

            return dons;
        }

        public ICollection<Donation> getAll()
        {
            var con = DBUtils.getConnection(props);
            IList<Donation> dons = new List<Donation>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from Donation";

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        long id = dataR.GetInt64(0);
                        long idCase = dataR.GetInt64(1);
                        String first = dataR.GetString(2);
                        String last = dataR.GetString(3);
                        String address = dataR.GetString(4);
                        String phone = dataR.GetString(5);
                        float amount = dataR.GetFloat(6);
                        Donation don = new Donation(idCase, first, last, address, phone, amount);
                        don.ID = id;
                        dons.Add(don);
                    }
                }
            }

            return dons;
        }
    }
}