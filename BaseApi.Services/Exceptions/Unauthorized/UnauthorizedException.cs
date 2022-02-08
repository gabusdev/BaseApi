using BaseApi.Services.Exceptions.BaseExceptions;
using Microsoft.Extensions.Localization;
using System;

namespace BaseApi.Services.Exceptions.Unauthorized
{
    public class UnauthorizedException : BaseUnauthorizedException
    {
        public UnauthorizedException(string message, int customCode) 
            : base(message, customCode) { }
        public UnauthorizedException() : base() { }
    }
}