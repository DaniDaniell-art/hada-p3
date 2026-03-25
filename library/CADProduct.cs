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
            // Más adelante configuraremos este nombre en el Web.config
            constring = ConfigurationManager.ConnectionStrings["miconexion"].ToString();
        }

        public bool create(ENProduct en)
        {
            bool exito = false;
            try
            {
                // Aquí irá el código SQL en el futuro
                exito = true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
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