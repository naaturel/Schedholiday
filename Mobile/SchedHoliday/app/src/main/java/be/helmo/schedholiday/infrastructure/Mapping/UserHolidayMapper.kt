package be.helmo.schedholiday.infrastructure.Mapping

import be.helmo.schedholiday.repository.UserHoliday.DTOUserHoliday

class UserHolidayMapper {

    fun createDTO(idHoliday : String, idUser : String) = DTOUserHoliday(listOf(idHoliday), listOf(idUser))

}