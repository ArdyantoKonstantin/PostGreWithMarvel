using MarvelContract.ResponseModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelContract.RequestModel
{
    public class CursorPaginationRequest : IRequest<CursorPaginationResponse>
    {
        public int NextId { get; set; }
        public int PrevId { get; set; }
        public int Limit { get; set; }
    }
}
