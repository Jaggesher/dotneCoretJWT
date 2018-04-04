using System;
using System.Threading.Tasks;
using System.Security.Claims;

namespace dotnetCoreJWT.Services
{
    public interface IJwtFactoryService
    {
       Task<String> GenerateToken(string userName, string id);
       
    }
}