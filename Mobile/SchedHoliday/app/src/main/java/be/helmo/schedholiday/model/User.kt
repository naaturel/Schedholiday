package be.helmo.schedholiday.model

import androidx.room.ColumnInfo
import androidx.room.Entity
import androidx.room.PrimaryKey


open class User(
    open val id:String,
    open val lastName:String,
    open val firstName:String,
    open val email:String,
)