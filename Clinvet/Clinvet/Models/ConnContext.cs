﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Clinvet.Models
{
    public class ConnContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ConnContext() : base("name=ConnContext")
        {
        }

        public System.Data.Entity.DbSet<Clinvet.Models.Usuario> Usuarios { get; set; }

        public System.Data.Entity.DbSet<Clinvet.Models.Funcionario> Funcionarios { get; set; }
    }
}
