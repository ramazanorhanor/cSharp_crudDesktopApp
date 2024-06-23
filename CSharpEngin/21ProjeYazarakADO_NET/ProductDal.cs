using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace _21ProjeYazarakADO_NET
{
    public class ProductDal
    {
        SqlConnection _connection = new SqlConnection(@"server=DESKTOP-AT01LJP;initial catalog=ETRADE_BTK;integrated security=true");
        //private DataTable GetAll() // List<Product>  DataTable
        //{
        //    SqlConnection connection = new SqlConnection(@"server=DESKTOP-AT01LJP;initial catalog=ETRADE_BTK;integrated security=true");
        //    if (connection.State == ConnectionState.Closed)
        //    {
        //        connection.Open();
        //    }
        //    SqlCommand command = new SqlCommand("select * from products", connection);
        //    SqlDataReader reader = command.ExecuteReader();
        //    DataTable dataTable = new DataTable();
        //    dataTable.Load(reader);

        //    connection.Close();
        //    return dataTable;
        //}
        public List<Product>  GetAll() // DataTable   List<Product>
        {

            // localFunction(_connection);
            ConnectionControl();
            SqlCommand command = new SqlCommand("select * from products", _connection);
            SqlDataReader reader = command.ExecuteReader();
            List<Product> products = new List<Product>();
            while (reader.Read())
            {
                Product product = new Product()
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    StockAmount = Convert.ToInt32(reader["StockAmount"]),
                    UnitPrice = Convert.ToDecimal(reader["UnitPrice"]),
                };
                //Product product=null; //System.NullReferenceException: 'Nesne başvurusu bir nesnenin örneğine ayarlanmadı.'
                //product.Id = Convert.ToInt32(reader["Id"]);
                //product.Name = reader["Id"].ToString();
                //product.StockAmount = Convert.ToInt32(reader["StockAmount"]);
                //product.UnitPrice = Convert.ToDecimal(reader["UnitPrice"]);

                products.Add(product);
            }
            _connection.Close();
            return products;

            //void localFunction(SqlConnection connection)
            //{
            //    if (connection.State == ConnectionState.Closed)
            //    {
            //        connection.Open();
            //    }
            //}
        }

        private void ConnectionControl()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
        }

        public void Add(Product product)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Insert Into Products values(@name,@unitPirce,@stockAmount)",_connection);
            command.Parameters.AddWithValue("@name", product.Name);
            command.Parameters.AddWithValue("@unitPirce", product.UnitPrice);
            command.Parameters.AddWithValue("@stockAmount", product.StockAmount);
            command.ExecuteNonQuery();
            _connection.Close();
        }
        public void Update(Product product)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Update Products set Name=@name, UnitPrice=@unitPirce, StockAmount=@stockAmount where Id=@id", _connection);
            command.Parameters.AddWithValue("@name", product.Name);
            command.Parameters.AddWithValue("@unitPirce", product.UnitPrice);
            command.Parameters.AddWithValue("@stockAmount", product.StockAmount);
            command.Parameters.AddWithValue("@id", product.Id);
            command.ExecuteNonQuery();
            _connection.Close();
        }
        public void Delete(int id)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Delete from Products  where Id=@id", _connection);           
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
            _connection.Close();
        }
    }
}
