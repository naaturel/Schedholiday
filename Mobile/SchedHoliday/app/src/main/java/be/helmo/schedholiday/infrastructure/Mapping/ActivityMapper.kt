package be.helmo.schedholiday.infrastructure.Mapping

import be.helmo.schedholiday.model.Activity
import be.helmo.schedholiday.repository.Activity.DTOActivity
import be.helmo.schedholiday.utils.EpochConverter

class ActivityMapper {
    fun toActivity(dto : DTOActivity) : Activity {
        return Activity(
            dto.Name,
            dto.Description,
            EpochConverter.toLocalDate(dto.EpochStart),
            EpochConverter.toLocalDate(dto.EpochEnd),
            dto.HolidayId
        )
    }

    fun toDTOActivity(activity : Activity) :  DTOActivity{
        return DTOActivity(
            activity.name,
            activity.description,
            EpochConverter.toEpochSeconds(activity.startDate),
            EpochConverter.toEpochSeconds(activity.endDate),
            activity.idHoliday
        )
    }

    fun toManyActivity(activitiesDTO : List<DTOActivity>) :  List<Activity>{
        val listDTO : MutableList<Activity> = mutableListOf()
        for(dtoA in activitiesDTO){
            listDTO += toActivity(dtoA)
        }
        return listDTO
    }

    fun toManyDTOActivity(activities : List<Activity>) : List<DTOActivity>{
        val listDTO : MutableList<DTOActivity> = mutableListOf()
        for(act in activities){
            listDTO += toDTOActivity(act)
        }
        return listDTO
    }



}