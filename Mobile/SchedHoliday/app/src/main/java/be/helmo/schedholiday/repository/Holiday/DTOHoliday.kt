package be.helmo.schedholiday.repository.Holiday

import kotlinx.serialization.Serializable
import kotlinx.serialization.encodeToString
import kotlinx.serialization.json.Json

@Serializable
class DTOHoliday(
    val Id:String,
    var CreatorId: String,
    val Name:String,
    val EpochStart: Long,
    val EpochEnd: Long,
    val Longitude:Double,
    val Latitude:Double,
)  {
    fun toJson() : String{
        return Json.encodeToString(this)
    }
}