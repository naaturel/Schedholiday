package be.helmo.schedholiday.infrastructure

import be.helmo.schedholiday.exception.ActivityException
import be.helmo.schedholiday.infrastructure.Mapping.ActivityMapper
import be.helmo.schedholiday.model.Activity
import be.helmo.schedholiday.repository.Activity.DTOActivity
import com.google.gson.reflect.TypeToken
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.withContext
import okhttp3.FormBody
import okhttp3.MediaType
import okhttp3.OkHttpClient
import okhttp3.Request
import okhttp3.RequestBody
import java.io.IOException

class ActivityInfrastructure : Infra() {

    private val URL = super.BASE_URL + "Activity"

    suspend fun getActivities(id : String) : List<DTOActivity> {
       try {
           val request: Request = Request.Builder()
               .url("${URL}/holiday/${id}")
               .addHeader(
                   "Authorization",
                   "Bearer ${super.roomRepo.getAuthenticatedUser()?.token}"
               )
               .get()
               .build()

           val client = OkHttpClient()
           val response = withContext(Dispatchers.IO) {
               client.newCall(request).execute()
           }

           if (!response.isSuccessful) throw IOException("Response probably unsuccessful. Is authorization token valid ?")

           val activities: String? = response.body()?.string()
           val itemType = object : TypeToken<ArrayList<DTOActivity>>() {}.type
           return DESERIALIZER.fromJson<ArrayList<DTOActivity>>(activities, itemType)

       } catch (ioe : IOException){
           throw ActivityException(ioe.message.toString())
       }
    }

    suspend fun createActivity(dtoActivity: DTOActivity) :Boolean {

        try{
            val client = OkHttpClient()
            val JSON = MediaType.parse("application/json; charset=utf-8")
            val formBody : RequestBody = RequestBody.create(JSON, dtoActivity.toJson())

            val request : Request = Request.Builder()
                .url(URL)
                .addHeader(
                    "Authorization",
                    "Bearer ${super.roomRepo.getAuthenticatedUser()?.token}"
                )
                .post(formBody)
                .build()

            val response = withContext(Dispatchers.IO) {
                client.newCall(request).execute()
            }

            return response.isSuccessful

        } catch(e: IOException) {
            throw ActivityException("Activity could not be created")
        }
    }
}