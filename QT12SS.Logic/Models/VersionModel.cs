//@CodeCopy
//MdStart

namespace QT12SS.Logic.Models
{
    public abstract partial class VersionModel : IdentityModel, IVersionable
    {
        /// <summary>
        /// Row version of the entity.
        /// </summary>
        public virtual byte[]? RowVersion { get; set; }
    }
}
//MdEnd
