package be.helmo.schedholiday.repository.Message

import kotlinx.serialization.Serializable
import kotlinx.serialization.encodeToString
import kotlinx.serialization.json.Json

@Serializable
class DTOMessage(
    val Content:String,
    val Epoch: Long,
    var Sender : String,
    val HolidayId : String
)  {
    fun toJson() : String{
        return Json.encodeToString(this)
    }

}