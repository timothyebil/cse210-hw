using System;

namespace OnlineOrdering
{
    // Handles validation, data isolation, and formatting of address data
    public class Address
    {
        private string _streetAddress;
        private string _city;
        private string _stateOrProvince;
        private string _country;

        public Address(string streetAddress, string city, string stateOrProvince, string country)
        {
            _streetAddress = streetAddress;
            _city = city;
            _stateOrProvince = stateOrProvince;
            _country = country;
        }

        public bool IsInUSA()
        {
            return _country.Trim().Equals("USA", StringComparison.OrdinalIgnoreCase) || 
                   _country.Trim().Equals("United States", StringComparison.OrdinalIgnoreCase);
        }

        public string GetFormattedAddress()
        {
            return $"{_streetAddress}\n{_city}, {_stateOrProvince}\n{_country}";
        }
    }
}
