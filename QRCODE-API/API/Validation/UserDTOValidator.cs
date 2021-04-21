
using FluentValidation;

using QRCODE_API.API.DTO;

namespace QRCODE_API.API.Validation
{
    public class UserDTOValidator : AbstractValidator<UserDTO>
    {
        public UserDTOValidator()
        {
            RuleSet("Update", () =>
            {
                RuleFor(u => u.ID).NotNull().GreaterThan(0);
            });

            RuleFor(u => u.FULLNAME).NotEmpty().Length(1, 255);
            RuleFor(u => u.USERNAME).NotEmpty().Length(1, 255);
            RuleFor(u => u.PASSWORD).NotEmpty().Length(1, 255);
            RuleFor(u => u.PHONE_NUMBER).NotEmpty().Length(1, 14)
                .Matches("^[0-9]{3}-([0-9]{3}|[0-9]{4})-[0-9]{4}$");
            RuleFor(u => u.EMAIL).NotEmpty().Length(1, 255);

            RuleFor(u => u.ROLE_ID).NotNull();
        }
    }
}
