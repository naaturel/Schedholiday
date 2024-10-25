package be.helmo.schedholiday.infrastructure

import android.util.Log
import be.helmo.schedholiday.repository.WeatherResponse.DTOWeatherResponse
import com.google.android.gms.maps.model.LatLng
import com.google.gson.Gson
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.withContext
import okhttp3.OkHttpClient
import okhttp3.Request

class MeteoInfrastructure : Infra(){

    suspend fun getWeather(coordinate : LatLng) : DTOWeatherResponse?{
        val URL = "${super.BASE_URL}Meteo/${coordinate.latitude}&${coordinate.longitude}"
        val request : Request = Request.Builder()
            .url(URL)
            .addHeader(
                "Authorization",
                "Bearer ${super.roomRepo.getAuthenticatedUser()?.token}")
            .build()

        val client = OkHttpClient()
        return try {
            val response = withContext(Dispatchers.IO) {
                client.newCall(request).execute()
            }
            if (response.isSuccessful) {
                val json = response.body()?.string()
                Gson().fromJson(json, DTOWeatherResponse::class.java)
            } else {
                null
            }
        } catch (e: Exception) {
            e.printStackTrace()
            null
        }

    }

}