using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;

namespace CapaPresentacion
{
    public partial class FormProductos : Form
    {
        public FormProductos()
        {
            InitializeComponent();
        }

        private void txtProducto_Enter(object sender, EventArgs e)
        {
            if (txtProducto.Text == "IdProducto")
            {
                txtProducto.Text = "";
                txtProducto.ForeColor = Color.LightGray;
            }
        }
        private void txtProducto_Leave(object sender, EventArgs e)
        {
            if (txtProducto.Text == "")
            {
                txtProducto.Text = "IdProducto";
                txtProducto.ForeColor = Color.Silver;
            }
        }

        private void TxtNombre_Leave(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                txtNombre.Text = "Nombre";
                txtNombre.ForeColor = Color.Silver;
            }
        }
        private void TxtNombre_Enter(object sender, EventArgs e)
        {
            if (txtNombre.Text == "Nombre")
            {
                txtNombre.Text = "";
                txtNombre.ForeColor = Color.LightGray;
            }
        }

        private void TxtDescripcion_Leave(object sender, EventArgs e)
        {
            if (txtDescripcion.Text == "")
            {
                txtDescripcion.Text = "Descripcion";
                txtDescripcion.ForeColor = Color.Silver;
            }
        }
        private void TxtDescripcion_Enter(object sender, EventArgs e)
        {
            if (txtDescripcion.Text == "Descripcion")
            {
                txtDescripcion.Text = "";
                txtDescripcion.ForeColor = Color.LightGray;
            }
        }

        private void TxtPrecio_Leave(object sender, EventArgs e)
        {
            if (txtPrecio.Text == "")
            {
                txtPrecio.Text = "Precio";
                txtPrecio.ForeColor = Color.Silver;
            }
            if (txtPrecio.Text.Contains(','))
            {
                txtPrecio.Text = "Precio";
                txtPrecio.ForeColor = Color.Silver;
                MessageBox.Show("Debes introducir el precio con '.' y no con ',' en el caso de ser decimal");
            }
        }
        private void TxtPrecio_Enter(object sender, EventArgs e)
        {
            if (txtPrecio.Text == "Precio")
            {
                txtPrecio.Text = "";
                txtPrecio.ForeColor = Color.LightGray;
            }
        }

        private void TxtCantidad_Leave(object sender, EventArgs e)
        {
            if (txtCantidad.Text == "")
            {
                txtCantidad.Text = "Cantidad";
                txtCantidad.ForeColor = Color.Silver;
            }
        }
        private void TxtCantidad_Enter(object sender, EventArgs e)
        {
            if (txtCantidad.Text == "Cantidad")
            {
                txtCantidad.Text = "";
                txtCantidad.ForeColor = Color.LightGray;
            }
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            UserModel user = new UserModel();

            dataGridView1.ClearSelection();

            if ((txtProducto.Text != "") && (txtProducto.Text != "IdProducto"))
            {
                dataGridView1.DataSource = user.selectProductos(txtProducto.Text, "IdProducto");
            }
            else if ((txtNombre.Text != "") && (txtNombre.Text != "Nombre"))
            {
                dataGridView1.DataSource = user.selectProductos(txtNombre.Text, "Nombre");
            }
            else if ((txtDescripcion.Text != "") && (txtDescripcion.Text != "Descripcion"))
            {
                dataGridView1.DataSource = user.selectProductos(txtDescripcion.Text, "Descripcion");
            }
            else if ((txtPrecio.Text != "") & (txtPrecio.Text != "Precio"))
            {
                dataGridView1.DataSource = user.selectProductos(txtPrecio.Text, "Precio");
            }
            else if ((txtCantidad.Text != "") & (txtCantidad.Text != "Cantidad"))
            {
                dataGridView1.DataSource = user.selectProductos(txtCantidad.Text, "Cantidad");
            }
            else
            {
                dataGridView1.DataSource = user.selectProductos();
            }

            dataGridView1.AutoResizeColumns();
            txtProducto.Text = "IdProducto";
            txtNombre.Text = "Nombre";
            txtDescripcion.Text = "Descripcion";
            txtPrecio.Text = "Precio";
            txtCantidad.Text = "Cantidad";
        }

