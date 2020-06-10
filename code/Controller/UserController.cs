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
            return user;
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
            _userService.Delete(entity);
        }

        public void Edit(User entity)
        {
            _userService.Edit(entity);
        }

        public IEnumerable<User> GetAll()
        {
            return _userService.GetAll();
        }

        public User Get(long id)
        {
            return _userService.Get(id);
        }

        public bool IsPasswordValid(string password)
        {
            throw new NotImplementedException();
        }

        public bool IsUsernamedValid(string username)
        {
            throw new NotImplementedException();
        }

        public bool IsPasswordValid(string password)
        {
            throw new NotImplementedException();
        }

        public bool IsUsernamedValid(string username)
        {
            throw new NotImplementedException();
        }
    }
}