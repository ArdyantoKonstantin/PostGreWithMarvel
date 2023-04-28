using NpgsqlTypes;
using System.Net;

namespace MarvelEntity.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public Guid? BlobId { get; set; }
        public Blob? Blob { get; set; }
        public NpgsqlTsVector SearchVector { get; set; } = null!;
        public List<Address> Addresses { get; set; } = new List<Address>();
    }
}