﻿
using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using web_basics.business.ViewModels;

namespace web_basics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogController : ControllerBase
    {
        business.Domains.Dog domain;

        public DogController(IConfiguration configuration)
        {
            this.domain = new business.Domains.Dog(configuration);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var dogs = this.domain.Get();
            return Ok(dogs);
        }

        [HttpPost]
        public IActionResult Set([FromBody] business.ViewModels.Dog dog)
        {
            this.domain.Set(dog);
            return Ok(dog);
        }


    }
}
