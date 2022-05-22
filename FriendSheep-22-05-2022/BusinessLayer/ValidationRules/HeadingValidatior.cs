using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
  public   class HeadingValidatior:AbstractValidator<Heading>
    {
        public HeadingValidatior()
        {
            RuleFor(x => x.HeadingName).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
            RuleFor(x => x.HeadingName).MinimumLength(10).WithMessage("En Az 10 Karakter Girişi Yapınız!!!");
        }
    }
}
