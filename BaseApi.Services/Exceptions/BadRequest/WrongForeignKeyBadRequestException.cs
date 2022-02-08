using BaseApi.Services.Exceptions.BaseExceptions;
using Microsoft.Extensions.Localization;
using System;

namespace BaseApi.Services.Exceptions.BadRequest
{
    public class WrongForeignKeyBadRequestException : BaseBadRequestException
    {
        public WrongForeignKeyBadRequestException() : base() {}
        public WrongForeignKeyBadRequestException(string message, int customCode) 
            : base(message, customCode) { }
    }
}