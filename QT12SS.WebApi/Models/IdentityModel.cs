﻿//@CodeCopy
//MdStart
using System.ComponentModel.DataAnnotations;

namespace QT12SS.WebApi.Models
{
    /// <summary>
    /// The model with the identity property.
    /// </summary>
    public abstract partial class IdentityModel : Logic.IIdentifyable
    {
        /// <summary>
        /// ID of the model (primary key)
        /// </summary>
        [Key]
        public int Id { get; set; }
    }
}
//MdEnd
