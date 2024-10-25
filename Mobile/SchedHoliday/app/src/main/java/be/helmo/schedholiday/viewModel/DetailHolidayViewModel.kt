package be.helmo.schedholiday.viewModel

import android.util.Log
import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import be.helmo.schedholiday.adapter.UserListAdapter
import be.helmo.schedholiday.exception.ActivityException
import be.helmo.schedholiday.model.Holiday
import be.helmo.schedholiday.model.User
import be.helmo.schedholiday.model.WeatherResponse
import be.helmo.schedholiday.repository.Holiday.IHolidayRepository
import be.helmo.schedholiday.repository.User.IUserRepository
import be.helmo.schedholiday.repository.WeatherResponse.IWeatherResponseRepository
import com.google.android.gms.maps.model.LatLng
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch
import kotlinx.coroutines.runBlocking
import kotlinx.coroutines.withContext
import java.text.SimpleDateFormat
import java.util.Date

class DetailHolidayViewModel : ViewModel(){

    private val userRepo = IUserRepository.get()
    private val holidayRepo = IHolidayRepository.get()
    private val meteoRepo = IWeatherResponseRepository.get()
    private var meteo : WeatherResponse? = null
    private lateinit var holiday : Holiday

    var liveHoliday : MutableLiveData<Holiday> = MutableLiveData()
    var liveUserList : MutableLiveData<MutableList<User>> = MutableLiveData(mutableListOf())
    var liveWeather : MutableLiveData<WeatherResponse> = MutableLiveData()

    lateinit var idHoliday: String

    private var listUser: MutableList<User> = listOf<User>().toMutableList()
        get() = field

    fun load(){

        runBlocking(Dispatchers.IO) {
            holiday = holidayRepo.getHoliday(idHoliday)
            liveHoliday.postValue(holiday)
        }

        runBlocking(Dispatchers.IO) {
            listUser = holidayRepo.getListUsers(idHoliday).toMutableList()
            liveUserList.postValue(listUser)
        }

        viewModelScope.launch(Dispatchers.IO) {
            meteo = meteoRepo.getWeather(LatLng(holiday.latitude, holiday.longitude))
            if(meteo != null)  liveWeather.postValue(meteo!!)
        }
    }

    fun getMeteo() : String{
        var meteoText = ""
        meteoText += when(meteo?.main){
            "Thunderstorm" -> "Orageux"
            "Drizzle" -> "Grosse pluie"
            "Rain" -> "Pluvieux"
            "Snow" -> "Neigeux"
            "Clear" -> "Ensoleillé"
            "Clouds" -> "Nuageux"
            else -> "Brouillard"
        }
        return meteoText + " " + meteo?.temp + " °C"
    }

    fun getIcon() = meteo?.icon

    fun getDate() : String{
        return holiday.getFormattedDate()
    }

    fun getAdapterUser() : UserListAdapter = UserListAdapter(listUser)

    fun addUser(email:String) : String{
        if(email.isEmpty()){
            return "veuillez remplir tous les champs"
        }
        return try{
            var message : String
            runBlocking {
                val user = userRepo.getUser(email)
                message = if(user !== null){
                    listUser.add(user)
                    holidayRepo.addUser(holiday.id, user.id)
                    ""
                }else{
                    "la personne n'existe pas"
                }
            }
            message
        }catch(e : ActivityException){
            "une erreur c'est produit"
        }

    }

    fun getCordinnate() : LatLng = LatLng(holiday.latitude, holiday.longitude)


}