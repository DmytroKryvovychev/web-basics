using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using web_basics.data.Entities;

namespace web_basics.data.Repositories
{
    public class Dog
    {
        WebBasicsDBContext context;

        public Dog(IConfiguration configuration)
        {
            this.context = new WebBasicsDBContext(configuration);
        }

        public IEnumerable<Entities.Dog> Get()
        {
            var dogs = context.Dogs.ToList();
            return dogs;
        }

        public void Set(data.Entities.Dog dog)
        {
            context.Dogs.Add(dog);
            context.SaveChanges();

        }

    }
}
