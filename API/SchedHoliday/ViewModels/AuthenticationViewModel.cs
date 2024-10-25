using SchedHoliday.Models;

namespace SchedHoliday.ViewModels
{

    public class OAuthRequest : IViewModel<OAuth>
    {

        public string Token { get; set; }

        public OAuth toModel()
        {
            return new OAuth { Token = Token };
        }
    }

    public class AuthenticationRequest : IViewModel<Authentication>
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public Authentication toModel()
        {
            return new Authentication { Username = Email, Password = Password };
        }
    }

    public class AuthenticationResponse
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }

    }



}
