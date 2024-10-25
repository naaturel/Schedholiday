package be.helmo.schedholiday.activity

import android.content.Context
import android.content.Intent
import android.os.Bundle
import android.view.View
import androidx.activity.viewModels
import androidx.appcompat.app.AppCompatActivity
import be.helmo.schedholiday.adapter.ActivityListAdapter
import be.helmo.schedholiday.adapter.CalendarAdapter
import be.helmo.schedholiday.databinding.ActivitySchedulerBinding
import be.helmo.schedholiday.model.Activity
import be.helmo.schedholiday.viewModel.ScheduleViewModel
import java.time.LocalDateTime
import java.time.format.DateTimeFormatter

private var EXTRA_ID_HOLIDAY = ""
class ScheduleActivity : AppCompatActivity(), IDisplayComponents{

    private lateinit var binding: ActivitySchedulerBinding
    private val viewModel : ScheduleViewModel by viewModels();

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

        binding = ActivitySchedulerBinding.inflate(layoutInflater)
        viewModel.loadActivities(EXTRA_ID_HOLIDAY)

        viewModel.liveActivities.observe(this){
            displayCalendar()
        }

        viewModel.liveSelectedDate.observe(this){

        }

        binding.nextMonthButton.setOnClickListener{
            viewModel.incMonth()
            setMonthView()
        }

        binding.previousMonthButton.setOnClickListener{
            viewModel.decMonth()
            setMonthView()
        }

        setContentView(binding.root)
    }


    private fun setMonthView() {

        fun monthYearFromDate(date: LocalDateTime): String {
            val formatter = DateTimeFormatter.ofPattern("MMMM yyyy")
            return date.format(formatter)
        }

        val days : Map<String, List<Activity>>  = viewModel.getDays()
        binding.monthBox.text = monthYearFromDate(viewModel.getSelectedDate())
        binding.calendarRecyclerView.adapter = CalendarAdapter(days, this)
    }

    override fun updateSelectedDate(day : Int) {
        val newDate = viewModel.getSelectedDate().withDayOfMonth(day)
        viewModel.setSelectedDate(newDate)
    }

    override fun displayAddActivityButton() {
        binding.cardAddActivityButton.visibility = View.VISIBLE
        binding.addActivityButton.setOnClickListener{
            startActivity(
                CreateActivityActivity.newIntent(
                    this@ScheduleActivity, EXTRA_ID_HOLIDAY, viewModel.getSelectedDate().toString()
            ))
        }
    }

    override fun displayDayActivities(activities: List<Activity>) {
        binding.activityDisplayerRecyclerView.adapter = ActivityListAdapter(activities)
    }

    override fun displayCalendar() {
        setMonthView()
    }

    companion object{
        fun newIntent(packageContext: Context, idHoliday: String): Intent {
            return Intent(packageContext, ScheduleActivity::class.java).apply{
                EXTRA_ID_HOLIDAY = idHoliday
            }
        }
    }
}
interface IDisplayComponents {

    fun updateSelectedDate(day : Int)

    fun displayAddActivityButton()

    fun displayDayActivities(activities: List<Activity>)

    fun displayCalendar();
}