using MySql.Data.MySqlClient;
using Abarrotes.Models;
using System.Data.SqlClient;
using System.Data;

using MySql.Data.MySqlClient;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

using System.IO;

namespace Abarrotes.Datos
{
    public class PersonaDatos
    {
        private string connectionString = "server=localhost;port=3306;database=db_abarrotes;user=root;password=;";

        public List<AbarrotesModels> ListarProductos()
        {
            var oListaProductos = new List<AbarrotesModels>();

            using (var conexion = new MySqlConnection(connectionString))
            {
                conexion.Open();

                MySqlCommand cmd = new MySqlCommand("CALL sp_productos()", conexion);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var producto = new AbarrotesModels()
                        {
                            Producto = reader["nombre_producto"].ToString(),
                            Descripcion = reader["descripcion"].ToString(),
                            Marca = reader["marca"].ToString(),
                            Precio = reader["precio"].ToString(),
                            Imagen = "/Images/" + reader["imagen"].ToString()
                        };

                        oListaProductos.Add(producto);
                    }
                }
            }

            return oListaProductos;
        }


    
    }
}
