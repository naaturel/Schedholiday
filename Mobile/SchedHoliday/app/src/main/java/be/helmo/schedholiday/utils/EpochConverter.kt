package be.helmo.schedholiday.utils

import java.time.Instant
import java.time.LocalDate
import java.time.LocalDateTime
import java.time.ZoneId
import java.time.format.DateTimeFormatter


class EpochConverter {

    companion object{

        fun toLocalDate(epoch: Long): LocalDateTime {
            val instant = Instant.ofEpochSecond(epoch)
            val zoneId = ZoneId.systemDefault()
            return instant.atZone(zoneId).toLocalDateTime();
        }

        fun toEpochSeconds(date : LocalDateTime) : Long{
            val zoneId = ZoneId.systemDefault();
            return date.atZone(zoneId).toEpochSecond()
        }

        fun toLocalDateTime(date: String): LocalDateTime {
            val formatter = DateTimeFormatter.ofPattern("dd/MM/yyyy")
            return LocalDate.parse(date, formatter).atStartOfDay()
        }

    }

}