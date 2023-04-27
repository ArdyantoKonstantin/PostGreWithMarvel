using MarvelContract.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelContract.ResponseModel
{
    public class CursorPaginationResponse
    {
        public List<CursorPaginationModel>? Users { get; set; }
        public string? NextCursor { get; set; }
        public string? PrevCursor { get; set; }
    }
}
