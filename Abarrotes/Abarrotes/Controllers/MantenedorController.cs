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