using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Dominio;
using Soporte;

namespace CapaPresentacion
{
    public partial class FormPass : Form
    {
        public FormPass()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void Btncerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLogin formlogin = new FormLogin();
            formlogin.Show();
        }

        private void Btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void FormPass_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Panel1_MouseDown_1(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void TxtDni_Leave(object sender, EventArgs e)
        {
            if (txtDni.Text == "")
            {
                txtDni.Text = "Introduce el DNI";
                txtDni.ForeColor = Color.Silver;
            }
        }

        private void TxtDni_Enter(object sender, EventArgs e)
        {
            if (txtDni.Text == "Introduce el DNI" | txtDni.Text == "No existe el DNI indicado en la BBDD")
            {
                txtDni.Text = "";
                txtDni.ForeColor = Color.LightGray;
            }
        }
        
        private void BtnPass_Click(object sender, EventArgs e)
        {
            if (txtDni.Text != "Username" && txtDni.TextLength > 7)
            {
                UserModel user = new UserModel();
                txtDni.Text = user.RecuPass(txtDni.Text);
            }
                
        }
    }
}
