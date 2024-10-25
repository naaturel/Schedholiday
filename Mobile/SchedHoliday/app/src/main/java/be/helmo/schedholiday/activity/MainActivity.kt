package be.helmo.schedholiday.activity

import android.content.Context
import android.content.Intent
import android.os.Bundle
import androidx.activity.viewModels
import androidx.appcompat.app.AppCompatActivity
import be.helmo.schedholiday.adapter.ISwitchMain
import be.helmo.schedholiday.viewModel.MainViewModel
import be.helmo.schedholiday.databinding.ActivityMainBinding

class MainActivity : AppCompatActivity(), ISwitchMain {

    private lateinit var binding:ActivityMainBinding
    private val mainViewModel: MainViewModel by viewModels()

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        mainViewModel.loadHolidays()

        binding = ActivityMainBinding.inflate(layoutInflater)
        setContentView(binding.root)

    }
    override fun switchDetail(id : String) {
        startActivity(DetailHolidayActivity.newIntent(this@MainActivity, id))
    }

    override fun switchCreateHoliday() {
        startActivity(CreateHolidayActivity.newInstent(this@MainActivity))
    }

    companion object{
        fun newInstent(packageContext: Context): Intent {
            return Intent(packageContext, MainActivity::class.java).apply{

            }
        }
    }

}