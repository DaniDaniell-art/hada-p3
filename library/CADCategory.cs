using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace library
{
    public class CADCategory
    {
        private string constring;

        public CADCategory()
        {
            constring = ConfigurationManager.ConnectionStrings["miconexion"].ToString();
        }

        public bool read(ENCategory en)
        {
            // Dejamos esto preparado, aunque el importante ahora es readAll
            return false;
        }

        public List<ENCategory> readAll()
        {
            List<ENCategory> lista = new List<ENCategory>();
            SqlConnection c = new SqlConnection(constring);

            try
            {
                c.Open();
                // Comando SQL para obtener todas las categorías
                SqlCommand com = new SqlCommand("SELECT id, name FROM Categories", c);
                SqlDataReader dr = com.ExecuteReader();

                // Leemos fila a fila y creamos los objetos ENCategory
                while (dr.Read())
                {
                    ENCategory cat = new ENCategory();
                    cat.Id = int.Parse(dr["id"].ToString());
                    cat.Name = dr["name"].ToString();
                    lista.Add(cat);
                }
                dr.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Category operation has failed. Error: {0}", ex.Message);
            }
            finally
            {
                c.Close(); // Siempre hay que cerrar la conexión
            }

            return lista;
        }
    }
}