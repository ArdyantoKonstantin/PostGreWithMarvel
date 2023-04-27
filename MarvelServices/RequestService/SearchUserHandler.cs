using MarvelContract.RequestModel;
using MarvelContract.ResponseModel;
using MarvelEntity.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelServices.RequestService
{
    public class SearchUserHandler : IRequestHandler<SearchUserRequest, SearchUserResponse>
    {
        UserDbContext _db;

        public SearchUserHandler(UserDbContext db)
        {
            _db = db;
        }
        public async Task<SearchUserResponse> Handle(SearchUserRequest request, CancellationToken cancellationToken)
        {
            //var res = await _db.Users.FirstOrDefaultAsync(Queryable => Queryable.SearchVector.Matches(request.Username));
            var user = await _db.Users.
                Where(u => u.SearchVector.
                Matches(request.Username)).
                Select(u => new SearchUserResponse
            {
                Username = u.Name
            }).FirstOrDefaultAsync();
            if (user == null)
            {
                return new SearchUserResponse()
                {
                    Username = "Username not found"
                };
            }
            return user;
        }
    }
}
