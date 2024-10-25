package be.helmo.schedholiday.infrastructure.Mapping

import android.util.Log
import be.helmo.schedholiday.model.WeatherResponse
import be.helmo.schedholiday.repository.WeatherResponse.DTOWeatherResponse
import kotlin.math.truncate

class MeteoMapper {

    fun toWeather(dto : DTOWeatherResponse?) : WeatherResponse? {
        Log.d("dto", dto.toString())
        return if (dto == null)
            null
        else
            WeatherResponse(
                dto.list[0].weather[0].main,
                dto.list[0].weather[0].icon.substring(0,2)+'d',
                truncate((dto.list[0].main.temp - 273.15))
            )
    }

}