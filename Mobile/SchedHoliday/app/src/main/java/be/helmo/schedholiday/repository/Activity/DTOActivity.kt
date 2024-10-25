package be.helmo.schedholiday.repository.Activity

import kotlinx.serialization.Serializable
import kotlinx.serialization.encodeToString
import kotlinx.serialization.json.Json

@Serializable
class DTOActivity(
    val Name:String,
    val Description:String,
    val EpochStart: Long,
    val EpochEnd: Long,
    val HolidayId: String?,
) {

    fun toJson() : String{
        return Json.encodeToString(this)
    }

}