using AccesoDatos;
using System.Data;

namespace Dominio{
    public class UserModel
    {
        UserDao userDao = new UserDao();
        public bool LoginUser(string user, string pass)
        {
            return userDao.Login(user, pass);
        }
        public string RecuPass(string dni)
        {
            string mensaje;
            mensaje = userDao.RecuperarContraseña(dni);
            return mensaje;
        }
        public void permisosUsuario()
        {
            userDao.permisosUsuario();
        }
        public DataTable select(string parametro, string dato, string tabla)
        {
            return userDao.select(parametro, dato, tabla);
        }
        public DataTable select(string tabla)
        {
            return userDao.select(tabla);
        }
        public DataTable insertProductos(string producto, string nombre, string descripcion, string precio, string cantidad)
        {
            return userDao.insertProductos(producto, nombre, descripcion, precio, cantidad);
        }
        public DataTable deleteProductos(string producto)
        {
            return userDao.deleteProductos(producto);
        }
        public DataTable updateProductos(string producto, string nombre, string descripcion, string precio, string cantidad)
        {
            return userDao.updateProductos(producto, nombre, descripcion, precio, cantidad);
        }
    }
}
