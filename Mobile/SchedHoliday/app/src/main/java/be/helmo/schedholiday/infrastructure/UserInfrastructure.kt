package be.helmo.schedholiday.infrastructure

import be.helmo.schedholiday.exception.HolidayException
import be.helmo.schedholiday.exception.UserException
import be.helmo.schedholiday.model.User
import be.helmo.schedholiday.repository.Holiday.DTOHoliday
import be.helmo.schedholiday.repository.User.DTOUser
import com.google.gson.reflect.TypeToken
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.withContext
import okhttp3.FormBody
import okhttp3.MediaType
import okhttp3.OkHttpClient
import okhttp3.Request
import okhttp3.RequestBody
import java.io.IOException

class UserInfrastructure : Infra(){

    private val URL_BASE = "https://porthos-intra.cg.helmo.be/Q210044/api/user"

    suspend fun registerUser(user: DTOUser) :Boolean {

        try{
            val client = OkHttpClient()
            val JSON = MediaType.parse("application/json; charset=utf-8")

            val formBody : RequestBody = RequestBody.create(JSON, user.toJson())
            val request : Request = Request.Builder()
                .url(URL_BASE)
                .post(formBody)
                .build()

            val response = withContext(Dispatchers.IO) {
                client.newCall(request).execute()
            }

            return response.isSuccessful
        }catch(e:IOException){
            throw UserException("erreur pendant l'enregistrement")
        }

    }

    suspend fun getUser(email: String) :DTOUser? {
        try{
            val request : Request = Request.Builder()
                .url("https://porthos-intra.cg.helmo.be/Q210044/email/${email}")
                .addHeader(
                    "Authorization",
                    "Bearer ${super.roomRepo.getAuthenticatedUser()?.token}")
                .build()

            val client = OkHttpClient()
            val response = withContext(Dispatchers.IO) {
                client.newCall(request).execute()
            }

            if(!response.isSuccessful) throw IOException("Response probably unsuccessful. Is authorization token valid ?")

            val user: String? = response.body()?.string()
            val itemType = object : TypeToken<DTOUser>() {}.type
            return DESERIALIZER.fromJson(user, itemType)

        } catch(e: IOException) {
            throw UserException("Erreur pendant l'ajout de l'utilisateur")
        }
    }
}