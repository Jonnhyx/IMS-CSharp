﻿using System;
using System.Data;
using System.Data.OleDb;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;
using Soporte;

namespace AccesoDatos
{
    public class UserDao : ConnectionToOleDb
    {
        private string Mensaje;
        public bool Login(string user, string pass)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new OleDbCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select * from Users where LoginName=@user and Password=@pass";
                    command.Parameters.AddWithValue("@user", user);
                    command.Parameters.AddWithValue("@pass", pass);
                    command.CommandType = CommandType.Text;
                    OleDbDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            UserCache.IdUser = reader.GetInt32(0);
                            UserCache.LoginName = reader.GetString(1);
                            UserCache.Password = reader.GetString(2);
                            UserCache.FirstName = reader.GetString(3);
                            UserCache.LastName = reader.GetString(4);
                            UserCache.Position = reader.GetString(5);
                            UserCache.Email = reader.GetString(6);
                            UserCache.DNI = reader.GetString(7);
                        }
                        return true;
                    }
                    else
                        return false;
                }
            }
        }


        public string RecuperarContraseña(string dni)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new OleDbCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Select *from Users where DNI=@dni";
                    command.Parameters.AddWithValue("@dni", dni);
                    command.CommandType = CommandType.Text;
                    OleDbDataReader reader = command.ExecuteReader();
                    if (reader.Read() == true)
                    {
                        UserCache.Email = reader["Email"].ToString();
                        UserCache.FirstName = reader["FirstName"].ToString();
                        UserCache.LastName = reader["LastName"].ToString();
                        UserCache.Password = reader["Password"].ToString();
                        //EMAIL
                        EnviarEmail();

                        Mensaje = "Estimado " + UserCache.FirstName +  " " + UserCache.LastName + " , Se ha enviado su contraseña a su correo: " + UserCache.Email + ": Verifique su bandeja de entrada";
                        reader.Close();
                    }
                    else
                    {
                        Mensaje = "No existe el DNI indicado en la BBDD";
                    }
                    return Mensaje;
                }
            }
        }

        public void EnviarEmail()
        {
            //CORREO
            MailMessage Correo = new MailMessage();
            Correo.From = new MailAddress("12345@gmail.com");
            Correo.To.Add(UserCache.Email);
            Correo.Subject = ("RECUPERAR CONTRASEÑA SYSTEM");
            Correo.Body = "Hola, " + UserCache.FirstName + " " + UserCache.LastName + " Usted solicito recuperar contraseña\n Su contraseña es: " + UserCache.Password + " ";
            Correo.Priority = MailPriority.Normal;
            // SMPT
            SmtpClient ServerMail = new SmtpClient();
            ServerMail.Credentials = new NetworkCredential("12345@gmail.com", "@admin123");
            ServerMail.Host = "smtp.gmail.com";
            ServerMail.Port = 587;
            ServerMail.EnableSsl = true;
            try
            {
                ServerMail.Send(Correo);
            }
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            catch (Exception ex)
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            {

            }
            Correo.Dispose();
        }

        public void permisosUsuario()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new OleDbCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Permisos WHERE UserID=" + Soporte.UserCache.IdUser;
                    command.CommandType = CommandType.Text;
                    command.CommandType = CommandType.Text;
                    OleDbDataReader reader = command.ExecuteReader();
                    try
                    {
                        while (reader.Read())
                        {
                            UserCache.permisoProductos = reader.GetString(1);
                            UserCache.permisoVentas = reader.GetString(2);
                            UserCache.permisoClientes = reader.GetString(3);
                            UserCache.permisoCompras = reader.GetString(4);
                            UserCache.permisoProveedores = reader.GetString(5);
                            UserCache.permisoEmpleados = reader.GetString(6);
                            UserCache.permisoPagos = reader.GetString(7);
                            UserCache.permisoReportes = reader.GetString(8);
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Error al Leer la tabla de permisos");
                    }
                }
            }
        }
        public DataTable select(string tabla)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new OleDbCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select * from " + tabla;
                    command.CommandType = CommandType.Text;
                    OleDbDataAdapter Adapter = new OleDbDataAdapter();
                    Adapter.SelectCommand = command;
                    DataTable Grid = new DataTable();
                    Adapter.Fill(Grid);
                    return Grid;
                }

            }
        }

        public DataTable select(string parametro, string dato, string tabla)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new OleDbCommand())
                {
                    command.Connection = connection;
                    if ((dato == "Cantidad") | (dato == "Precio") | (dato == "UserID"))
                    {
                        
                        command.CommandText = "Select * from " + tabla + " where " + dato + "=" + parametro;
                    }
                    else
                    {
                        command.CommandText = "Select * from " + tabla + " where " + dato + "=" + '"' + parametro +'"' + ';';
                    }

                    command.CommandType = CommandType.Text;
                    OleDbDataAdapter Adapter = new OleDbDataAdapter();
                    Adapter.SelectCommand = command;
                    DataTable Grid = new DataTable();

                    try
                    {
                        Adapter.Fill(Grid);
                        
                    }
#pragma warning disable CS0168 // La variable 'e' se ha declarado pero nunca se usa
                    catch(Exception e)
#pragma warning restore CS0168 // La variable 'e' se ha declarado pero nunca se usa
                    {
                        MessageBox.Show("El parámetro introducido es erroneo");
                    }
                    return Grid;
                }

            }
        }
        public DataTable insertProductos(string producto, string nombre, string descripcion, string precio, string cantidad)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new OleDbCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "INSERT INTO Productos (IdProducto, Nombre, Descripcion, Precio, Cantidad) VALUES (" + producto  + ", '" + nombre + "'" + ", '" + descripcion + "', " + precio + ", " + cantidad + ");";
                    command.CommandType = CommandType.Text;
                    OleDbDataAdapter Adapter = new OleDbDataAdapter();
                    Adapter.SelectCommand = command;
                    try
                    {
                        command.ExecuteReader();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("El parámetro introducido es erroneo");
                    }
                }
            }
            return select("Productos");
        }

        public DataTable deleteProductos(string producto){
            using (var connection = GetConnection()){
                connection.Open();
                using (var command = new OleDbCommand()){
                    command.Connection = connection;
                    command.CommandText = "DELETE FROM Productos WHERE IdProducto ='" + producto + "'";
                    command.CommandType = CommandType.Text;
                    OleDbDataAdapter Adapter = new OleDbDataAdapter();
                    Adapter.SelectCommand = command;
                    try{
                        command.ExecuteReader();
                    }
                    catch (Exception e){
                        MessageBox.Show("El parámetro introducido es erroneo");
                    }
                }
            }
            return select("Productos");
        }

        public DataTable updateProductos(string producto, string nombre, string descripcion, string precio, string cantidad)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new OleDbCommand())
                {
                    command.Connection = connection;
                    //command.CommandText = "UPDATE Productos SET Nombre = '" + nombre + "', Descripcion= '" + descripcion + "', Precio= '" + precio + "', Cantidad= '" + cantidad + "' WHERE IdProducto = '" + producto + "'";
                    command.CommandText = "UPDATE Productos SET Nombre = '" + nombre + "', Descripcion= '" + descripcion + "', Precio= " + precio + ", Cantidad= " + cantidad + " WHERE IdProducto = '" + producto + "'";
                    command.CommandType = CommandType.Text;
                    OleDbDataAdapter Adapter = new OleDbDataAdapter();
                    Adapter.SelectCommand = command;
                    try
                    {
                        command.ExecuteReader();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("El parámetro introducido es erroneo");
                    }
                }
            }
            return select("Productos");
        }
      
    }
}
