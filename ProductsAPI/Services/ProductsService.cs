using ProductsAPI.Models;
using System.Data.SqlClient;

namespace ProductsAPI.Services
{
    public class ProductsService
    {
        private SqlConnection GetConnection()
        {
            string connectionString = "Server=tcp:sqlappserverkpr.database.windows.net,1433;Initial Catalog=sqlappdb;Persist Security Info=False;User ID=krisprematarov;Password=KRISTIJANazure1!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            return new SqlConnection(connectionString);
        }

        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();

            string cmd = "SELECT ProductID, ProductName, Quantity FROM Products";

            SqlConnection sqlConnection = GetConnection();

            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand(cmd, sqlConnection);

            using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
            {
                while (sqlDataReader.Read())
                {
                    Product product = new()
                    {
                        ProductID = sqlDataReader.GetInt32(0),
                        ProductName = sqlDataReader.GetString(1),
                        Quantity = sqlDataReader.GetInt32(2)
                    };

                    products.Add(product);
                }
            }

            sqlConnection.Close();

            return products;
        }

        public Product GetProduct(string _productId)
        {
            int productId = Convert.ToInt32(_productId);

            string cmd = $"SELECT ProductID, ProductName, Quantity FROM Products WHERE ProductID={productId}";

            SqlConnection sqlConnection = GetConnection();

            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand(cmd, sqlConnection);

            using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
            {
                sqlDataReader.Read();//start reading, meaning, read the first record

                Product product = new()
                {
                    ProductID = sqlDataReader.GetInt32(0),
                    ProductName = sqlDataReader.GetString(1),
                    Quantity = sqlDataReader.GetInt32(2)
                };

                return product;
            }
        }
    }
}
