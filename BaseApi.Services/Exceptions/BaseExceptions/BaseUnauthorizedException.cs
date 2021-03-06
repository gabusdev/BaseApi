using System;
using System.Net;

namespace BaseApi.Services.Exceptions.BaseExceptions
{
    public class BaseUnauthorizedException : CustomBaseException
    {
        public BaseUnauthorizedException(string message = null, int customCode = 0) : base()
        {
            HttpCode = (int)HttpStatusCode.Unauthorized;
            CustomCode = 401000 + (Convert.ToBoolean(customCode) ? customCode : 0);
            CustomMessage = message ?? CustomCode.ToString();
        }
    }
}