        private void BtnAñadir_Click(object sender, EventArgs e)
        {
            UserModel user = new UserModel();
            dataGridView1.ClearSelection();

            if ((txtProducto.Text == "") | (txtProducto.Text == "IdProducto")){
                MessageBox.Show("Debes Introducir un IdProducto");
            }
            else if ((txtNombre.Text == "") | (txtNombre.Text == "Nombre")){
                MessageBox.Show("Debes Introducir un Nombre");
            }
            else if ((txtDescripcion.Text == "") | (txtDescripcion.Text == "Descripcion")){
                MessageBox.Show("Debes Introducir una Descripcion");
            }
            else if ((txtPrecio.Text == "") | (txtPrecio.Text == "Precio")){
                MessageBox.Show("Debes Introducir un Precio");
            }
            else if ((txtCantidad.Text == "") | (txtCantidad.Text == "Cantidad")){
                MessageBox.Show("Debes Introducir una Cantidad");
            }
            else{
                dataGridView1.DataSource = user.insertProductos(txtProducto.Text.ToUpper(), txtNombre.Text.ToUpper(), txtDescripcion.Text.ToUpper(), txtPrecio.Text.ToUpper(), txtCantidad.Text.ToUpper());
            }
            dataGridView1.AutoResizeColumns();
            txtProducto.Text = "IdProducto";
            txtNombre.Text = "Nombre";
            txtDescripcion.Text = "Descripcion";
            txtPrecio.Text = "Precio";
            txtCantidad.Text = "Cantidad";
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            UserModel user = new UserModel();
            dataGridView1.ClearSelection();

            if ((txtProducto.Text == "") | (txtProducto.Text == "IdProducto"))
            {
                MessageBox.Show("Debes Introducir un IdProducto");
            }
            else
            {
                dataGridView1.DataSource = user.deleteProductos(txtProducto.Text);
            }
            dataGridView1.AutoResizeColumns();
            txtProducto.Text = "IdProducto";
            txtNombre.Text = "Nombre";
            txtDescripcion.Text = "Descripcion";
            txtPrecio.Text = "Precio";
            txtCantidad.Text = "Cantidad";
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            UserModel user = new UserModel();
            dataGridView1.ClearSelection();

            if ((txtProducto.Text == "") | (txtProducto.Text == "IdProducto"))
            {
                MessageBox.Show("Debes Introducir un IdProducto");
            }
            else if ((txtNombre.Text == "") | (txtNombre.Text == "Nombre"))
            {
                MessageBox.Show("Debes Introducir un Nombre");
            }
            else if ((txtDescripcion.Text == "") | (txtDescripcion.Text == "Descripcion"))
            {
                MessageBox.Show("Debes Introducir una Descripcion");
            }
            else if ((txtPrecio.Text == "") | (txtPrecio.Text == "Precio"))
            {
                MessageBox.Show("Debes Introducir un Precio");
            }
            else if ((txtCantidad.Text == "") | (txtCantidad.Text == "Cantidad"))
            {
                MessageBox.Show("Debes Introducir una Cantidad");
            }
            else
            {
                dataGridView1.DataSource = user.updateProductos(txtProducto.Text.ToUpper(), txtNombre.Text.ToUpper(), txtDescripcion.Text.ToUpper(), txtPrecio.Text.ToUpper(), txtCantidad.Text.ToUpper());
            }
            dataGridView1.AutoResizeColumns();
            txtProducto.Text = "IdProducto";
            txtNombre.Text = "Nombre";
            txtDescripcion.Text = "Descripcion";
            txtPrecio.Text = "Precio";
            txtCantidad.Text = "Cantidad";
        }
    }
}
