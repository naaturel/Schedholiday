package be.helmo.schedholiday.model

import androidx.room.ColumnInfo
import androidx.room.Entity
import androidx.room.PrimaryKey

@Entity
class AuthenticationResponse(
    @PrimaryKey @ColumnInfo(name = "id") override val id: String,
    @ColumnInfo(name = "lastname") override val lastName: String,
    @ColumnInfo(name = "firstname") override val firstName: String,
    @ColumnInfo(name = "email") override val email: String,
    @ColumnInfo(name = "token") val token:String,
) : User(id, lastName, firstName, email)
{
}