using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Microsoft.Data.SqlClient;

namespace ProductInventoryTracker
{
    public class InventoryService
    {
        private string _connString = ConfigurationManager.ConnectionStrings["InventoryDb"].ConnectionString;

        public int GetTotalProductCount()
        {
            using (var conn = new SqlConnection(this._connString))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT SUM(Quantity) AS Total FROM dbo.Product";

                    var result = cmd.ExecuteScalar();
                    if (result == null || result == DBNull.Value)
                    {
                        return 0;
                    }

                    return Convert.ToInt32(result);
                }
            }
        }

        public void DeleteProduct(string productId)
        {
            using (var conn = new SqlConnection(this._connString))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM dbo.Product WHERE ProductID = @id";

                    cmd.Parameters.AddWithValue("id", productId);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Product> GetLowStockAlerts(int threshold)
        {
            var products = new List<Product>();

            using (var conn = new SqlConnection(this._connString))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    // Select products where the quantity is less than the threshold
                    cmd.CommandText = "SELECT * FROM dbo.Product WHERE Quantity <= @threshold ORDER BY Quantity ASC";
                    cmd.Parameters.AddWithValue("threshold", threshold);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            products.Add(new Product(
                                (int)reader["ProductID"],
                                reader["ProductName"].ToString()!,
                                (decimal)reader["Price"],
                                (int)reader["Quantity"],
                                (int)reader["CategoryID"],
                                (int)reader["SupplierID"]
                            ));
                        }
                    }
                }
            }
            return products;
        }

        public void UpdateProduct(int productId, string name, decimal price, int quantity, int categoryId, int supplierId)
        {
            using (var conn = new SqlConnection(this._connString))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        UPDATE dbo.Product 
                        SET ProductName = @name, 
                            Price = @price, 
                            Quantity = @qty, 
                            CategoryID = @catId, 
                            SupplierID = @supId 
                        WHERE ProductID = @id";

                    cmd.Parameters.AddWithValue("id", productId);
                    cmd.Parameters.AddWithValue("name", name);
                    cmd.Parameters.AddWithValue("price", price);
                    cmd.Parameters.AddWithValue("qty", quantity);
                    cmd.Parameters.AddWithValue("catId", categoryId);
                    cmd.Parameters.AddWithValue("supId", supplierId);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AddProduct(string name, decimal price, int quantity, int categoryId, int supplierId)
        {
            using (var conn = new SqlConnection(this._connString))
            {
                conn.Open();
                using(var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO dbo.Product(ProductName, Price, Quantity, CategoryID, SupplierID) VALUES(@p0, @p1, @p2, @p3, @p4);";

                    cmd.Parameters.AddWithValue("p0", name);
                    cmd.Parameters.AddWithValue("p1", price);
                    cmd.Parameters.AddWithValue("p2", quantity);
                    cmd.Parameters.AddWithValue("p3", categoryId);
                    cmd.Parameters.AddWithValue("p4", supplierId);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Product> GetProducts()
        {
            var products = new List<Product>();

            using (var conn = new SqlConnection(this._connString))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM dbo.Product";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var product = new Product(
                                   (int)reader["ProductID"],
                                   reader["ProductName"].ToString()!,
                                   (decimal)reader["Price"],
                                   (int)reader["Quantity"],
                                   (int)reader["CategoryID"],
                                   (int)reader["SupplierID"]
                                );
                            products.Add(product);
                        }
                        return products;
                    }
                }
            }
        }
        public List<Category> GetCategories()
        {
            var list = new List<Category>();
            // Wrap connections in 'using' statements to prevent database memory leaks
            using (var conn = new SqlConnection(this._connString))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT CategoryID, CategoryName FROM dbo.Category";

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = (int)reader["CategoryID"];
                            string name = reader["CategoryName"].ToString()!;

                            // Uses your newly updated constructor!
                            list.Add(new Category(id, name));
                        }
                    }
                }
            }
            return list;
        }
        public List<Supplier> GetSuppliers()
        {
            var list = new List<Supplier>();
            // Wrap connections in 'using' statements to prevent database memory leaks
            using (var conn = new SqlConnection(this._connString))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT SupplierID, SupplierName, SupplierEmail, SupplierPhone FROM dbo.Supplier";

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = (int)reader["SupplierID"];
                            string name = reader["SupplierName"].ToString()!;
                            string email = reader["SupplierEmail"].ToString()!;
                            string phone = reader["SupplierPhone"].ToString()!;

                            // Uses your newly updated constructor!
                            list.Add(new Supplier(id, name, email, phone));
                        }
                    }
                }
            }
            return list;
        }

        public void AddSupplier(string name, string email, string phone)
        {
            using (var conn = new SqlConnection(this._connString))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    // SQL parameterized statement to protect your database
                    cmd.CommandText = "INSERT INTO dbo.Supplier (SupplierName, SupplierEmail, SupplierPhone) VALUES (@name, @email, @phone)";

                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@phone", phone);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateSupplier(int id, string name, string email, string phone)
        {
            using (var conn = new SqlConnection(this._connString))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE dbo.Supplier SET SupplierName = @name, SupplierEmail = @email, SupplierPhone = @phone WHERE SupplierID = @id";

                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@phone", phone);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteSupplier(int id)
        {
            using (var conn = new SqlConnection(this._connString))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM dbo.Supplier WHERE SupplierID = @id";

                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
