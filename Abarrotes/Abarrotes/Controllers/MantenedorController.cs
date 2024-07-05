using Microsoft.AspNetCore.Mvc;
using Abarrotes.Datos;
using Abarrotes.Models;
using System.Data.SqlClient;
using System.Data;
using System.Text; 
using MySql.Data.MySqlClient;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using System.Security.Cryptography;
namespace Abarrotes.Controllers
{
    public class MantenedorController : Controller
    {
        private string connectionString = "server=localhost;port=3306;database=db_abarrotes;user=root;password=;";

        PersonaDatos _PersonaDatos = new PersonaDatos();







        public IActionResult Guardar() { 
          return View();
        }
        [HttpPost]
        public bool Guardar(AbarrotesModels oAbarrotes, IFormFile imagen, [FromServices] IWebHostEnvironment env)
        {
            bool rpta;

            try
            {
                using (var conexion = new MySqlConnection(connectionString))
                {
                    conexion.Open();

                    if (imagen != null && imagen.Length > 0)
                    {
                        string nombreArchivo = Path.GetFileName(imagen.FileName);
                        string rutaImagen = Path.Combine(env.WebRootPath, "Images", nombreArchivo);
                        string rutaImagenRelativa = Path.Combine("Images", nombreArchivo);

                        using (var fileStream = new FileStream(rutaImagen, FileMode.Create))
                        {
                            imagen.CopyTo(fileStream);
                        }

                        oAbarrotes.Imagen = "/" + rutaImagenRelativa;
                    }

                    // Resto del código para guardar los datos del producto en la base de datos
                    MySqlCommand cmd = new MySqlCommand("sp_add_productos", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@producto", oAbarrotes.Producto);
                    cmd.Parameters.AddWithValue("@descripcion", oAbarrotes.Descripcion);
                    cmd.Parameters.AddWithValue("@marca", oAbarrotes.Marca);
                    cmd.Parameters.AddWithValue("@precio", oAbarrotes.Precio);
                    cmd.Parameters.AddWithValue("@imagen", oAbarrotes.Imagen);

                    cmd.ExecuteNonQuery();
                }

                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }

            return rpta;
        }
        public IActionResult Login()
        {
            return View();
        }

       public IActionResult Abarrote()
        {
            var oLista = _PersonaDatos.ListarProductos();
            return View(oLista); 
        }
 

 



 
        


         
     

        private readonly PersonaDatos _personaDatos;




        [HttpPost]
        public ActionResult Login(AbarrotesModels oUsuario)
        {
            using (var conexion = new MySqlConnection(connectionString))
            {
                conexion.Open();

                MySqlCommand cmd = new MySqlCommand("sp_login", conexion);
                cmd.Parameters.AddWithValue("@id2", oUsuario.Usuario);
                cmd.Parameters.AddWithValue("@pass", oUsuario.Password);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {


                        return RedirectToAction("Abarrote", "Mantenedor");
                    }
                    else
                    {
                        TempData["Mensaje"] = "Usuario no encontrado"; 
                    }
                }
            }

            return RedirectToAction("Login", "Mantenedor");
        } 
    }
}