package be.helmo.schedholiday.repository.User

class DTOAuthenticationResponse(
    Id: String, FirstName: String, LastName: String, Email: String, val Token:String,
): DTOUser(Id, FirstName, LastName, Email) {
}