package be.helmo.schedholiday.viewModel

import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import be.helmo.schedholiday.exception.ActivityException
import be.helmo.schedholiday.model.Activity
import be.helmo.schedholiday.repository.Activity.IActivityRepository
import be.helmo.schedholiday.utils.EpochConverter
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch
import kotlinx.coroutines.runBlocking
import java.text.SimpleDateFormat
import java.time.LocalDateTime

class CreateActivityViewModel : ViewModel() {

    private val activityRepo = IActivityRepository.get()

    var name: String? = null
    var description: String? = null
    var dateStart: LocalDateTime? = null
    var dateEnd: LocalDateTime? = null
    var liveIsCreated: MutableLiveData<Boolean> = MutableLiveData(false)

    private fun checkInput() {

        if (name.isNullOrEmpty()
            || description.isNullOrEmpty()
            || dateStart == null
            || dateEnd == null
        ) throw ActivityException("All fields must be filled")

        if (dateStart!!.isAfter(dateEnd)) throw ActivityException("La date de fin ne peut pas être antérieur à la date de départ")
    }

    fun createActivity(idHoliday: String) {

        checkInput()

        val activity = Activity(
            name!!,
            description!!,
            dateStart!!,
            dateEnd!!,
            idHoliday)

        try {
            viewModelScope.launch(Dispatchers.IO) {
                val result = activityRepo.createActivity(activity)
                if (!result == liveIsCreated.value) liveIsCreated.postValue(true)
                else throw ActivityException("An error while creating the activity")
            }
        } catch (e: Exception) {
            throw ActivityException("An unknown error has occurred")
        }

    }
}
