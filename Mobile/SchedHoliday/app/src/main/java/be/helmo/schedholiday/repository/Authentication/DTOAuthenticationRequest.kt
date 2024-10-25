package be.helmo.schedholiday.repository.Authentication

import kotlinx.serialization.Serializable
import kotlinx.serialization.encodeToString
import kotlinx.serialization.json.Json


@Serializable
data class DTOAuthenticationRequest(

    val Email : String,
    val Password : String
) {

    fun toJson() : String{
        return Json.encodeToString(this);
    }

}