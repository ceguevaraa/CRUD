using Phonebook.Models;
using Phonebook.Requests;
using AutoMapper;

namespace Phonebook.Helpers
{
    public class AutoMapperContact : Profile
    {
        public AutoMapperContact()
        {
            CreateMap<CreateRequest, Contact>();

            CreateMap<UpdateRequest, Contact>()
    .ForAllMembers(x => x.Condition(
        (src, dest, prop) =>
        {
            // ignore both null & empty string properties
            if (prop == null) return false;
            if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

            return true;
        }
    ));
        }
    }
}
