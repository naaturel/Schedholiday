package be.helmo.schedholiday.infrastructure.Mapping

import be.helmo.schedholiday.model.Activity
import be.helmo.schedholiday.model.AuthenticationRequest
import be.helmo.schedholiday.repository.Activity.DTOActivity
import be.helmo.schedholiday.repository.User.DTOAuthenticationResponse
import be.helmo.schedholiday.utils.EpochConverter
import org.junit.Assert
import org.junit.Test
import java.time.LocalDateTime

class AuthentificationMapperTest {

    private val mapper = AuthenticationMapper()

    @Test
    fun testToModel(){
        val dto = DTOAuthenticationResponse("id", "firstname", "lastname", "email", "token")
        val response = mapper.toModel(dto)
        Assert.assertEquals(dto.Id, response.id)
        Assert.assertEquals(dto.FirstName, response.firstName)
        Assert.assertEquals(dto.LastName, response.lastName)
        Assert.assertEquals(dto.Email, response.email)
        Assert.assertEquals(dto.Token, response.token)
    }
    @Test
    fun testToDTOActivity(){
        val auth = AuthenticationRequest("username", "password")
        val dto = mapper.toDTOAuth(auth)
        Assert.assertEquals(dto.email, auth.username)
        Assert.assertEquals(dto.password, auth.password)
    }

}