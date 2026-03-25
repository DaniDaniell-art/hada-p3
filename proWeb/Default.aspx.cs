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

        protected void btnUpdate_Click(object sender, EventArgs e) { }
        protected void btnDelete_Click(object sender, EventArgs e) { }
        protected void btnReadFirst_Click(object sender, EventArgs e) { }
        protected void btnReadPrev_Click(object sender, EventArgs e) { }
        protected void btnReadNext_Click(object sender, EventArgs e) { }
    }
}