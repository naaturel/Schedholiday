package be.helmo.schedholiday.infrastructure.Mapping

import be.helmo.schedholiday.model.Holiday
import be.helmo.schedholiday.repository.Holiday.DTOHoliday
import be.helmo.schedholiday.utils.EpochConverter
import org.junit.Assert
import org.junit.Test
import java.text.SimpleDateFormat
import java.time.LocalDateTime

class HolidayMapperTest {

    private val mapper = HolidayMapper()

    @Test
    fun testToHoliday() {
        val dto = DTOHoliday("12", "test", 0,0, 0.0, 0.0)
        val holiday = mapper.toHoliday(dto)
        Assert.assertEquals(dto.Id, holiday.id)
        Assert.assertEquals(dto.Name, holiday.name)
        Assert.assertEquals(dto.EpochStart, EpochConverter.toEpochSeconds(holiday.startDate))
        Assert.assertEquals(dto.EpochEnd, EpochConverter.toEpochSeconds(holiday.endDate))
    }

    @Test
    fun testToDTOHoliday() {
        val holiday = Holiday("1", "test",LocalDateTime.now(), LocalDateTime.now(),0.0, 0.0, listOf())
        val dto = mapper.toDTOHoliday(holiday)
        Assert.assertEquals(dto.Id, holiday.id)
        Assert.assertEquals(dto.Name, holiday.name)
        Assert.assertEquals(dto.EpochStart, EpochConverter.toEpochSeconds(holiday.startDate))
        Assert.assertEquals(dto.EpochEnd, EpochConverter.toEpochSeconds(holiday.endDate))
    }

    @Test
    fun testToManyHoliday() {
        val listDTO = mutableListOf<DTOHoliday>()
        for (i in 1..4) {
            listDTO += DTOHoliday("12", "test", 0,0, 0.0, 0.0)
        }
        val listHoliday = mapper.toManyHoliday(listDTO)
        for (i in 0..3) {
            Assert.assertEquals(listDTO[i].Id, listHoliday[i].id)
            Assert.assertEquals(listDTO[i].Name, listHoliday[i].name)
            Assert.assertEquals(listDTO[i].EpochStart, EpochConverter.toEpochSeconds(listHoliday[i].startDate))
            Assert.assertEquals(listDTO[i].EpochEnd, EpochConverter.toEpochSeconds(listHoliday[i].endDate))

        }
    }
        @Test
        fun testToManyDTOHoliday() {
            val listHoliday = mutableListOf<Holiday>()
            for (i in 1..4) {
                listHoliday += Holiday("1", "test",LocalDateTime.now(), LocalDateTime.now(),0.0, 0.0, listOf())
            }
            val listDTO = mapper.toManyDTOHoliday(listHoliday)
            for (i in 0..3) {
                Assert.assertEquals(listDTO[i].Id, listHoliday[i].id)
                Assert.assertEquals(listDTO[i].Name, listHoliday[i].name)
                Assert.assertEquals(listDTO[i].EpochStart, EpochConverter.toEpochSeconds(listHoliday[i].startDate))
                Assert.assertEquals(listDTO[i].EpochEnd, EpochConverter.toEpochSeconds(listHoliday[i].endDate))

            }
        }
}