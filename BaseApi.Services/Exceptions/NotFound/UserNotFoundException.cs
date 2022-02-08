using BaseApi.Services.Exceptions.BaseExceptions;
using Microsoft.Extensions.Localization;
using System;

namespace BaseApi.Services.Exceptions.NotFound
{
    public class UserNotFoundException : BaseNotFoundException
    {
        public UserNotFoundException(string message, int customCode)
            : base(message, customCode) {}
        public UserNotFoundException() : base() {}
    }
}