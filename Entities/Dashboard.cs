namespace Clientes_API.Entities
{
    public class Dashboard
    {
        public int TotalClientesActivos { get; set; }
        public int TotalDirecciones { get; set; }
        public int TotalClientesInactivos { get; set; }
        
        /// <summary>
        /// store the list of Clientes that have more than 1 address
        /// </summary>
        public int TotalClientesMasDirecciones { get; set; }
    }
}
