using System;
using System.Configuration;
using System.Data.SqlClient;

namespace library
{
    public class CADProduct
    {
        private string constring;

        public CADProduct()
        {
            constring = ConfigurationManager.ConnectionStrings["miconexion"].ToString();
        }

        public bool create(ENProduct en)
        {
            bool exito = false;
            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();
                SqlCommand comCheck = new SqlCommand("SELECT COUNT(*) FROM Products WHERE code = @code", c);
                comCheck.Parameters.AddWithValue("@code", en.Code);
                int count = (int)comCheck.ExecuteScalar();

                if (count == 0)
                {
                    SqlCommand com = new SqlCommand("INSERT INTO Products (name, code, amount, price, category, creationDate) VALUES (@name, @code, @amount, @price, @category, @creationDate)", c);
                    com.Parameters.AddWithValue("@name", en.Name);
                    com.Parameters.AddWithValue("@code", en.Code);
                    com.Parameters.AddWithValue("@amount", en.Amount);
                    com.Parameters.AddWithValue("@price", en.Price);
                    com.Parameters.AddWithValue("@category", en.Category);
                    com.Parameters.AddWithValue("@creationDate", en.CreationDate);
                    com.ExecuteNonQuery();
                    exito = true;
                }
                else
                {
                    Console.WriteLine("Product operation has failed. Error: A product with this Code already exists.");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
                exito = false;
            }
            finally
            {
                c.Close();
            }
            return exito;
        }

        public bool update(ENProduct en)
        {
            bool exito = false;
            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("UPDATE Products SET name=@n, amount=@a, price=@p, category=@c, creationDate=@d WHERE code=@code", c);
                com.Parameters.AddWithValue("@n", en.Name);
                com.Parameters.AddWithValue("@a", en.Amount);
                com.Parameters.AddWithValue("@p", en.Price);
                com.Parameters.AddWithValue("@c", en.Category);
                com.Parameters.AddWithValue("@d", en.CreationDate);
                com.Parameters.AddWithValue("@code", en.Code);

                if (com.ExecuteNonQuery() > 0) exito = true;
            }
            catch (SqlException ex) { Console.WriteLine("Product operation has failed. Error: {0}", ex.Message); }
            finally { c.Close(); }
            return exito;
        }
        public bool delete(ENProduct en)
        {
            bool exito = false;
            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();
                // Borramos el producto que coincida con el código
                SqlCommand com = new SqlCommand("DELETE FROM Products WHERE code = @code", c);
                com.Parameters.AddWithValue("@code", en.Code);

                if (com.ExecuteNonQuery() > 0) exito = true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
            }
            finally { c.Close(); }
            return exito;
        }

        public bool read(ENProduct en)
        {
            bool exito = false;
            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("SELECT * FROM Products WHERE code = @code", c);
                com.Parameters.AddWithValue("@code", en.Code);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    en.Name = dr["name"].ToString();
                    en.Amount = int.Parse(dr["amount"].ToString());
                    en.Price = float.Parse(dr["price"].ToString());
                    en.Category = int.Parse(dr["category"].ToString());
                    en.CreationDate = DateTime.Parse(dr["creationDate"].ToString());
                    exito = true;
                }
                dr.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
                exito = false;
            }
            finally
            {
                c.Close();
            }
            return exito;
        }

        public bool readFirst(ENProduct en)
        {
            bool exito = false;
            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();
                // SQL: Seleccionamos el primer registro ordenado por código
                SqlCommand com = new SqlCommand("SELECT TOP 1 * FROM Products ORDER BY code ASC", c);
                SqlDataReader dr = com.ExecuteReader();

                if (dr.Read())
                {
                    en.Code = dr["code"].ToString();
                    en.Name = dr["name"].ToString();
                    en.Amount = int.Parse(dr["amount"].ToString());
                    en.Price = float.Parse(dr["price"].ToString());
                    en.Category = int.Parse(dr["category"].ToString());
                    en.CreationDate = DateTime.Parse(dr["creationDate"].ToString());
                    exito = true;
                }
                dr.Close();
            }
            catch (SqlException ex) { Console.WriteLine("Product operation has failed. Error: {0}", ex.Message); }
            finally { c.Close(); }
            return exito;
        }
        public bool readNext(ENProduct en)
        {
            bool exito = false;
            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();
                // Buscamos el primero cuyo código sea mayor al actual
                SqlCommand com = new SqlCommand("SELECT TOP 1 * FROM Products WHERE code > @code ORDER BY code ASC", c);
                com.Parameters.AddWithValue("@code", en.Code);
                SqlDataReader dr = com.ExecuteReader();

                if (dr.Read())
                {
                    en.Code = dr["code"].ToString();
                    en.Name = dr["name"].ToString();
                    en.Amount = int.Parse(dr["amount"].ToString());
                    en.Price = float.Parse(dr["price"].ToString());
                    en.Category = int.Parse(dr["category"].ToString());
                    en.CreationDate = DateTime.Parse(dr["creationDate"].ToString());
                    exito = true;
                }
                dr.Close();
            }
            catch (SqlException ex) { Console.WriteLine("Product operation has failed. Error: {0}", ex.Message); }
            finally { c.Close(); }
            return exito;
        }
        public bool readPrev(ENProduct en)
        {
            bool exito = false;
            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();
                // Buscamos el código más alto entre los que son menores al actual
                SqlCommand com = new SqlCommand("SELECT TOP 1 * FROM Products WHERE code < @code ORDER BY code DESC", c);
                com.Parameters.AddWithValue("@code", en.Code);
                SqlDataReader dr = com.ExecuteReader();

                if (dr.Read())
                {
                    en.Code = dr["code"].ToString();
                    en.Name = dr["name"].ToString();
                    en.Amount = int.Parse(dr["amount"].ToString());
                    en.Price = float.Parse(dr["price"].ToString());
                    en.Category = int.Parse(dr["category"].ToString());
                    en.CreationDate = DateTime.Parse(dr["creationDate"].ToString());
                    exito = true;
                }
                dr.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
            }
            finally { c.Close(); }
            return exito;
        }
    }
}