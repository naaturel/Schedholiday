package be.helmo.schedholiday.repository.Message

import be.helmo.schedholiday.model.Holiday
import be.helmo.schedholiday.model.Message
import be.helmo.schedholiday.model.User
import be.helmo.schedholiday.repository.Holiday.HolidayRepository
import io.mockk.every
import io.mockk.mockk
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.flow.flowOf
import kotlinx.coroutines.runBlocking
import kotlinx.coroutines.test.resetMain
import kotlinx.coroutines.test.setMain
import org.junit.After
import org.junit.Assert
import org.junit.Before
import org.junit.Test
import java.time.LocalDateTime

class MessageRepositoryTest {

    private val mockMessageRepository = mockk<MessageRepository>()

    @Before
    fun setUp() {
        Dispatchers.setMain(Dispatchers.Unconfined)

        every { runBlocking { mockMessageRepository.getMessages("id") } } returns listOf(
            Message("content", LocalDateTime.now(), "sender", "id"),
            Message("content", LocalDateTime.now(), "sender", "id"),
            Message("content", LocalDateTime.now(), "sender", "id")
        )

        every { runBlocking { mockMessageRepository.sendMessage(Message("content", LocalDateTime.now(), "sender", "id")) } } returns
                true

    }

    @After
    fun tearDown() {
        Dispatchers.resetMain()
    }

    @Test
    fun testGetMessages() {
        var list : List<Message>
        runBlocking {
            list = mockMessageRepository.getMessages("id")
        }
        Assert.assertEquals(3, list.count())
    }

    @Test
    fun testSendMessage(){
        /*val message = Message("content", LocalDateTime.now(), "sender", "id")
        runBlocking {
            Assert.assertTrue(mockMessageRepository.sendMessage(message))
        }*/

    }

}