package be.helmo.schedholiday.model

import com.applandeo.materialcalendarview.EventDay
import java.time.LocalDate
import java.time.LocalDateTime

class Activity (
    val name:String,
    val description:String,
    val startDate: LocalDateTime,
    val endDate: LocalDateTime,
    val idHoliday: String?
) {
    override fun toString(): String {
        return "$startDate - $endDate $name $description "
    }
}