package be.helmo.schedholiday.model

data class WeatherResponse(
    val main : String,
    val icon : String,
    val temp : Double,
)