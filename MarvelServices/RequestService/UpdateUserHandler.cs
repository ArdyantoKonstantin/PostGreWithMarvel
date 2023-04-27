using MarvelContract.RequestModel;
using MarvelContract.ResponseModel;
using MarvelEntity.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelServices.RequestService
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
    {
        UserDbContext _db;

        public UpdateUserHandler(UserDbContext db)
        {
            _db = db;
        }
        public async Task<UpdateUserResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var oldUser = _db.Users.Where(u => u.Id == request.Id).First();
                oldUser.Name = request.Username;
                oldUser.Password = request.Password;
                await _db.SaveChangesAsync();
                return new UpdateUserResponse()
                {
                    Success = "Success"
                };
            }
            catch (Exception ex)
            {
                return new UpdateUserResponse()
                {
                    Success = ex.Message
                };
            }
        }
    }
}
