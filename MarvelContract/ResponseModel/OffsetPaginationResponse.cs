using MarvelContract.RequestModel;
using MarvelEntity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelContract.ResponseModel
{
    public class OffsetPaginationResponse
    {
        public List<GetUserOffsetPaginationModel>? Users { get; set; }
        public int TotalData { get; set; }
    }
}
