﻿//@CodeCopy
//MdStart

namespace QT12SS.AspMvc.Models
{
    public abstract partial class VersionModel : IdentityModel
    {
        /// <summary>
        /// Row version of the entity.
        /// </summary>
        [Timestamp]
        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
    }
}
//MdEnd
