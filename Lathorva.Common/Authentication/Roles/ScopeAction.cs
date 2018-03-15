using System;
using System.Collections.Generic;
using System.Text;

namespace Lathorva.Common.Authentication.Roles
{
    /// <summary>
    /// Inspiration from https://api.slack.com/docs/oauth-scopes
    /// </summary>
    public enum ScopeAction
    {
        Unknown = 0,
        Get = 1,
        GetAll = 2,

        Post = 3,

        Put = 4,

        /// <summary>
        /// Seperate, some might not be allowed to delete resouce. Eg WebStore or admin user access. Same with post/put
        /// </summary>
        Delete = 5,
    }
}
