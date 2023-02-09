
namespace Clientes_API.Entities
{
    public class Address
    {
        public int AddressId { get; set; }
        public string Alias { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Active { get; set; }
        public int ClienteId { get; set; }
        public virtual Cliente? Cliente { get; set; }

        public Address()
        {
            CreatedAt= DateTime.Now;
        }
    }
}
