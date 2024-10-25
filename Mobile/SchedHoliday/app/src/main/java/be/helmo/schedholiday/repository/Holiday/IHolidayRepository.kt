package be.helmo.schedholiday.repository.Holiday

import be.helmo.schedholiday.model.Holiday
import be.helmo.schedholiday.model.User
import kotlinx.coroutines.flow.Flow

interface IHolidayRepository {

    suspend fun createHoliday(holiday: Holiday) : Boolean

    suspend fun getListHoliday() : Flow<List<Holiday>>

    suspend fun getHoliday(idHoliday : String) : Holiday

    suspend fun getListUsers(idHoliday : String) : List<User>

    suspend fun addUser(idHoliday : String, idUser : String) : Boolean

    companion object {
        private var INSTANCE : HolidayRepository? = null

        fun initialize(repo:HolidayRepository){
            if(INSTANCE == null){
                INSTANCE = repo
            }
        }

        fun get() : HolidayRepository {
            return INSTANCE ?: throw IllegalStateException("HolidayRepository must be initialized")
        }

    }

}