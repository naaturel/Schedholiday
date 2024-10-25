package be.helmo.schedholiday.repository.User

import be.helmo.schedholiday.model.Message
import be.helmo.schedholiday.model.User
import be.helmo.schedholiday.repository.Message.MessageRepository
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

class UserRepositoryTest {

    private val mockUserRepository = mockk<UserRepository>()

    @Before
    fun setUp() {
        Dispatchers.setMain(Dispatchers.Unconfined)

        every { runBlocking { mockUserRepository.getUser("email") } } returns User(
            "id", "lastname", "firstname", "email"
        )

    }

    @After
    fun tearDown() {
        Dispatchers.resetMain()
    }
    @Test
    fun getUser(){
        runBlocking{
            val user = mockUserRepository.getUser("email")
            Assert.assertEquals("id", user?.id)
            Assert.assertEquals("lastname", user?.lastName)
            Assert.assertEquals("firstname", user?.firstName)
            Assert.assertEquals("email", user?.email)

        }

    }
}