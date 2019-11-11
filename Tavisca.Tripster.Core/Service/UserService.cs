using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Tavisca.Tripster.Contracts.Service;
using Tavisca.Tripster.Core.Validation;
using Tavisca.Tripster.Data.Models;
using Tavisca.Tripster.MongoDB.UnitOfWork;

namespace Tavisca.Tripster.Core.Service
{
    public class UserService : IUserService
    {   
        private UserUnitOfWork _userUnitofWork;
        private Validator<User> _validator;
        public UserService(UserUnitOfWork userUnitofWork)
        {
            _validator = new Validator<User>();
            _userUnitofWork = userUnitofWork;
        }
        public void Add(User user)
        {
            _userUnitofWork.User.UpdateUser(user.Email,user);
        }

        public void Delete(string email)
        {
            _userUnitofWork.User.Delete(email);
        }

        public TransferObject<User> Get(string email)
        {
            var user = _userUnitofWork.User.Get(email);
            _validator.Entity = user;
             var transferObject = _validator.GetTransferObject();
            return transferObject;
        }

        public IEnumerable<User> GetAll()
        {
            return _userUnitofWork.User.GetAll();
        }

        public void Update(string email, User user)
        {
            _userUnitofWork.User.Update(email, user);
        }
    }
}
