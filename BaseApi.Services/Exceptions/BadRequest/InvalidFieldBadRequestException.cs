﻿using BaseApi.Services.Exceptions.BaseExceptions;
using System;

namespace BaseApi.Services.Exceptions.BadRequest
{
    public class InvalidFieldBadRequestException : BaseBadRequestException
    {
        public InvalidFieldBadRequestException() : base() { }
        public InvalidFieldBadRequestException(string message, int customCode)
            : base(message, customCode) { }
    }
}