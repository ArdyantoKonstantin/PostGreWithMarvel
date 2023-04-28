using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelEntity.Entity
{
    public class Blob
    {
        public Guid BlobId { get; set; }
        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public List<User> ListOfUsers { get; set; } = new List<User>();
        public string? MIME { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
