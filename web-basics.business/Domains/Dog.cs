using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using web_basics.business.ViewModels;
using web_basics.data.Entities;
using web_basics.data.Repositories;

namespace web_basics.business.Domains
{
    public class Dog
    {
        data.Repositories.Dog repository;
        IMapper mapper;

        public Dog(IConfiguration configuration)
        {
            this.repository = new data.Repositories.Dog(configuration);
            this.mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<data.Entities.Dog, ViewModels.Dog>();
                cfg.CreateMap<ViewModels.Dog, data.Entities.Dog>();
            }).CreateMapper();
        }

        public IEnumerable<ViewModels.Dog> Get()
        {
            var dogs = repository.Get();
            return dogs.Select(dog => mapper.Map<data.Entities.Dog, ViewModels.Dog>(dog));
        }

        public void Set(business.ViewModels.Dog dog)
        {
            repository.Set(mapper.Map<business.ViewModels.Dog, data.Entities.Dog>(dog));
        }


    }
}
