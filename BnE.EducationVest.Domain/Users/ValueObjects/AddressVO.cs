namespace BnE.EducationVest.Domain.Users.ValueObjects
{
    public class AddressVO
    {
        public string CEP { get; private set; }
        public string Street { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Number { get; private set; }

        internal AddressVO() { }
        public AddressVO(string cep, string street, string neighborhood, string city, 
                         string state, string number)
        {
            CEP = cep;
            Street = street;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Number = number;
        }

        public override string ToString()
        {
            return $"{Street}, {Number} CEP: {CEP}";
        }
    }
}
