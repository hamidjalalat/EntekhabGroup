using Entekhab.Application.PersonSalaries.Commands;
using Entekhab.Domain.Models;
using Entekhab.Persistence.ViewModels;
using Prime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entekhab.Application.PersonSalaries
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile() : base()
        {
            CreateMap<GetPersonSalariesQueryResponseViewModel, PersonSalary>();
            CreateMap<PersonSalary, GetPersonSalariesQueryResponseViewModel>();

            CreateMap<CreatePersonSalaryCommand, PersonSalary>()
                .ForMember(des=>des.DateShamsi,opt=>opt.MapFrom(src=>src.Date))
                .ForMember(des => des.DateMiladi, opt => opt.MapFrom(src => Shamsi.ToDateTimeYYMMDD(src.Date)));
            CreateMap<PersonSalary, CreatePersonSalaryCommand>();

            CreateMap<UpdatePersonSalaryCommand, PersonSalary>()
             .ForMember(des => des.DateShamsi, opt => opt.MapFrom(src => src.Date))
             .ForMember(des => des.DateMiladi, opt => opt.MapFrom(src => Shamsi.ToDateTimeYYMMDD(src.Date)));
            CreateMap<PersonSalary, UpdatePersonSalaryCommand>();
        }
    }
}
