package be.helmo.schedholiday.infrastructure

import be.helmo.schedholiday.exception.HolidayException
import be.helmo.schedholiday.repository.User.DTOUser
import com.google.gson.reflect.TypeToken
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.withContext
import okhttp3.OkHttpClient
import okhttp3.Request
import java.io.IOException

class UserHolidayInfra : Infra() {

    private val URL = "${super.BASE_URL}UserHoliday"

    suspend fun getListUsers(idHoliday : String) : List<DTOUser>{
        try{
            val request : Request = Request.Builder()
                    .url("$URL/holiday/$idHoliday")
                    .addHeader(
                            "Authorization",
                            "Bearer ${super.roomRepo.getAuthenticatedUser()?.token}")
                    .build()

            val client = OkHttpClient()
            val response = withContext(Dispatchers.IO) {
                client.newCall(request).execute()
            }

            if(!response.isSuccessful) throw IOException("Response probably unsuccessful. Is authorization token valid ?")

            val holidays: String? = response.body()?.string()
            val itemType = object : TypeToken<ArrayList<DTOUser>>() {}.type
            val users : List<DTOUser> = DESERIALIZER.fromJson(holidays, itemType)
            return users

        }catch(e: IOException){
            throw HolidayException(e.message.toString())
        }
    }

}