package be.helmo.schedholiday.infrastructure.Mapping

import be.helmo.schedholiday.model.Holiday
import be.helmo.schedholiday.repository.Holiday.DTOHoliday
import be.helmo.schedholiday.utils.EpochConverter

class HolidayMapper {

    fun toHoliday(dto : DTOHoliday) : Holiday {
        return Holiday(
            dto.Id,
            dto.Name,
            EpochConverter.toLocalDate(dto.EpochStart),
            EpochConverter.toLocalDate(dto.EpochEnd),
            dto.Longitude,
            dto.Latitude,
            listOf()
        )
    }

    fun toDTOHoliday(holiday : Holiday) : DTOHoliday {
        return DTOHoliday(
            holiday.id,
            "",
            holiday.name,
            EpochConverter.toEpochSeconds(holiday.startDate),
            EpochConverter.toEpochSeconds(holiday.endDate),
            holiday.longitude,
            holiday.latitude
        )
    }

    fun toManyHoliday(holidaysDTO : List<DTOHoliday>) :  List<Holiday>{
        val listDTO : MutableList<Holiday> = mutableListOf()
        for(dto in holidaysDTO){
            listDTO += toHoliday(dto)
        }
        return listDTO
    }

    fun toManyDTOHoliday(holidays : List<Holiday>) : List<DTOHoliday>{
        val listDTO : MutableList<DTOHoliday> = mutableListOf()
        for(holiday in holidays){
            listDTO += toDTOHoliday(holiday)
        }
        return listDTO
    }

}