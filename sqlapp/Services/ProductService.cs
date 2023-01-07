using sqlapp.Models;
using System.Data.SqlClient;

namespace sqlapp.Services
{
    public class ProductService
    {
        private static string db_source = "appserver121.database.windows.net";
        private static string db_user = "raja";
        private static string db_password = "Aryastark@1996";
        private static string db_database = "appdb";

        private SqlConnection GetConection()
        {
            var _builder = new SqlConnectionStringBuilder();
            _builder.DataSource = db_source;
            _builder.UserID = db_user;
            _builder.Password = db_password;
            _builder.InitialCatalog = db_database;
            return new SqlConnection(_builder.ConnectionString);
        }

        public List<Product> GetProductsList()
        {
            List<Product> products = new List<Product>();

            SqlConnection conn = GetConection();
            var statement = "SELECT ProductID, ProductName, Quantity FROM Products";
            conn.Open();
            SqlCommand cmd = new SqlCommand(statement, conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {

                while (reader.Read())
                {
                    Product product = new Product()
                    {
                        ProductID = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        Quantity = reader.GetInt32(2)
                    };   
                    products.Add(product);
                }
            }

            return products;
        }
    }
}
