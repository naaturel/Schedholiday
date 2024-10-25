package be.helmo.schedholiday.repository.User

import androidx.room.Dao
import androidx.room.Insert
import androidx.room.OnConflictStrategy
import androidx.room.Query
import be.helmo.schedholiday.model.AuthenticationResponse
import be.helmo.schedholiday.model.User
import kotlinx.coroutines.flow.Flow

@Dao
interface AuthDAO {

    @Query("SELECT * FROM AuthenticationResponse WHERE id = :id")
    fun getById(id : String): Flow<AuthenticationResponse>

    @Query("SELECT * FROM AuthenticationResponse")
    suspend fun get(): AuthenticationResponse

    @Insert(onConflict = OnConflictStrategy.REPLACE)
    suspend fun add(auth : AuthenticationResponse)

}