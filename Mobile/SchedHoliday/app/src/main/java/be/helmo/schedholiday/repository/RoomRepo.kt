package be.helmo.schedholiday.repository

import android.content.Context
import androidx.room.Room
import be.helmo.schedholiday.model.AuthenticationResponse

private const val DATABASE_NAME = "cachingDB"
class RoomRepo private constructor(context : Context) {

    private val database : RoomDB = Room.databaseBuilder(
        context.applicationContext,
        RoomDB::class.java,
        DATABASE_NAME
    ).build()

    private val authDAO = database.authDAO()

    suspend fun addAuthenticatedUser(u : AuthenticationResponse){
        authDAO.add(u)
    }

    suspend fun getAuthenticatedUser() : AuthenticationResponse? {
        return authDAO.get()
    }

    companion object {
        private var INSTANCE: RoomRepo? = null
        fun initialize(context: Context) {
            if (INSTANCE == null) {
                INSTANCE = RoomRepo(context)
            }
        }

        fun get(): RoomRepo {
            return INSTANCE ?:
            throw IllegalStateException("Room repository must be initialized")
        }
    }
}