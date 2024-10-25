package be.helmo.schedholiday.infrastructure.Mapping

import be.helmo.schedholiday.model.AuthenticationRequest
import be.helmo.schedholiday.model.AuthenticationResponse
import be.helmo.schedholiday.model.User
import be.helmo.schedholiday.repository.Authentication.DTOAuthenticationRequest
import be.helmo.schedholiday.repository.User.DTOAuthenticationResponse

class AuthenticationMapper {

    fun toDTOAuth(auth : AuthenticationRequest) : DTOAuthenticationRequest{
        return DTOAuthenticationRequest(auth.username, auth.password)
    }

    fun toModel(dtoAuth : DTOAuthenticationResponse) : AuthenticationResponse{
        return AuthenticationResponse(
            dtoAuth.Id,
            dtoAuth.LastName,
            dtoAuth.FirstName,
            dtoAuth.Email,
            dtoAuth.Token)
    }

}