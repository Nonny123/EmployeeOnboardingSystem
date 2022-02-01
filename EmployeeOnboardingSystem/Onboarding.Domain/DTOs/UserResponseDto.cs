namespace OnBoarding.Infrastructure.Interfaces
{
	public class UserResponseDto
	{
		public string userId { get; set; }
		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		public string LastName { get; set; }
		public string Gender { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public string PhoneNumber2 { get; set; }
		public string DateOfBirth { get; set; }
		public string Avatar { get; set; }
		public string ResidentialAddress { get; set; }
		public string CityOfResidence { get; set; }
		public string StateofResidence { get; set; }
		public string StateofOrigin { get; set; }
		public string CountryOfOrigin { get; set; }
	}
}