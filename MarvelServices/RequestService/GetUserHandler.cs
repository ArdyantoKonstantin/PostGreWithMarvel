using MarvelEntity.Entity;
using MarvelContract.RequestModel;
using MarvelContract.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MarvelServices.RequestService
{
    public class GetUserHandler : IRequestHandler<GetUserRequest, List<GetUserResponse>>
    {
        UserDbContext _db;

        public GetUserHandler(UserDbContext dbContext)
        {
            _db = dbContext;
        }
        public async Task<List<GetUserResponse>> Handle(GetUserRequest request, CancellationToken cancellationToken)
        {
            var userList = await _db.Users.Select(s => new GetUserResponse()
            {
                Username = s.Name,
                Email = s.Email
            }).ToListAsync();

            return userList;
        }
    }
}
