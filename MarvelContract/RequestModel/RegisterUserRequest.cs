﻿using MarvelContract.ResponseModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelContract.RequestModel
{
    public class RegisterUserRequest : IRequest<RegisterUserResponse>
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public Guid? BlobId { get; set; }
    }
}
