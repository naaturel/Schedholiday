package be.helmo.schedholiday.repository.Authentification

import be.helmo.schedholiday.model.Activity
import be.helmo.schedholiday.model.AuthenticationRequest
import be.helmo.schedholiday.model.AuthenticationResponse
import be.helmo.schedholiday.repository.Activity.ActivityRepository
import be.helmo.schedholiday.repository.Authentication.AuthenticationRepo
import io.mockk.every
import io.mockk.mockk
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.runBlocking
import kotlinx.coroutines.test.resetMain
import kotlinx.coroutines.test.setMain
import org.junit.After
import org.junit.Assert
import org.junit.Before
import org.junit.Test
import java.time.LocalDateTime

class AuthentificationRepositoryTest {

    private val mockAuthRepository = mockk<AuthenticationRepo>()

    @Before
    fun setUp() {
        Dispatchers.setMain(Dispatchers.Unconfined)

        every { runBlocking { mockAuthRepository.authenticate(AuthenticationRequest("username", "password")) } }returns AuthenticationResponse(
            "id", "lastname", "firstname", "email", "token"
        )


    }

    @After
    fun tearDown() {
        Dispatchers.resetMain()
    }

    @Test
    fun testAuthenticate() {
       /* var result : AuthenticationResponse
        runBlocking {
            result = mockAuthRepository.authenticate(AuthenticationRequest("username", "password"))
        }
        Assert.assertEquals("id", result.id)
        Assert.assertEquals("lastname", result.lastName)
        Assert.assertEquals("firstname", result.firstName)
        Assert.assertEquals("email", result.email)
        Assert.assertEquals("token", result.token)*/
    }

}