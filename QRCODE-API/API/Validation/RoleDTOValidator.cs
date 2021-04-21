using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FluentValidation;

using QRCODE_API.DTO;

namespace QRCODE_API.API.Validation
{
    public class RoleDTOValidator : AbstractValidator<RoleDTO>
    {
        public RoleDTOValidator()
        {
            RuleSet("Update", () =>
            {
                RuleFor(x => x.ID).NotNull().GreaterThan(0);
            });

            RuleFor(x => x.ROLE_NAME).NotEmpty().Length(1, 50);

        }
    }
}
