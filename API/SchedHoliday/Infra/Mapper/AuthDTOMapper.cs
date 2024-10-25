using SchedHoliday.Models;
using SchedHoliday.Repo.Auth;

namespace SchedHoliday.Infra.Mapper
{
    public class AuthDTOMapper : IMapper<Authentication, DTOAuth>
    {
        public Authentication From(DTOAuth src)
        {
            return new Authentication { Username = src.Email, Password = src.Password };
        }

        public DTOAuth From(Authentication src)
        {
            return new DTOAuth { Email = src.Username, Password = src.Password };
        }

        public IEnumerable<Authentication> FromMany(IEnumerable<DTOAuth> src)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DTOAuth> FromMany(IEnumerable<Authentication> src)
        {
            throw new NotImplementedException();
        }
    }

    public class OAuthDTOMapper : IMapper<OAuth, DTOOAuth>
    {
        public OAuth From(DTOOAuth src)
        {
            return new OAuth { Token = src.Token };
        }

        public DTOOAuth From(OAuth src)
        {
            return new DTOOAuth { Token = src.Token };
        }

        public IEnumerable<OAuth> FromMany(IEnumerable<DTOOAuth> src)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DTOOAuth> FromMany(IEnumerable<OAuth> src)
        {
            throw new NotImplementedException();
        }
    }

}
