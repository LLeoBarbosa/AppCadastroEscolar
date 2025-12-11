using ACE.Domain.Abstract;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACE.Domain.Models
{
    public class Usuario : IdentityUser<Guid>
    {
        public Usuario()
        {            
        }

    }

}
