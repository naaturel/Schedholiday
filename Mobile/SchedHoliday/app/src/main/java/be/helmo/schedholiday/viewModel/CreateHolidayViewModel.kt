package be.helmo.schedholiday.viewModel

import android.util.Log
import androidx.lifecycle.ViewModel
import be.helmo.schedholiday.exception.HolidayException
import be.helmo.schedholiday.model.Holiday
import be.helmo.schedholiday.repository.Holiday.IHolidayRepository
import be.helmo.schedholiday.utils.EpochConverter
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.runBlocking
import java.text.SimpleDateFormat
import java.time.LocalDateTime
import java.time.format.DateTimeFormatter
import java.util.Date
import java.util.Locale
import java.util.UUID

class CreateHolidayViewModel : ViewModel() {

    private val holidayRepo = IHolidayRepository.get()

    fun checkInput(name:String, dateStart:String, dateEnd:String, longitude:Double, latitude:Double) : String{
        if(name.isEmpty() || dateStart.isEmpty() || dateEnd.isEmpty() || longitude == 0.0 || latitude == 0.0){
           return "veuillez remplir tous les champs et/ou choisir une destination"
        }else if(SimpleDateFormat("dd/mm/yyyy").parse(dateStart).after(SimpleDateFormat("dd/mm/yyyy").parse(dateEnd))){
            return "la date de fin ne peut pas être antérieur à la date de départ"
        }
        return ""
    }

    fun createHoliday(name:String, dateStart:String, dateEnd:String, longitude:Double, latitude:Double):Boolean{
        val holiday = Holiday(
            UUID.randomUUID().toString(),
            name,
            EpochConverter.toLocalDateTime(dateStart),
            EpochConverter.toLocalDateTime(dateEnd),
            longitude,
            latitude,
            listOf())

        return try{
            var result : Boolean
            runBlocking(Dispatchers.IO) {
                result = holidayRepo.createHoliday(holiday)
            }
            result
        }catch(e : HolidayException){
            false
        }
    }
}