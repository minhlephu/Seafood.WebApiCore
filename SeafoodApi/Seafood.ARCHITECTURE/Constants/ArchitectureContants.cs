using BCrypt.Net;
using Seafood.ARCHITECTURE.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seafood.ARCHITECTURE.Constants
{
    public class ArchitectureContants
    {
        // JWT
        public const string KEY_SECRET = "tEQ3eZqmWjWCeE4dxK28pHP#EyqpWkBc";
        public const int SIGNIN_EXPIRE_MINUTES = 1440;
        public const int SIGNIN_EXPIRE_DAY = 30;
        public const int VERIFY_TOKEN_EXPIRE_DAY = 1;

        // AUTHORIZATION
        public const string AUTHORIZE_ROLE = nameof(User.Role);
        public const string AUTHORIZE_ROLE_ADMIN = "admin";
        public const string AUTHORIZE_ROLE_USER = "user";

        // SECURITY
        public const int BCRYPT_SALT = 11;
        public const HashType BCRYPT_HASHTYPE = HashType.SHA384;

        // SESSION
        public const int SESSION_EXPIRE_SECOND = 10;
    }
}
