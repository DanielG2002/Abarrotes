namespace Abarrotes.Datos
{
    public class Conexion
    {
        private string cadenaSQL = string.Empty;

        public Conexion()
        {
            cadenaSQL = "Server=localhost;Database=db_abarrotes;Uid=root;Pwd=;";
        }

        public string GetCadenaSQL()
        {
            return cadenaSQL;
        }
    
}
}
