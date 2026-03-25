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

                // 1. Comprobamos si ya existe un producto con ese Code (Requisito de la práctica)
                SqlCommand comCheck = new SqlCommand("SELECT COUNT(*) FROM Products WHERE code = @code", c);
                comCheck.Parameters.AddWithValue("@code", en.Code);
                int count = (int)comCheck.ExecuteScalar();

                if (count == 0) // Si es 0, no existe, así que podemos insertarlo
                {
                    // 2. Preparamos el INSERT INTO
                    SqlCommand com = new SqlCommand("INSERT INTO Products (name, code, amount, price, category, creationDate) VALUES (@name, @code, @amount, @price, @category, @creationDate)", c);

                    // 3. Asignamos los valores de forma segura (evita inyecciones SQL)
                    com.Parameters.AddWithValue("@name", en.Name);
                    com.Parameters.AddWithValue("@code", en.Code);
                    com.Parameters.AddWithValue("@amount", en.Amount);
                    com.Parameters.AddWithValue("@price", en.Price);
                    com.Parameters.AddWithValue("@category", en.Category);
                    com.Parameters.AddWithValue("@creationDate", en.CreationDate);

                    com.ExecuteNonQuery(); // Ejecutamos la inserción
                    exito = true;
                }
                else
                {
                    // Si ya existe, imprimimos el error por consola
                    Console.WriteLine("Product operation has failed. Error: A product with this Code already exists.");
                }
            }
            catch (SqlException ex)
            {
                // Requisito de la práctica: Mostrar error por consola exactamente con este formato
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
                exito = false;
            }
            finally
            {
                c.Close(); // Cerramos conexión siempre
            }

            return exito;
        }

        public bool update(ENProduct en) { return false; }
        public bool delete(ENProduct en) { return false; }
        public bool read(ENProduct en) { return false; }
        public bool readFirst(ENProduct en) { return false; }
        public bool readNext(ENProduct en) { return false; }
        public bool readPrev(ENProduct en) { return false; }
    }
}