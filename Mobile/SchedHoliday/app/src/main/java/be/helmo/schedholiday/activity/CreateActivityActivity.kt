package be.helmo.schedholiday.activity

import android.app.DatePickerDialog
import android.content.Context
import android.content.Intent
import android.os.Bundle
import android.util.Log
import android.widget.Button
import android.widget.Toast
import androidx.activity.viewModels
import androidx.appcompat.app.AppCompatActivity
import be.helmo.schedholiday.databinding.ActivityCreateActivityBinding
import be.helmo.schedholiday.exception.ActivityException
import be.helmo.schedholiday.viewModel.CreateActivityViewModel
import java.time.LocalDateTime
import java.util.Calendar

private var EXTRA_ID_HOLIDAY : String = "UUID.random()"
private var EXTRA_DATE_START : LocalDateTime = LocalDateTime.now()

class CreateActivityActivity : AppCompatActivity() {

    private lateinit var binding: ActivityCreateActivityBinding
    private val viewModel: CreateActivityViewModel by viewModels()

    private val calendarStartDate = Calendar.getInstance()
    private val calendarEndDate = Calendar.getInstance()

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityCreateActivityBinding.inflate(layoutInflater)

        setDate(binding.dateStartInput, EXTRA_DATE_START, true)

        viewModel.liveIsCreated.observe(this){

            if(!it) return@observe

            Toast.makeText(this, "Activity created successfuly !", Toast.LENGTH_LONG).show()
            onBackPressed()
        }

        setButton()

        setContentView(binding.root)
    }

    private fun setButton(){
        binding.buttonBackButton.setOnClickListener {
            onBackPressed()
        }

        binding.dateStartInput.setOnClickListener {
            showDatePicker(calendarStartDate, true)
        }

        binding.dateEndInput.setOnClickListener {
            showDatePicker(calendarEndDate, false)
        }

        binding.createButton.setOnClickListener {

            viewModel.name = binding.nameInput.text.toString()
            viewModel.description = binding.descriptionInput.text.toString()

            try{
                viewModel.createActivity(EXTRA_ID_HOLIDAY)
            } catch (ae : ActivityException){
                binding.errorMessage.text = ae.message
            }
        }
    }

    private fun showDatePicker(calendar: Calendar, start : Boolean){
        val datePickerDialog =
            DatePickerDialog(this, { _, year: Int, monthOfYear: Int, dayOfMonth: Int ->

                val localDateTime =
                    LocalDateTime
                        .now()
                        .withYear(year)
                        .withMonth(monthOfYear+1)
                        .withDayOfMonth(dayOfMonth)

                if(start) setDate(binding.dateStartInput, localDateTime, true)
                else setDate(binding.dateEndInput, localDateTime, false)


            },
            calendar.get(Calendar.YEAR),
            calendar.get(Calendar.MONTH),
            calendar.get(Calendar.DAY_OF_MONTH)
        )
        datePickerDialog.show()
    }

    private fun setDate(datePicker : Button, date : LocalDateTime, start: Boolean){

        if(start) viewModel.dateStart = date
        else viewModel.dateEnd = date

        datePicker.text = formatDate(date)
    }

    private fun formatDate(date : LocalDateTime) : String{
        return "${date.dayOfMonth} ${date.month} ${date.year}"
    }

    companion object{
        fun newIntent(packageContext: Context, idHoliday : String, dateStart : String): Intent {
            return Intent(packageContext, CreateActivityActivity::class.java).apply{
                EXTRA_ID_HOLIDAY = idHoliday
                EXTRA_DATE_START = LocalDateTime.parse(dateStart)
                Log.d("Date", EXTRA_DATE_START.dayOfMonth.toString())
            }
        }
    }
}