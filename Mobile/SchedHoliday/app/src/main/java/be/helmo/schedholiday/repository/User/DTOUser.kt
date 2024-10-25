package be.helmo.schedholiday.repository.User

import kotlinx.serialization.Serializable
import kotlinx.serialization.encodeToString
import kotlinx.serialization.json.Json
@Serializable
open class DTOUser(
    val Id:String,
    val FirstName:String,
    val LastName:String,
    val Email:String,
)   {
    fun toJson() : String{
        return Json.encodeToString(this)
    }
}