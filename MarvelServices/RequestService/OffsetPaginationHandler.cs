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
    public class OffsetPaginationHandler : IRequestHandler<OffsetPaginationRequest, OffsetPaginationResponse>
    {
        UserDbContext _db;

        public OffsetPaginationHandler(UserDbContext dbContext)
        {
            _db = dbContext;
        }
        public async Task<OffsetPaginationResponse> Handle(OffsetPaginationRequest request, CancellationToken cancellationToken)
        {
            var query = _db.Users;
            var user = await query.
                Skip(request.Limit * request.Offset).
                Take(request.Limit).
                Select(s => new GetUserOffsetPaginationModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                    Password = s.Password,
                    Email = s.Email
                }).
                ToListAsync();
            var totalData = await query.CountAsync();

            return new OffsetPaginationResponse()
            {
                Users = user,
                TotalData = totalData
            };
        }
    }
}
