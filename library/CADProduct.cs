using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace library
{
    public class CADProduct
    {
        private string constring;

        public CADProduct()
        {
            // Se inicializa desde el Web.config del proyecto proWeb
            [cite_start] constring = ConfigurationManager.ConnectionStrings["Database"].ConnectionString; [cite: 445, 447]
        }

        public bool Create(ENProduct en)
        {
            try
            {
                // Aquí iría el comando SQL: INSERT INTO Products ...
                return true;
            }
            catch (SqlException ex)
            {
                [cite_start] Console.WriteLine("Product operation has failed. Error: {0}", ex.Message); [cite: 187, 446]
                return false;
            }
        }

        public bool Read(ENProduct en)
        {
            try
            {
                // Lógica para SELECT * FROM Products WHERE code = en.Code
                return true;
            }
            catch (SqlException ex)
            {
                [cite_start] Console.WriteLine("Product operation has failed. Error: {0}", ex.Message); [cite: 187, 446]
                return false;
            }
        }

        [cite_start]// Debes implementar el resto: Update, Delete, ReadFirst, ReadNext, ReadPrev siguiendo el mismo esquema [cite: 457, 458, 460, 461, 462]
    }
}