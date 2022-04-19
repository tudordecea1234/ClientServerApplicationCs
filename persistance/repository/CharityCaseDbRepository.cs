using System;
using System.Collections.Generic;
using System.Data;
using Lab6_mpp.model;
using log4net;


namespace Lab6_mpp.repository
{
    public class CharityCaseDbRepository : IRepository<CharityCase, long>
    {
        private static readonly ILog log = LogManager.GetLogger("VolunteerDbRepository");

        IDictionary<String, string> props;

        public CharityCaseDbRepository(IDictionary<String, string> props)
        {
            log.Info("Creating CharityCaseDbRepository... ");
            this.props = props;
        }

        public void Add(CharityCase entity)
        {
            var con = DBUtils.getConnection(props);

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "insert into CharityCases (caseName,totalAmount) values (@name,@total)";
                var paramFirst = comm.CreateParameter();
                paramFirst.ParameterName = "@name";
                paramFirst.Value = entity.CaseName;
                comm.Parameters.Add(paramFirst);

                var paramAmount = comm.CreateParameter();
                paramAmount.ParameterName = "@total";
                paramAmount.Value = entity.TotalAmount;
                comm.Parameters.Add(paramAmount);


                var result = comm.ExecuteNonQuery();
                if (result == 0)
                    throw new Exception("No Charity Case added !");
            }
        }

        public void Update(CharityCase entity, long id)
        {
            var con = DBUtils.getConnection(props);

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "update CharityCases set caseName=@name,totalAmount=@total where id=@id";
                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);

                var paramFirst = comm.CreateParameter();
                paramFirst.ParameterName = "@name";
                paramFirst.Value = entity.CaseName;
                comm.Parameters.Add(paramFirst);

                var paramAmount = comm.CreateParameter();
                paramAmount.ParameterName = "@total";
                paramAmount.Value = entity.TotalAmount;
                comm.Parameters.Add(paramAmount);

                var result = comm.ExecuteNonQuery();
                if (result == 0)
                    throw new Exception("No Case updated!");
            }
        }

        public void Delete(long id)
        {
            IDbConnection con = DBUtils.getConnection(props);
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "delete from CharityCases where id=@id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);
                var dataR = comm.ExecuteNonQuery();
                /*if (dataR == 0)
                    throw new Exception("No task deleted!");*/
            }
        }

        public CharityCase findOne(long id)
        {
            log.InfoFormat("Entering findOne with value {0}", id);
            IDbConnection con = DBUtils.getConnection(props);

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from CharityCases where id=@id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);

                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        String name = dataR.GetString(1);
                        float total = dataR.GetFloat(2);
                        CharityCase case1 = new CharityCase(name, total);
                        case1.ID = id;
                        log.InfoFormat("Exiting findOne with value {0}", case1);
                        return case1;
                    }
                }
            }

            log.InfoFormat("Exiting findOne with value {0}", null);
            return null;
        }

        public IEnumerable<CharityCase> findAll()
        {
            var con = DBUtils.getConnection(props);
            IList<CharityCase> cases = new List<CharityCase>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from CharityCases";

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        long id = dataR.GetInt64(0);
                        String name = dataR.GetString(1);
                        float total = dataR.GetFloat(2);
                        CharityCase case1 = new CharityCase(name, total);
                        case1.ID = id;
                        cases.Add(case1);
                    }
                }
            }

            return cases;
        }

        public ICollection<CharityCase> getAll()
        {
            var con = DBUtils.getConnection(props);
            IList<CharityCase> cases = new List<CharityCase>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from CharityCases";

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        long id = dataR.GetInt64(0);
                        String name = dataR.GetString(1);
                        float total = dataR.GetFloat(2);
                        CharityCase case1 = new CharityCase(name, total);
                        case1.ID = id;
                        cases.Add(case1);
                    }
                }
            }

            return cases;
        }
    }
}