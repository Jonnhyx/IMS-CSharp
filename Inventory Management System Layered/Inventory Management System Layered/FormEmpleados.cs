using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;

namespace Inventory_Management_System_Layered
{
    public partial class FormEmpleados : Form
    {
        public FormEmpleados()
        {
            InitializeComponent();
        }

        private void TextUserID_Enter(object sender, EventArgs e)
        {
            if (txtUserID.Text == "UserID")
            {
                txtUserID.Text = "";
                txtUserID.ForeColor = Color.LightGray;
            }
        }

        private void TextUserID_Leave(object sender, EventArgs e)
        {
            if (txtUserID.Text == "")
            {
                txtUserID.Text = "UserID";
                txtUserID.ForeColor = Color.Silver;
            }
        }

        private void TextLoginName_Leave(object sender, EventArgs e)
        {
            if (txtLoginName.Text == "")
            {
                txtLoginName.Text = "LoginName";
                txtLoginName.ForeColor = Color.Silver;
            }
        }

        private void TextLoginName_Enter(object sender, EventArgs e)
        {
            if (txtLoginName.Text == "LoginName")
            {
                txtLoginName.Text = "";
                txtLoginName.ForeColor = Color.LightGray;
            }
        }

        private void TextPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Password";
                txtPassword.ForeColor = Color.Silver;
            }
        }

        private void TextPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.LightGray;
            }            
        }

        private void TxtFirstName_Leave(object sender, EventArgs e)
        {
            if (txtFirstName.Text == "")
            {
                txtFirstName.Text = "FirstName";
                txtFirstName.ForeColor = Color.Silver;
            }
        }

        private void TxtFirstName_Enter(object sender, EventArgs e)
        {
            if (txtFirstName.Text == "FirstName")
            {
                txtFirstName.Text = "";
                txtFirstName.ForeColor = Color.LightGray;
            }
        }

        private void TxtLastName_Leave(object sender, EventArgs e)
        {
            if (txtLastName.Text == "")
            {
                txtLastName.Text = "LastName";
                txtLastName.ForeColor = Color.Silver;
            }
        }

        private void TxtLastName_Enter(object sender, EventArgs e)
        {
            if (txtLastName.Text == "LastName")
            {
                txtLastName.Text = "";
                txtLastName.ForeColor = Color.LightGray;
            }            
        }

        private void TxtPosition_Leave(object sender, EventArgs e)
        {
            if (txtPuesto.Text == "")
            {
                txtPuesto.Text = "Puesto";
                txtPuesto.ForeColor = Color.Silver;
            }
        }

        private void TxtPosition_Enter(object sender, EventArgs e)
        {
            if (txtPuesto.Text == "Puesto")
            {
                txtPuesto.Text = "";
                txtPuesto.ForeColor = Color.LightGray;
            }            
        }

        private void TxtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                txtEmail.Text = "Email";
                txtEmail.ForeColor = Color.Silver;
            }
        }

        private void TxtEmail_Enter(object sender, EventArgs e)
        {
            if (txtEmail.Text == "Email")
            {
                txtEmail.Text = "";
                txtEmail.ForeColor = Color.LightGray;
            }            
        }

        private void TxtDNI_Leave(object sender, EventArgs e)
        {
            if (txtDNI.Text == "")
            {
                txtDNI.Text = "DNI";
                txtDNI.ForeColor = Color.Silver;
            }
        }

        private void TxtDNI_Enter(object sender, EventArgs e)
        {
            if (txtDNI.Text == "DNI")
            {
                txtDNI.Text = "";
                txtDNI.ForeColor = Color.LightGray;
            }            
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            UserModel user = new UserModel();
            string tabla = "Users";

            dataGridView1.ClearSelection();

            if ((txtUserID.Text != "") && (txtUserID.Text != "UserID"))
            {
                dataGridView1.DataSource = user.select(txtUserID.Text, "UserID", tabla);
            }
            else if ((txtLoginName.Text != "") && (txtLoginName.Text != "LoginName"))
            {
                dataGridView1.DataSource = user.select(txtLoginName.Text, "LoginName", tabla);
            }
            else if ((txtPassword.Text != "") && (txtPassword.Text != "Password"))
            {
                dataGridView1.DataSource = user.select(txtPassword.Text, "Password", tabla);
            }
            else if ((txtFirstName.Text != "") & (txtFirstName.Text != "FirstName"))
            {
                dataGridView1.DataSource = user.select(txtFirstName.Text, "FirstName", tabla);
            }
            else if ((txtLastName.Text != "") & (txtLastName.Text != "LastName"))
            {
                dataGridView1.DataSource = user.select(txtLastName.Text, "LastName", tabla);
            }
            else if ((txtPuesto.Text != "") && (txtPuesto.Text != "Puesto"))
            {
                dataGridView1.DataSource = user.select(txtPuesto.Text, "Puesto", tabla);
            }
            else if ((txtEmail.Text != "") & (txtEmail.Text != "Email"))
            {
                dataGridView1.DataSource = user.select(txtEmail.Text, "Email", tabla);
            }
            else if ((txtDNI.Text != "") & (txtDNI.Text != "DNI"))
            {
                dataGridView1.DataSource = user.select(txtDNI.Text, "DNI", tabla);
            }
            else
            {
                dataGridView1.DataSource = user.select(tabla);
            }

            dataGridView1.AutoResizeColumns();
            txtUserID.Text = "UserID";
            txtLoginName.Text = "LoginName";
            txtPassword.Text = "Password";
            txtFirstName.Text = "FirstName";
            txtLastName.Text = "LastName";
            txtPuesto.Text = "Puesto";
            txtEmail.Text = "Email";
            txtDNI.Text = "DNI";
        }

        private void BtnAñadir_Click(object sender, EventArgs e)
        {

        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {

        }
    }
}
