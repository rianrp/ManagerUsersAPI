using Manager.Domain.Validators;
using Manager.Core.Exeptions;
using System.Collections.Generic;
using System;

namespace Manager.Domain.Entities
{
    public class User : Base
    {
        public string name { get; private set; } = "";
        public string email { get; private set; } = "";
        public string password { get; private set; } = "";

        protected User(){ }

        public User(string name, string email, string password)
        {
            this.name = name;
            this.email = email;
            this.password = password;
            _errors = new List<string>();
        }

        public void ChangeName(string Name){
            name = Name;
            Validate();
        }
        public void ChangePassword(string Password)
        {
            password = Password;
            Validate();
        }
        public void ChangeEmail(string Email){
            email = Email;
            Validate();
        }

        public override bool Validate()
        {
            var validator = new UserValidator();
            var validation = validator.Validate(this);

            if(!validation.IsValid){
                foreach(var error in validation.Errors)
                    _errors.Add(error.ErrorMessage);
                
                throw new DomainException("Alguns campos estão inválidos, por favor corrija-os! ", _errors);
            }

            return true;
        }
    }
}