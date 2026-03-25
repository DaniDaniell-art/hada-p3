using System;
using System.Collections.Generic;
// ¡Muy importante añadir esta línea para poder usar las clases de tu librería!
using library; 

namespace proWeb
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // IsPostBack comprueba si es la primera vez que entramos a la página.
            // Si es la primera vez, cargamos el desplegable. Si venimos de pulsar un botón, no lo recargamos.
            if (!IsPostBack)
            {
                CADCategory cadCat = new CADCategory();
                List<ENCategory> categorias = cadCat.readAll(); 

                // Si la lista tiene datos, la vinculamos a tu DropDownList
                if(categorias != null && categorias.Count > 0)
                {
                    ddlCategory.DataSource = categorias;
                    ddlCategory.DataTextField = "Name"; // Lo que lee el usuario (ej: Computing)
                    ddlCategory.DataValueField = "Id";  // El valor numérico interno que se guarda
                    ddlCategory.DataBind();
                }
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Recogemos lo que el usuario ha escrito en las cajas de texto y lo convertimos a su tipo correspondiente
                string code = tbCode.Text;
                string name = tbName.Text;
                int amount = int.Parse(tbAmount.Text);
                float price = float.Parse(tbPrice.Text);
                int category = int.Parse(ddlCategory.SelectedValue);
                DateTime creationDate = DateTime.Parse(tbDate.Text);

                // 2. Creamos nuestro objeto Producto de la capa de negocio
                ENProduct producto = new ENProduct(code, name, amount, price, category, creationDate);

                // 3. Intentamos guardarlo en la Base de Datos
                if (producto.create())
                {
                    lblMessage.Text = "Success: Product created correctly.";
                    lblMessage.ForeColor = System.Drawing.Color.Green; // Mensaje de éxito en verde
                }
                else
                {
                    lblMessage.Text = "Error: Could not create the product.";
                    lblMessage.ForeColor = System.Drawing.Color.Red; // Mensaje de error en rojo
                }
            }
            catch (Exception ex)
            {
                // Si el usuario deja un campo vacío o pone texto donde va un número, capturamos el error aquí
                lblMessage.Text = "Format error: Please check your input data. " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        // --- LOS DEMÁS BOTONES LOS DEJAREMOS PREPARADOS PARA DESPUÉS ---

        protected void btnUpdate_Click(object sender, EventArgs e) { }

        protected void btnDelete_Click(object sender, EventArgs e) { }

        protected void btnRead_Click(object sender, EventArgs e) { }

        protected void btnReadFirst_Click(object sender, EventArgs e) { }

        protected void btnReadPrev_Click(object sender, EventArgs e) { }

        protected void btnReadNext_Click(object sender, EventArgs e) { }
    }
}