﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Essen.Models;
using Essen.Models.Entities;
using Microsoft.AspNet.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Essen.Controllers
{
  [Route("api/[controller]")]
  public class UserController : Controller
  {
    private DataContext data;

    public UserController(DataContext d)
    {
      data = d;
    }

    // GET: api/values
    [HttpGet]
    public IEnumerable<User> Get()
    {
      return data.Users;
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public User Get(int id)
    {
      return (from x in data.Users
              where x.UserID == id
              select x).FirstOrDefault();
    }

    // POST api/values
    [HttpPost]
    public void Post([FromBody] User user)
    {
      data.Users.Add(user);
      data.SaveChanges();
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}