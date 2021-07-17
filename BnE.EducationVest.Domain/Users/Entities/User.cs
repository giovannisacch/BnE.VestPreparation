using BnE.EducationVest.Domain.Common;
using BnE.EducationVest.Domain.Exam.Entities;
using BnE.EducationVest.Domain.Exam.RelationEntities;
using BnE.EducationVest.Domain.Users.Enums;
using BnE.EducationVest.Domain.Users.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public bool WasAcceptedTerms { get; private set; }
        public DateTime BirthDate { get; private set; }
        public AddressVO Address { get; private set; }
        public List<QuestionAnswer> QuestionAnswers { get; private set; }
        public ExternalUserProfile ExternalUserProfile { get; private set; }
        public List<FinalizedExam> FinalizedExams { get; private set; }
        public List<UserOptin> Optins { get; set; }
        public Guid CognitoUserId { get; private set; }
        public EUserType UserType { get; set; }
        internal User() { }
        public User(string name, string cpf, string phoneNumber, string gender, string email, 
            DateTime birthDate, AddressVO address, EUserType userType)
        {
            SetUserName(name);
            CPF = userType == EUserType.InternalStudent ? cpf : null;
            PhoneNumber = phoneNumber;
            Gender = gender;
            Email = email;
            BirthDate = birthDate;
            Address = address;
            UserType = userType;
        }
        public void SetUserName(string name)
        {
            if (name.Split(' ').Length <= 1)
                throw new DomainErrorException(ErrorConstants.USER_SHOULD_HAVE_LAST_NAME);
            this.Name = name;
        }
        public void SetCognitoUserId(Guid cognitoUserId)
        {
            CognitoUserId = cognitoUserId;
        }
        public void AcceptTerms()
        {
            WasAcceptedTerms = true;
        }
        public void AddAcceptedOptin(int optinId)
        {
            if (Optins == null)
                Optins = new List<UserOptin>();
            Optins.Add(new UserOptin(Id, optinId));
        }
        //TODO: ADICIONAR VALIDACOES
    }
}
