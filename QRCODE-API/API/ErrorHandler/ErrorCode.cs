using QRCODE_API.Utils;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QRCODE_API.ErrorHandler
{
    public enum ErrorCode
    {
        BadRequest = 400001,

        AcessDenied = 403001,

        DBConflict = 409001,

        FileNotFound = 404001,
        DataNotFound = 404002,

        ServerError = 500001,

        Unhandled = 500999

    }
}
