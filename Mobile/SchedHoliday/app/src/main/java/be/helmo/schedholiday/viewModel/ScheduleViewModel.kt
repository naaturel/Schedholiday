package be.helmo.schedholiday.viewModel

import androidx.lifecycle.MutableLiveData
import be.helmo.schedholiday.model.Activity
import be.helmo.schedholiday.repository.Activity.IActivityRepository
import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch
import java.time.LocalDateTime
import java.time.YearMonth

class ScheduleViewModel : ViewModel() {

    private val repo = IActivityRepository.get()

    private var activities : List<Activity> = listOf()
    var liveActivities : MutableLiveData<List<Activity>> = MutableLiveData(activities)

    val liveSelectedDate : MutableLiveData<LocalDateTime> =
        MutableLiveData(LocalDateTime.now().withDayOfMonth(1))

    fun loadActivities(holidayId : String) {
        viewModelScope.launch(Dispatchers.IO) {
            activities = repo.getActivities(holidayId).toMutableList()
            liveActivities.postValue(activities)
        }
    }

    fun incMonth(){
        liveSelectedDate.apply {
            value = value!!.plusMonths(1)
        }
    }

    fun decMonth(){
        liveSelectedDate.apply {
            value = value!!.minusMonths(1)
        }
    }

    fun setSelectedDate(date :  LocalDateTime){
        liveSelectedDate.apply {
            value = date
        }
    }

    fun getSelectedDate() : LocalDateTime{
        return liveSelectedDate.value!!
    }

    fun addActivity(idHoliday: String){

        val activity  = Activity(
            "name",
            "description",
            LocalDateTime.now(),
            LocalDateTime.now(),
            idHoliday
            )

        viewModelScope.launch(Dispatchers.IO) {
            repo.createActivity(activity)
        }
    }

    fun getDays() : Map<String, List<Activity>>{

        val base = liveSelectedDate.value!!
        val events : MutableMap<String, MutableList<Activity>> = mutableMapOf()
        val month = YearMonth.from(base)
        val dayNumber = base.dayOfWeek.value

        for (i in 2-dayNumber .. month.lengthOfMonth()){
            events[i.toString()] = mutableListOf()
        }

        for (a in activities){

            val activityDate = a.startDate

            if(activityDate.year == base.year
                && activityDate.month == base.month){
                events[activityDate.dayOfMonth.toString()]?.add(a)
            }
        }

        return events
    }

    fun get(index : Int) : String{
        return activities[index].toString();
    }

    private fun sort(){
        activities.sortedBy { a -> a.startDate }
    }
}