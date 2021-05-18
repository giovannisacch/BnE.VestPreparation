using BnE.EducationVest.Domain.Common;
using BnE.EducationVest.Domain.Users.ValueObjects;
using System;

namespace BnE.EducationVest.Domain.Users.Entities
{
    public class User : EntityBase
    {
        public string Name { get; private set; }
        //IGNORAR NO EF, NAO SALBAR NO BANNCO
        public string CPF { get; private set; }
        public string  PhoneNumber { get; private set; }
        public string Gender { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public AddressVO Address { get; private set; }
        public string CognitoUserId { get; set; }
        public bool IsTeacher { get; set; }
        internal User() { }
        public User(string name, string cpf, string phoneNumber, string gender, string email, 
            DateTime birthDate, AddressVO address, bool isTeacher)
        {
            Name = name;
            CPF = cpf;
            PhoneNumber = phoneNumber;
            Gender = gender;
            Email = email;
            BirthDate = birthDate;
            Address = address;
            IsTeacher = isTeacher;
        }

        //TODO: ADICIONAR VALIDACOES
    }
}
