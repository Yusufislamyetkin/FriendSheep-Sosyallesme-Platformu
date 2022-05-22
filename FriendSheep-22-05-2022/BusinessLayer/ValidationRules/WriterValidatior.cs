using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public class WriterValidatior : AbstractValidator<Writer>
    {
        public WriterValidatior()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Bu Kısım Boş Bırakılamaz");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar Soyadı Boş Bırakılamaz");
            RuleFor(x => x.WriterEmail).NotEmpty().WithMessage("Yazar Mail Boş Bırakılamaz");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Yazar Hakkında Kısmı Boş Bırakılamaz");

            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Yazar Adı Minimum 2 Karakter Olmak Zorundadır");
            RuleFor(x => x.WriterSurname).MinimumLength(2).WithMessage("Yazar Soyadı  Minimum 2 Karakter Olmak Zorundadır");
            RuleFor(x => x.WriterEmail).EmailAddress().WithMessage("Yazar Mail Girişi Hatalı");
            RuleFor(x => x.WriterAbout).MaximumLength(25).WithMessage("Yazar Hakkında Kısmı Maksimum 25 Karakter Olabilir");


        }
    }
}
