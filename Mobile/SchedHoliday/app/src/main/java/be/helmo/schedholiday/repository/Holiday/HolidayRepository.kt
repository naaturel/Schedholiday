package be.helmo.schedholiday.repository.Holiday

import be.helmo.schedholiday.model.Holiday
import be.helmo.schedholiday.infrastructure.HolidayInfrastructure
import be.helmo.schedholiday.infrastructure.Mapping.HolidayMapper
import be.helmo.schedholiday.infrastructure.Mapping.UserHolidayMapper
import be.helmo.schedholiday.infrastructure.Mapping.UserMapper
import be.helmo.schedholiday.infrastructure.UserHolidayInfra
import be.helmo.schedholiday.model.User
import kotlinx.coroutines.flow.Flow
import kotlinx.coroutines.flow.flowOf

class HolidayRepository : IHolidayRepository{

    private val holiadyInfra = HolidayInfrastructure()
    private val userHolidaInfra = UserHolidayInfra()
    private val holidayMapper = HolidayMapper()
    private val userMapper = UserMapper()
    private val userHolidayMapper = UserHolidayMapper()
    override suspend fun createHoliday(holiday: Holiday) = holiadyInfra.createHoliday(holidayMapper.toDTOHoliday(holiday))

    override suspend fun getListHoliday() : Flow<List<Holiday>> {
        val holidays = holidayMapper.toManyHoliday(holiadyInfra.getListHoliday())
        return flowOf(holidays)
    }

    override suspend fun getHoliday(idHoliday : String) = holidayMapper.toHoliday(holiadyInfra.getHoliday(idHoliday))

    override suspend fun getListUsers(idHoliday : String) : List<User> = userMapper.toManyUser(userHolidaInfra.getListUsers(idHoliday))

    override suspend fun addUser(idHoliday : String, idUser : String) : Boolean = holiadyInfra.addUser(userHolidayMapper.createDTO(idHoliday, idUser))

}