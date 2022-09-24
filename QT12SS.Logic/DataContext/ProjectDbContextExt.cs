using QT12SS.Logic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QT12SS.Logic.DataContext
{
    partial class ProjectDbContext
    {
        public DbSet<Logic.Entities.SocialSecurity> SocialSecuritySet { get; set; }

        partial void GetDbSet<E>(ref DbSet<E>? dbSet, ref bool handled) where E : IdentityEntity
        {
            if(typeof(E) == typeof(Logic.Entities.SocialSecurity))
            {
                dbSet = SocialSecuritySet as DbSet<E>;
                handled = true;
            }    
        }
    }
}
