package be.helmo.schedholiday.repository.Holiday

import be.helmo.schedholiday.model.Activity
import be.helmo.schedholiday.model.Holiday
import be.helmo.schedholiday.model.User
import be.helmo.schedholiday.repository.Activity.ActivityRepository
import io.mockk.every
import io.mockk.mockk
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.flow.Flow
import kotlinx.coroutines.flow.collect
import kotlinx.coroutines.flow.count
import kotlinx.coroutines.flow.flowOf
import kotlinx.coroutines.flow.toList
import kotlinx.coroutines.runBlocking
import kotlinx.coroutines.test.resetMain
import kotlinx.coroutines.test.setMain
import org.junit.After
import org.junit.Assert
import org.junit.Before
import org.junit.Test
import java.time.LocalDateTime

class HolidayRepositoryTest {

    private val mockActivityRepository = mockk<HolidayRepository>()

    @Before
    fun setUp() {
        Dispatchers.setMain(Dispatchers.Unconfined)

        every { runBlocking { mockActivityRepository.getListHoliday() } } returns flowOf(listOf(
            Holiday("id","name", LocalDateTime.now(), LocalDateTime.now(), 0.0, 0.0, listOf()),
            Holiday("id","name", LocalDateTime.now(), LocalDateTime.now(), 0.0, 0.0, listOf()),
            Holiday("id","name", LocalDateTime.now(), LocalDateTime.now(), 0.0, 0.0, listOf())
        ))

        every { runBlocking { mockActivityRepository.getHoliday("id") } } returns Holiday(
            "id","name", LocalDateTime.now(), LocalDateTime.now(), 0.0, 0.0, listOf())

        every { runBlocking { mockActivityRepository.getListUsers("id") } } returns listOf(
            User("id","name", "de", "email") ,
            User("id","name", "de", "email") ,
            User("id","name", "de", "email")
        )

    }

    @After
    fun tearDown() {
        Dispatchers.resetMain()
    }

    @Test
    fun testGetHoliday(){
        var result : Holiday
        runBlocking {
            result = mockActivityRepository.getHoliday("id")
            Assert.assertEquals("id", result.id)
            Assert.assertEquals("name", result.name)
        }
    }

    @Test
    fun testGetListHoliday(){
        var result : Flow<List<Holiday>>
        runBlocking {
            result = mockActivityRepository.getListHoliday()
            Assert.assertEquals(3, result.toList().get(0).count())
        }
    }

    @Test
    fun testGetListUser(){
        var result : List<User>
        runBlocking {
            result = mockActivityRepository.getListUsers("id")
        }
        Assert.assertEquals(3, result.count())
    }

}