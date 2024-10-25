package be.helmo.schedholiday.infrastructure.Mapping


import be.helmo.schedholiday.model.Activity
import be.helmo.schedholiday.repository.Activity.DTOActivity
import be.helmo.schedholiday.utils.EpochConverter.Companion.toEpochSeconds
import org.junit.Assert.assertEquals
import org.junit.Test
import java.text.SimpleDateFormat
import java.time.LocalDateTime

class ActivityMapperTest {

    private val mapper = ActivityMapper()
    @Test
    fun testToActivity(){
        val dto = DTOActivity("12", "test", 0,0,"12/12/2012")
        val activity = mapper.toActivity(dto)
        assertEquals(dto.Name, activity.name)
        assertEquals(dto.Description, activity.description)
        assertEquals(dto.EpochStart, toEpochSeconds(activity.startDate))
        assertEquals(dto.EpochEnd, toEpochSeconds(activity.endDate))
    }
    @Test
    fun testToDTOActivity(){
        val activity = Activity("12", "test", LocalDateTime.now(), LocalDateTime.now(), "id")
        val dto = mapper.toDTOActivity(activity)
        assertEquals(dto.Name, activity.name)
        assertEquals(dto.Description, activity.description)
        assertEquals(dto.EpochStart, toEpochSeconds(activity.startDate))
        assertEquals(dto.EpochEnd, toEpochSeconds(activity.endDate))
    }
    @Test
    fun testToManyActivity(){
        val listDTO = mutableListOf<DTOActivity>()
        for(i in 1..4){
            listDTO += DTOActivity("12 $i", "test $i", 0,0, "$i")
        }
        val listActivity = mapper.toManyActivity(listDTO)
        for(i in 0..3){
            assertEquals(listDTO[i].Name, listActivity[i].name)
            assertEquals(listDTO[i].Description, listActivity[i].description)
            assertEquals(listDTO[i].EpochStart, toEpochSeconds(listActivity[i].startDate))
            assertEquals(listDTO[i].EpochEnd, toEpochSeconds(listActivity[i].endDate))
            assertEquals(listDTO[i].HolidayId, listActivity[i].idHoliday)
        }

    }
    @Test
    fun testToManyDTOActivity(){
        val listActivity = mutableListOf<Activity>()
        for(i in 1..4){
            listActivity += Activity("12 $i", "test $i", LocalDateTime.now(), LocalDateTime.now(), "$i")
        }
        val listDTO = mapper.toManyDTOActivity(listActivity)
        for(i in 0..3){
            assertEquals(listDTO[i].Name, listActivity[i].name)
            assertEquals(listDTO[i].Description, listActivity[i].description)
            assertEquals(listDTO[i].EpochStart, toEpochSeconds(listActivity[i].startDate))
            assertEquals(listDTO[i].EpochEnd, toEpochSeconds(listActivity[i].endDate))
            assertEquals(listDTO[i].HolidayId, listActivity[i].idHoliday)
        }
    }

}