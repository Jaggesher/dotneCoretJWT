using System;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Collections.Generic;

namespace dotnetCoreJWT.Services
{
    public interface IJwtFactoryService
    {
        Task<String> GenerateToken(string userName, string id, IList<string> roles);

    }
}