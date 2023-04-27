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
    public class DeleteUserHandler : IRequestHandler<DeleteUserRequest, DeleteUserResponse>
    {
        UserDbContext _db;

        public DeleteUserHandler(UserDbContext dbContext)
        {
            _db = dbContext;
        }
        public async Task<DeleteUserResponse> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            var userToDelete = await _db.Users.Where(w => w.Id == request.Id).FirstOrDefaultAsync();
            if (userToDelete == null)
            {
                return new DeleteUserResponse()
                {
                    Success = "Fail"
                };
            }
            _db.Users.Remove(userToDelete);
            await _db.SaveChangesAsync();
            return new DeleteUserResponse()
            {
                Success = "Success"
            };
        }
    }
}
