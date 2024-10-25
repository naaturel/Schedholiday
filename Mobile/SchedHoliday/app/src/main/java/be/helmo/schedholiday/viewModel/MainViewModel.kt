package be.helmo.schedholiday.viewModel

import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import be.helmo.schedholiday.model.Holiday
import be.helmo.schedholiday.repository.Holiday.IHolidayRepository
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.flow.MutableStateFlow
import kotlinx.coroutines.flow.StateFlow
import kotlinx.coroutines.flow.collect
import kotlinx.coroutines.launch

class MainViewModel : ViewModel() {

    private val repo = IHolidayRepository.get()
    val holidays: MutableLiveData<MutableList<Holiday>> = MutableLiveData(mutableListOf())

    fun loadHolidays(){
        viewModelScope.launch(Dispatchers.IO) {
            repo.getListHoliday().collect{
                holidays.value!!.clear()
                holidays.postValue(it.toMutableList())
            }
        }
    }

}