package be.helmo.schedholiday.repository.WeatherResponse

import be.helmo.schedholiday.model.WeatherResponse
import com.google.android.gms.maps.model.LatLng

interface IWeatherResponseRepository {

    suspend fun getWeather(coordinate : LatLng) : WeatherResponse?
    companion object {
        private var INSTANCE : WeatherResponseRepository? = null

        fun initialize(repo : WeatherResponseRepository){
            if(INSTANCE == null){
                INSTANCE = repo
            }
        }

        fun get() : WeatherResponseRepository {
            return INSTANCE ?: throw IllegalStateException("WeatherResponseRepository must be initialized")
        }

    }
}