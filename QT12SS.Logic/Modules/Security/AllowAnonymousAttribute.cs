//@CodeCopy
//MdStart
#if ACCOUNT_ON
using System;

namespace QT12SS.Logic.Modules.Security
{
    [AttributeUsage(AttributeTargets.Method)]
    internal partial class AllowAnonymousAttribute : AuthorizeAttribute
    {
        public AllowAnonymousAttribute()
            : base(false)
        {

        }
    }
}
#endif
//MdEnd
