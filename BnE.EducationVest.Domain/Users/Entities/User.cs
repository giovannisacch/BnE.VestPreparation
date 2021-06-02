using BnE.EducationVest.Domain.Common;
using BnE.EducationVest.Domain.Exam.Entities;
using BnE.EducationVest.Domain.Users.Enums;
using BnE.EducationVest.Domain.Users.ValueObjects;
using System;
using System.Collections.Generic;

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
        public List<QuestionAnswer> QuestionAnswers { get; private set; }
        public ExternalUserProfile ExternalUserProfile { get; private set; }
        public Guid CognitoUserId { get; private set; }
        public EUserType UserType { get; set; }
        internal User() { }
        public User(string name, string cpf, string phoneNumber, string gender, string email, 
            DateTime birthDate, AddressVO address, EUserType userType)
        {
            Name = name;
            CPF = userType == EUserType.InternalStudent ? cpf : null;
            PhoneNumber = phoneNumber;
            Gender = gender;
            Email = email;
            BirthDate = birthDate;
            Address = address;
            UserType = userType;
        }
        
        public void SetCognitoUserId(Guid cognitoUserId)
        {
            CognitoUserId = cognitoUserId;
        }
        //TODO: ADICIONAR VALIDACOES
    }
}
