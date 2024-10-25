package be.helmo.schedholiday.repository.WeatherResponse

import be.helmo.schedholiday.infrastructure.Mapping.MeteoMapper
import be.helmo.schedholiday.infrastructure.MeteoInfrastructure
import be.helmo.schedholiday.model.WeatherResponse
import com.google.android.gms.maps.model.LatLng

class WeatherResponseRepository : IWeatherResponseRepository {

    private val _weatherInfra = MeteoInfrastructure()
    private val mapper = MeteoMapper();

    override suspend fun getWeather(coordinate: LatLng): WeatherResponse? {
        val dtoWeather = _weatherInfra.getWeather(coordinate)
        return mapper.toWeather(dtoWeather)
    }
}