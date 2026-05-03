namespace DVLDDataAccessLayer.DTOs
{
    public class CountryDTO
    {
        public int CountryID { get; set; }
        public string CountryName { get; set; }

        public CountryDTO() { }

        public CountryDTO(int countryID, string countryName)
        {
            CountryID = countryID;
            CountryName = countryName;
        }
    }
}
