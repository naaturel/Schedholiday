package be.helmo.schedholiday.repository

import androidx.room.Database
import androidx.room.RoomDatabase
import be.helmo.schedholiday.model.AuthenticationResponse
import be.helmo.schedholiday.repository.User.AuthDAO

@Database(entities = [AuthenticationResponse::class], version = 1)
abstract class RoomDB : RoomDatabase() {

    abstract fun authDAO(): AuthDAO

}