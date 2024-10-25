package be.helmo.schedholiday.repository.WeatherResponse

data class DTOWeatherResponse(
    val cod: Int,
    val message:Int,
    val cnt:Int,
    val list:List<DTOList>
)

data class DTOList(
    val dt: Int,
    val main: DTOMain,
    val weather:List<DTOWeather>,
    val clouds:DTOClouds,
    val wind:DTOWind,
    val visibility:Int,
    val pop:Double,
    val rain:DTORain,
    val sys:DTOSys,
    val dt_txt:String

)

data class DTOMain(
    val temp: Double,
    val feels_like: Double,
    val temp_min: Double,
    val temp_max: Double,
    val pressure: Int,
    val sea_level: Int,
    val grnd_level: Int,
    val humidity: Int,
    val temp_kf:Double
)

data class DTOWeather(
    val id: Int,
    val main: String,
    val description: String,
    val icon: String
)

data class DTOClouds(
    val all:Int
)

data class DTOWind(
    val speed:Double,
    val deg:Int,
    val gust:Double
)

data class DTORain(
    val theeH:Double
)

data class DTOSys(
    val pod:String
)
