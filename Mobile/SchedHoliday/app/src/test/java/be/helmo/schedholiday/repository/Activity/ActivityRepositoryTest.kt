package be.helmo.schedholiday.repository.Activity

import be.helmo.schedholiday.model.Activity
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

class ActivityRepositoryTest {

    private val mockActivityRepository = mockk<ActivityRepository>()

    @Before
    fun setUp() {
        Dispatchers.setMain(Dispatchers.Unconfined)

        every { runBlocking { mockActivityRepository.getActivities("id") } } returns listOf(
            Activity("name", "de", LocalDateTime.now(), LocalDateTime.now(), "id") ,
            Activity("name", "de", LocalDateTime.now(), LocalDateTime.now(), "id") ,
            Activity("name", "de", LocalDateTime.now(), LocalDateTime.now(), "id")
        )

    }

    @After
    fun tearDown() {
        Dispatchers.resetMain()
    }
    @Test
    fun testGetActivities(){
        var result : List<Activity>
        runBlocking {
            result = mockActivityRepository.getActivities("id")
        }
        Assert.assertEquals(3, result.count())
    }


}