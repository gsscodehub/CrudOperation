using System.Xml.Linq;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace CrudOperation.Models
{
    public class CustomerDAL
    {
        private readonly IConfiguration _configuration = null;
        public CustomerDAL(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        public Customer EditCustomer(int? Id)
        {
            Customer c = new Customer();
            string sqlDataSource = _configuration.GetConnectionString("ConnectionString");
            using (SqlConnection con = new SqlConnection(sqlDataSource))
            {
                SqlCommand cmd = new SqlCommand("SPEditCustomer", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Id);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {                 
                    c.Id = Convert.ToInt32(dr["Id"]);
                    c.FirstName = Convert.ToString(dr["FirstName"]);
                    c.MiddleName = Convert.ToString(dr["MiddleName"]);
                    c.LastName = Convert.ToString(dr["LastName"]);
                    c.Email = Convert.ToString(dr["Email"]);
                    c.Mobile = Convert.ToString(dr["Mobile"]);
                    c.Address = Convert.ToString(dr["Address"]);
                }

            }
            return c;
        }
        public bool UpdateCustomer(Customer customer)
        {

            string sqlDataSource = _configuration.GetConnectionString("ConnectionString");
            using (SqlConnection con = new SqlConnection(sqlDataSource))
            {
                SqlCommand cmd = new SqlCommand("SPUpdateCustomer", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", customer.Id);
                cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                cmd.Parameters.AddWithValue("@MiddleName", customer.MiddleName);
                cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                cmd.Parameters.AddWithValue("@Email", customer.Email);
                cmd.Parameters.AddWithValue("@Mobile", customer.Mobile);
                cmd.Parameters.AddWithValue("@Address", customer.Address);

                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public bool CreateCustomer(Customer customer)
        {
            string sqlDataSource = _configuration.GetConnectionString("ConnectionString");
            using (SqlConnection con = new SqlConnection(sqlDataSource))
            {
                SqlCommand cmd = new SqlCommand("SPAddCustomer", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                cmd.Parameters.AddWithValue("@MiddleName", customer.MiddleName);
                cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                cmd.Parameters.AddWithValue("@Email", customer.Email);
                cmd.Parameters.AddWithValue("@Mobile", customer.Mobile);
                cmd.Parameters.AddWithValue("@Address", customer.Address);

                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public IEnumerable<Customer> GetCustomerList()
        {

            List<Customer> customers = new List<Customer>();
            string sqlDataSource = _configuration.GetConnectionString("ConnectionString");
            using (SqlConnection con = new SqlConnection(sqlDataSource))
            {
                SqlCommand cmd = new SqlCommand("SPListCustomer", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
             
                while (dr.Read())
                {
                    Customer s = new Customer();
                    s.Id = Convert.ToInt32(dr["Id"]);
                    s.FirstName = Convert.ToString(dr["FirstName"]);
                    s.MiddleName = Convert.ToString(dr["MiddleName"]);
                    s.LastName = Convert.ToString(dr["LastName"]);
                    s.Email = Convert.ToString(dr["Email"]);
                    s.Mobile = Convert.ToString(dr["Mobile"]);
                    s.Address = Convert.ToString(dr["Address"]);
                    customers.Add(s);
                }

            }
            return customers;
        }
    }
}
