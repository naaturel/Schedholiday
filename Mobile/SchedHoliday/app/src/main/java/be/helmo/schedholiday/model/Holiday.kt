package be.helmo.schedholiday.model

import java.time.LocalDateTime

class Holiday(
    val id:String,
    val name:String,
    val startDate: LocalDateTime,
    val endDate:LocalDateTime,
    val longitude:Double,
    val latitude:Double,
    val activities: List<Activity>?
) {

    fun getFormattedDate() : String{
        return "Du ${startDate.dayOfMonth}/${startDate.monthValue}/${startDate.year} " +
        "au ${endDate.dayOfMonth}/${endDate.monthValue}/${endDate.year}"
    }
}