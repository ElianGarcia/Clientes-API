namespace Clientes_API.Entities
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Cedula { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }

        public virtual List<Address>? Addresses { get; set; }
    }
}
