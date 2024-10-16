namespace Talbat.Core.Entites.identity
{
    public class Address
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string AppuserId { get; set; } //forjenkey

        public Appuser appusers { get; set; }

    }
}