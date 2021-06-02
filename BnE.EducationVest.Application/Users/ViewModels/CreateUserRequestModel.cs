using BnE.EducationVest.Domain.Users.Enums;
using System;

namespace BnE.EducationVest.Application.Users.ViewModels
{
    public class CreateUserRequestModel
    {
        public string Name { get; set; }
        public string CPF { get; set; } = null;
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public UserAddressRequestModel Address { get; set; }
        public EUserType UserType { get; set; } = EUserType.ExternalStudent;
    }

    public class UserAddressRequestModel
    {
        public string CEP { get; set; }
        public string Street { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}