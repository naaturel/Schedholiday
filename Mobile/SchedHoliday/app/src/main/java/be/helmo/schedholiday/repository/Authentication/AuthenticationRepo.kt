package be.helmo.schedholiday.repository.Authentication

import be.helmo.schedholiday.infrastructure.AuthenticationInfra
import be.helmo.schedholiday.infrastructure.Mapping.AuthenticationMapper
import be.helmo.schedholiday.model.AuthenticationRequest
import be.helmo.schedholiday.model.AuthenticationResponse
import be.helmo.schedholiday.model.User
import be.helmo.schedholiday.repository.User.DTOUser
import kotlinx.coroutines.runBlocking

class AuthenticationRepo : IAuthenticateRepo {

    private val infra = AuthenticationInfra()
    private val mapper = AuthenticationMapper()

    override suspend fun authenticate(auth : AuthenticationRequest): AuthenticationResponse
    {
        val response = infra.authenticate(mapper.toDTOAuth(auth))
        return mapper.toModel(response)
    }

}