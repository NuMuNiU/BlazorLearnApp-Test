using BlazorLearnApp.Models;
using BlazorLearnApp.UtilityClass;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;

namespace BlazorLearnApp.Gateway
{
    public class PeopleGateway:Gateway 
    {
        public async Task<Alert> Save(People people, string existCondition = "")
        {
            try
            {
                if (existCondition != "")
                {
                    if (await IsExist(existCondition) == true)
                    {
                        return new Alert("warning", "The record is already exist");
                    }
                }

                Query = "INSERT INTO People (FirstName,LastName,EmailAddress) VALUES(@firstName,@lastName,@emailAddress)";

                Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@firstName", people.FirstName);
                Command.Parameters.AddWithValue("@lastName", people.LastName);
                Command.Parameters.AddWithValue("@emailAddress", people.EmailAddress);

                ConnectionOpen();
                int rowAffected = await Command.ExecuteNonQueryAsync();
                ConnectionClose();

                if (rowAffected > 0)
                {
                    return new Alert("success", "Saved");
                }
                return new Alert("warning", "Not Saved");
            }
            catch (Exception exception)
            {
                return new Alert("danger", "Failed To Save\n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<Alert> Edit(People people, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "UPDATE People SET LastName=@lastName,EmailAddress=@emailAddress WHERE FirstName = @firstName";
                }
                else
                {
                    Query = "UPDATE People SET LastName=@lastName,EmailAddress=@emailAddress WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@firstName", people.FirstName);
                Command.Parameters.AddWithValue("@lastName", people.LastName);
                Command.Parameters.AddWithValue("@emailAddress", people.EmailAddress);

                ConnectionOpen();
                int rowAffected = await Command.ExecuteNonQueryAsync();
                ConnectionClose();

                if (rowAffected > 0)
                {
                    return new Alert("success", "Updated");
                }
                return new Alert("warning", "Not Updated");
            }
            catch (Exception exception)
            {
                return new Alert("danger", "Failed To Updated\n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<Alert> Delete(string firstName, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "DELETE People WHERE FirstName = @firstName";
                }
                else
                {
                    Query = "DELETE People WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@firstName", firstName);

                ConnectionOpen();
                int rowAffected = await Command.ExecuteNonQueryAsync();
                ConnectionClose();

                if (rowAffected > 0)
                {
                    return new Alert("success", "Deleted");
                }
                return new Alert("warning", "Not Deleted");
            }
            catch (Exception exception)
            {
                return new Alert("danger", "Failed To Delete\n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<bool> IsExist(string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT 1 FROM People";
                }
                else
                {
                    Query = "SELECT 1 FROM People WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();
                bool exist = Reader.HasRows;
                Reader.Close();
                ConnectionClose();
                return exist;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<People> GetPeople(string firstName, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT * FROM People WHERE FirstName = @firstName";
                }
                else
                {
                    Query = "SELECT * FROM People WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@firstName", firstName);
                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                People people = new People();
                while (Reader.Read())
                {
                    people.FirstName = Reader["FirstName"].ToString();
                    people.LastName = Reader["LastName"].ToString();
                    people.EmailAddress = Reader["EmailAddress"].ToString();
                }
                Reader.Close();
                ConnectionClose();
                return people;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get People\n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<List<People>> GetPeopleList(string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT * FROM People";
                }
                else
                {
                    Query = "SELECT * FROM People WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                List<People> peopleList = new List<People>();
                while (Reader.Read())
                {
                    People people = new People();

                    people.FirstName = Reader["FirstName"].ToString();
                    people.LastName = Reader["LastName"].ToString();
                    people.EmailAddress = Reader["EmailAddress"].ToString();

                    peopleList.Add(people);
                }
                Reader.Close();
                ConnectionClose();
                return peopleList;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get People List \n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<List<People>> GetPeopleListMinCol(string columns, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT " + columns + " FROM People";
                }
                else
                {
                    Query = "SELECT " + columns + " FROM People WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                List<People> peopleList = new List<People>();
                while (Reader.Read())
                {
                    People people = new People();

                    SkipOnError(() => people.FirstName = Reader["FirstName"].ToString());
                    SkipOnError(() => people.LastName = Reader["LastName"].ToString());
                    SkipOnError(() => people.EmailAddress = Reader["EmailAddress"].ToString());

                    peopleList.Add(people);
                }
                Reader.Close();
                ConnectionClose();
                return peopleList;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get People List \n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        private void SkipOnError(Action action)
        {
            try
            {
                action();
            }
            catch
            {
            }
        }

    }
}
