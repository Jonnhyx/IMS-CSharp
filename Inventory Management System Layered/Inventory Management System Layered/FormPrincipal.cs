using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Soporte;
using Dominio;

namespace Inventory_Management_System_Layered
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }
        private void iconCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelHeader_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void permisosUsuario()
        {
            UserModel user = new UserModel();
            user.permisosUsuario();

            if (UserCache.permisoProductos != "Sí"){
                btnPRODUCTOS.Enabled = false;
            }
            if (UserCache.permisoVentas != "Sí"){
                btnVENTAS.Enabled = false;
            }
            if (UserCache.permisoClientes != "Sí"){
                btnCLIENTES.Enabled = false;
            }
            if (UserCache.permisoCompras != "Sí"){
                btnCOMPRAS.Enabled = false;
            }
            if (UserCache.permisoProveedores != "Sí"){
                btnPROVEEDORES.Enabled = false;
            }
            if (UserCache.permisoEmpleados != "Sí"){
                btnEMPLEADOS.Enabled = false;
            }
            if (UserCache.permisoPagos != "Sí"){
                btnPAGOS.Enabled = false;
            }
            if (UserCache.permisoReportes != "Sí"){
                btnREPORTES.Enabled = false;
            }
        }

        private void AbrirFormInPanel(object formHijo)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form fh = formHijo as Form;
            fh.TopLevel = false;
            fh.FormBorderStyle = FormBorderStyle.None;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
        }

        private void iconmaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            iconmaximizar.Visible = false;
            iconrestaurar.Visible = true;
        }

        private void iconrestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            iconmaximizar.Visible = true;
            iconrestaurar.Visible = false;
        }

        private void iconMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnmenu_Click(object sender, EventArgs e)
        {
            if (MenuVertical.Width == 70)
            {
                MenuVertical.Width = 250;
            }
            else

                MenuVertical.Width = 70;
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            lblNombre.Text = UserCache.FirstName;
            lblApellido.Text = UserCache.LastName;
            lblEmail.Text = UserCache.Email;
            permisosUsuario();
        }

        private void BtnPRODUCTOS_Click(object sender, EventArgs e)
        {
            FormProductos productos = new FormProductos();
            AbrirFormInPanel(productos);
        }

       
    }
}
