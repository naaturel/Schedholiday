package be.helmo.schedholiday.repository.UserHoliday

import kotlinx.serialization.Serializable
import kotlinx.serialization.encodeToString
import kotlinx.serialization.json.Json

@Serializable
class DTOUserHoliday (
    val IdHoliday : List<String>,
    val IdUser : List<String>
){
    fun toJson() : String{
        return Json.encodeToString(this)
    }
}