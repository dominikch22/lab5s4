using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5s4
{
    class ContactContex : DbContext
    {
        public DbSet<Person> Persons;
        public DbSet<Address> Addresses;

        protected override void OnConfiguration(DbContextOptionsBuilder ) { 
        
        }
            
            }
}
