using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab6_mpp.model;
using log4net;


namespace Lab6_mpp.repository
{
    public class VolunteerDbRepository : IRepository<Volunteer, long>
    {
        private static readonly ILog log = LogManager.GetLogger("VolunteerDbRepository");

        IDictionary<String, string> props;

        public VolunteerDbRepository(IDictionary<String, string> props)
        {
            log.Info("Creating VolunteerDbRepository... ");
            this.props = props;
        }

        public void Add(Volunteer entity)
        {
            var con = DBUtils.getConnection(props);

            using (var comm = con.CreateCommand())
            {
                comm.CommandText =
                    "insert into Volunteers (firstName,lastName,email,password) values (@firstName, @lastName, @email, @password)";
                var paramFirst = comm.CreateParameter();
                paramFirst.ParameterName = "@firstName";
                paramFirst.Value = entity.FirstName;
                comm.Parameters.Add(paramFirst);

                var paramLast = comm.CreateParameter();
                paramLast.ParameterName = "@lastName";
                paramLast.Value = entity.LastName;
                comm.Parameters.Add(paramLast);

                var paramEmail = comm.CreateParameter();
                paramEmail.ParameterName = "@email";
                paramEmail.Value = entity.Email;
                comm.Parameters.Add(paramEmail);

                var paramP = comm.CreateParameter();
                paramP.ParameterName = "@password";
                paramP.Value = entity.Password;
                comm.Parameters.Add(paramP);

                var result = comm.ExecuteNonQuery();
                if (result == 0)
                    throw new Exception("No task added !");
            }
        }

        public void Delete(long id)
        {
            IDbConnection con = DBUtils.getConnection(props);
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "delete from Volunteers where id=@id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);
                var dataR = comm.ExecuteNonQuery();
                /*if (dataR == 0)
                    throw new Exception("No task deleted!");*/
            }
        }

        public IEnumerable<Volunteer> findAll()
        {
            IDbConnection con = DBUtils.getConnection(props);
            IList<Volunteer> tasksR = new List<Volunteer>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from Volunteers";

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        long id = dataR.GetInt64(0);
                        String first = dataR.GetString(1);
                        String last = dataR.GetString(2);
                        String email = dataR.GetString(3);
                        String pass = dataR.GetString(4);
                        Volunteer vol = new Volunteer(first, last, email, pass);
                        vol.ID = id;
                        tasksR.Add(vol);
                    }
                }
            }

            return tasksR;
        }

        public Volunteer findByEmail(String email)
        {
            log.InfoFormat("Entering findByEmail with value {0}", email);
            IDbConnection con = DBUtils.getConnection(props);

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select id,firstName,lastName, email, password from Volunteers where email=@email";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@email";
                paramId.Value = email;
                comm.Parameters.Add(paramId);

                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        long id = dataR.GetInt64(0);
                        String first = dataR.GetString(1);
                        String last = dataR.GetString(2);
                        String email2 = dataR.GetString(3);
                        String password = dataR.GetString(4);
                        Volunteer vol = new Volunteer(first, last, email2, password);
                        vol.ID = id;
                        log.InfoFormat("Exiting findOne with value {0}", vol);
                        return vol;
                    }
                }
            }

            log.InfoFormat("Exiting findOne with value {0}", null);
            return null;
        }

        public Volunteer findOne(long id)
        {
            log.InfoFormat("Entering findOne with value {0}", id);
            IDbConnection con = DBUtils.getConnection(props);

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select firstName,lastName, email, password from Volunteers where id=@id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);

                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        String first = dataR.GetString(0);
                        String last = dataR.GetString(1);
                        String email = dataR.GetString(2);
                        String password = dataR.GetString(3);
                        Volunteer vol = new Volunteer(first, last, email, password);
                        vol.ID = id;
                        log.InfoFormat("Exiting findOne with value {0}", vol);
                        return vol;
                    }
                }
            }

            log.InfoFormat("Exiting findOne with value {0}", null);
            return null;
        }

        public ICollection<Volunteer> getAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Volunteer entity, long id)
        {
            var con = DBUtils.getConnection(props);

            using (var comm = con.CreateCommand())
            {
                comm.CommandText =
                    "update Volunteers set firstName=@firstName,lastName=@lastName,email=@email,password=@password where id=@id";
                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);

                var paramFirst = comm.CreateParameter();
                paramFirst.ParameterName = "@firstName";
                paramFirst.Value = entity.FirstName;
                comm.Parameters.Add(paramFirst);

                var paramLast = comm.CreateParameter();
                paramLast.ParameterName = "@lastName";
                paramLast.Value = entity.LastName;
                comm.Parameters.Add(paramLast);

                var paramEmail = comm.CreateParameter();
                paramEmail.ParameterName = "@email";
                paramEmail.Value = entity.Email;
                comm.Parameters.Add(paramEmail);

                var paramP = comm.CreateParameter();
                paramP.ParameterName = "@password";
                paramP.Value = entity.Password;
                comm.Parameters.Add(paramP);

                var result = comm.ExecuteNonQuery();
                if (result == 0)
                    throw new Exception("No volunteer added !");
            }
        }
    }
}