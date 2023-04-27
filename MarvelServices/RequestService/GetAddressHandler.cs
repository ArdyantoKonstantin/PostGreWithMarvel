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
    public class GetAddressHandler : IRequestHandler<GetAddressRequest, List<GetAddressResponse>>
    {
        UserDbContext _db;

        public GetAddressHandler(UserDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<List<GetAddressResponse>> Handle(GetAddressRequest request, CancellationToken cancellationToken)
        {
            var addresses = await(from a in _db.Address
                                  join u in _db.Users
                                  on a.UserId equals u.Id
                                  select new GetAddressResponse()
                                  {
                                      Address = a.AddressName,
                                      Username = u.Name
                                  }).AsNoTracking().ToListAsync();
            return addresses;
        }
    }
}
