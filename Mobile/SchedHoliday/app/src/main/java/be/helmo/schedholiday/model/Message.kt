package be.helmo.schedholiday.model

import java.time.LocalDateTime

class Message(
    val content:String,
    val date:LocalDateTime,
    val sender : String,
    val holidayId : String
) {
}