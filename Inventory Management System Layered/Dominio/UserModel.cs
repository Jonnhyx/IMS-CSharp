using AccesoDatos;
using System.Data;

namespace Dominio
{
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
        public DataTable selectProductos(string parametro, string dato)
        {
            return userDao.selectProductos(parametro, dato);
        }
        public DataTable selectProductos()
        {
            return userDao.selectProductos();
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
