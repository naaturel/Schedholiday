package be.helmo.schedholiday.infrastructure

import be.helmo.schedholiday.exception.HolidayException
import be.helmo.schedholiday.exception.UserException
import be.helmo.schedholiday.repository.Holiday.DTOHoliday
import be.helmo.schedholiday.repository.User.DTOUser
import be.helmo.schedholiday.repository.UserHoliday.DTOUserHoliday
import com.google.gson.reflect.TypeToken
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.withContext
import okhttp3.MediaType
import okhttp3.OkHttpClient
import okhttp3.Request
import okhttp3.RequestBody
import java.io.IOException

class HolidayInfrastructure : Infra() {

    private val URL = "${super.BASE_URL}Holiday"

    suspend fun createHoliday(holiday: DTOHoliday) :Boolean {


        val user = super.roomRepo.getAuthenticatedUser()
        holiday.CreatorId = user!!.id

        try{
            val client = OkHttpClient()
            val JSON = MediaType.parse("application/json; charset=utf-8")

            val formBody : RequestBody = RequestBody.create(JSON, holiday.toJson())
            val request : Request = Request.Builder()
                .addHeader(
                    "Authorization",
                    "Bearer ${user.token}")
                .url(URL)
                .post(formBody)
                .build()

            val response = withContext(Dispatchers.IO) {
                client.newCall(request).execute()
            }

            return response.isSuccessful
        }catch(e: IOException){
            throw HolidayException("Erreur pendant l'enregistrement du voyage")
        }
    }

    suspend fun getListHoliday() : List<DTOHoliday>{
        try{
            val request : Request = Request.Builder()
                .url(URL)
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
            val itemType = object : TypeToken<ArrayList<DTOHoliday>>() {}.type
            return DESERIALIZER.fromJson<ArrayList<DTOHoliday>>(holidays, itemType)

        }catch(e: IOException){
            throw HolidayException(e.message.toString())
        }
    }

    suspend fun getHoliday(idHoliday: String) : DTOHoliday{

        try{
            val request : Request = Request.Builder()
                .url("${URL}/${idHoliday}")
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
            val itemType = object : TypeToken<DTOHoliday>() {}.type
            return DESERIALIZER.fromJson(holidays, itemType)

        }catch(e: IOException){
            throw HolidayException(e.message.toString())
        }
    }

    suspend fun addUser(dto : DTOUserHoliday) : Boolean{
        try{
            val client = OkHttpClient()
            val JSON = MediaType.parse("application/json; charset=utf-8")

            val formBody : RequestBody = RequestBody.create(JSON, dto.toJson())
            val request : Request = Request.Builder()
                .addHeader(
                    "Authorization",
                    "Bearer ${super.roomRepo.getAuthenticatedUser()?.token}")
                .url(URL)
                .post(formBody)
                .build()

            val response = withContext(Dispatchers.IO) {
                client.newCall(request).execute()
            }

            return response.isSuccessful
        }catch(e: IOException){
            throw HolidayException("erreur pendant l'enregistrement du voyage")
        }
    }
}