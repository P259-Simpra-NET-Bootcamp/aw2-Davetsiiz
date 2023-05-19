using FluentValidation;
using SimpApi.Data.Domain;
using System.Numerics;

namespace SimpApi.Operation;

public class StaffValidator : AbstractValidator<Staff>
{

	public StaffValidator()
	{
		RuleFor(x => x.FirstName)
			.NotEmpty().WithMessage("Name field cannot be empty")
			.MaximumLength(30).WithMessage("Name field must be less than 30 characters.")
			.MinimumLength(2).WithMessage("Name field must be more than 2 characters.");

		RuleFor(x => x.LastName)
			.NotEmpty().WithMessage("LastName field cannot be empty")
			.MaximumLength(30).WithMessage("LastName field must be less than 30 characters.")
			.MinimumLength(2).WithMessage("LastName field must be more than 2 characters.");

		RuleFor(x => x.Email)
			.NotEmpty().WithMessage("Email field cannot be empty")
			.MaximumLength(30).WithMessage("Email field must be less than 30 characters.")
			.MinimumLength(2).WithMessage("Email field must be more than 2 characters.")
			.EmailAddress().WithMessage("A valid email is required");
			 

		

		RuleFor(x => x.Phone)
			.NotEmpty().WithMessage("Phone field cannot be empty")
			.MaximumLength(11).WithMessage("Phone field must be less than 11 characters.")
			.MinimumLength(11).WithMessage("Phone field must be more than 11 characters.")
			.Must(x => x.All(char.IsDigit)).WithMessage("Phone field must contain only numeric characters.")
			.When(x => !string.IsNullOrEmpty(x.Phone)); ;

		RuleFor(x => x.DateOfBirth)
			.NotEmpty().WithMessage("DateOfBirth field cannot be empty");

		RuleFor(x => x.AddressLine1).NotEmpty().WithMessage("AddressLine field cannot be empty")
			.MaximumLength(50).WithMessage("AddressLine field must be less than 50 characters.")
			.MinimumLength(15).WithMessage("AddressLine field must be more than 15 characters.");

		RuleFor(x => x.City)
			.NotEmpty().WithMessage("City field cannot be empty")
			.MaximumLength(20).WithMessage("City field must be less than 20 characters.")
			.MinimumLength(3).WithMessage("City field must be more than 3 characters.");

		RuleFor(x => x.Country)
			.NotEmpty().WithMessage("Country field cannot be empty")
			.MaximumLength(20).WithMessage("Country field must be less than 20 characters.")
			.MinimumLength(3).WithMessage("Country field must be more than 3 characters.");

		RuleFor(x => x.Province)
			.NotEmpty().WithMessage("Province field cannot be empty")
			.MaximumLength(20).WithMessage("Province field must be less than 20 characters.")
			.MinimumLength(3).WithMessage("Province field must be more than 3 characters.");

	}
}
