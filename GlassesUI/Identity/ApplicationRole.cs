using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GlassesUI.Identity
{
    public class ApplicationRole : IdentityRole
    {
        public string Description { get; set; }

        public ApplicationRole()
        {
            
        }
        //Role ismni ve acıklamansını dişardan alacaz
        public ApplicationRole(string roleName,string description)
        {
            this.Description = description;
        }
    }
}