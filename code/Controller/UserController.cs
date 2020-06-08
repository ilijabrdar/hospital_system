using bolnica.Controller;
using bolnica.Service;
using Model.Users;
using System;
using System.Collections.Generic;

namespace Controller
{
    public class UserController : IUserController
    {

        //private Service.IService _service;
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
           this._userService = userService;
        }

        public User Save(User entity)
        {
            return _userService.Save(entity);
        }

        public bool BlockUser(string username)
        {
            throw new NotImplementedException();
        }

        public User Login(string username, string password)
        {
            User user = _userService.Login(username, password);
            if (user == null) throw new NullReferenceException("User not found");
            else return user;
        }

        public bool Logout(User user)
        {
            throw new NotImplementedException();
        }

 

        public Feedback SendFeedback(string feedback)
        {
            throw new NotImplementedException();
        }

        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(User entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User Get(long id)
        {
            throw new NotImplementedException();
        }
    }
}