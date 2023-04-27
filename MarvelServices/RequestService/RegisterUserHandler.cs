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
    public class RegisterUserHandler : IRequestHandler<RegisterUserRequest, RegisterUserResponse>
    {
        UserDbContext _db;

        public RegisterUserHandler(UserDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<RegisterUserResponse> Handle(RegisterUserRequest model, CancellationToken cancellationToken)
        {
            var newUser = new User()
            {
                Name = model.Username,
                Email = model.Email,
                Password = model.Password
            };
            _db.Users.Add(newUser);
            try
            {

                await _db.SaveChangesAsync();
                return new RegisterUserResponse()
                {
                    Success = "Success"
                };
            }
            catch (Exception ex)
            {
                return new RegisterUserResponse()
                {
                    Success = ex.Message
                };
            }
        }
    }
}
