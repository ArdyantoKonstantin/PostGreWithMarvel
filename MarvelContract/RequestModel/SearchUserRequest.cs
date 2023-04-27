using MarvelContract.ResponseModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelContract.RequestModel
{
    public class SearchUserRequest : IRequest<SearchUserResponse>
    {
        public string? Username { get; set; }
    }
}
