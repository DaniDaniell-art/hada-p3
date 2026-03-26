using System;
using System.Collections.Generic;
using library;

namespace proWeb
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CADCategory cadCat = new CADCategory();
                List<ENCategory> categorias = cadCat.readAll();

                if (categorias != null && categorias.Count > 0)
                {
                    ddlCategory.DataSource = categorias;
                    ddlCategory.DataTextField = "Name";
                    ddlCategory.DataValueField = "Id";
                    ddlCategory.DataBind();
                }
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                ENProduct producto = new ENProduct(
                    tbCode.Text,
                    tbName.Text,
                    int.Parse(tbAmount.Text),
                    float.Parse(tbPrice.Text),
                    int.Parse(ddlCategory.SelectedValue),
                    DateTime.Parse(tbDate.Text)
                );

                if (producto.create())
                {
                    lblMessage.Text = "Success: Product created correctly.";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblMessage.Text = "Error: Product could not be created.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Format error: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnRead_Click(object sender, EventArgs e)
        {
            try
            {
                ENProduct producto = new ENProduct();
                producto.Code = tbCode.Text;

                if (producto.read())
                {
                    tbName.Text = producto.Name;
                    tbAmount.Text = producto.Amount.ToString();
                    tbPrice.Text = producto.Price.ToString();
                    ddlCategory.SelectedValue = producto.Category.ToString();
                    tbDate.Text = producto.CreationDate.ToString("dd/MM/yyyy HH:mm:ss");

                    lblMessage.Text = "Success: Product read correctly.";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblMessage.Text = "Error: Product not found.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                ENProduct p = new ENProduct(tbCode.Text, tbName.Text, int.Parse(tbAmount.Text),
                                            float.Parse(tbPrice.Text), int.Parse(ddlCategory.SelectedValue),
                                            DateTime.Parse(tbDate.Text));
                if (p.update())
                {
                    lblMessage.Text = "Success: Product updated.";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblMessage.Text = "Error: Could not update.";
                }
            }
            catch (Exception ex) { lblMessage.Text = "Error: " + ex.Message; }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ENProduct p = new ENProduct();
            p.Code = tbCode.Text; // Leemos el código de la caja de texto

            if (p.delete())
            {
                lblMessage.Text = "Success: Product deleted.";
                lblMessage.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMessage.Text = "Error: Product not found.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void btnReadFirst_Click(object sender, EventArgs e)
        {
            ENProduct p = new ENProduct();
            if (p.readFirst())
            {
                tbCode.Text = p.Code;
                tbName.Text = p.Name;
                tbAmount.Text = p.Amount.ToString();
                tbPrice.Text = p.Price.ToString();
                ddlCategory.SelectedValue = p.Category.ToString();
                tbDate.Text = p.CreationDate.ToString("dd/MM/yyyy HH:mm:ss");
                lblMessage.Text = "Success: First product loaded.";
            }
            else
            {
                lblMessage.Text = "No products found.";
            }
        }
        protected void btnReadPrev_Click(object sender, EventArgs e) { }
        protected void btnReadNext_Click(object sender, EventArgs e)
        {
            ENProduct p = new ENProduct();
            p.Code = tbCode.Text; // Empezamos desde el código que hay en pantalla
            if (p.readNext())
            {
                tbCode.Text = p.Code;
                tbName.Text = p.Name;
                tbAmount.Text = p.Amount.ToString();
                tbPrice.Text = p.Price.ToString();
                ddlCategory.SelectedValue = p.Category.ToString();
                tbDate.Text = p.CreationDate.ToString("dd/MM/yyyy HH:mm:ss");
                lblMessage.Text = "Success: Next product loaded.";
            }
            else
            {
                lblMessage.Text = "No more products.";
            }
        }
    }
}