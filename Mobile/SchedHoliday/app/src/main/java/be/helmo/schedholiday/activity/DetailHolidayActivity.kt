package be.helmo.schedholiday.activity

import android.app.AlertDialog
import android.content.Context
import android.content.Intent
import android.location.Location
import android.location.LocationListener
import android.location.LocationManager
import android.net.Uri
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.EditText
import android.widget.TextView
import android.widget.Toast
import androidx.activity.viewModels
import androidx.lifecycle.lifecycleScope
import be.helmo.schedholiday.R
import be.helmo.schedholiday.databinding.ActivityDetailHolidayBinding
import be.helmo.schedholiday.viewModel.DetailHolidayViewModel
import com.google.android.gms.maps.model.LatLng
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch
import kotlinx.coroutines.runBlocking

private var EXTRA_ID_HOLIDAY = ""
class DetailHolidayActivity : AppCompatActivity() {

    private lateinit var binding: ActivityDetailHolidayBinding
    private val viewModel: DetailHolidayViewModel by viewModels()

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityDetailHolidayBinding.inflate(layoutInflater)

        viewModel.apply {
            idHoliday = EXTRA_ID_HOLIDAY
            load()
        }

        viewModel.liveWeather.observe(this){
            setMeteo()
        }

        viewModel.liveUserList.observe(this){
            binding.recyclerViewUser.adapter = viewModel.getAdapterUser()
        }

        viewModel.liveHoliday.observe(this){
            binding.holidayDate.text = viewModel.getDate()
            binding.holidayTitle.text = it.name
        }

        setButton()

        setContentView(binding.root)
    }

    private fun setButton(){
        binding.buttonBackButton.setOnClickListener {
            onBackPressed()
        }

        binding.chatButton.setOnClickListener {
            startActivity(ChatActivity.newIntent(this@DetailHolidayActivity, EXTRA_ID_HOLIDAY))
        }

        binding.addUserButton.setOnClickListener {
            addUser()
        }

        binding.routeButton.setOnClickListener {
            var here : LatLng
            val locationManager = getSystemService(Context.LOCATION_SERVICE) as LocationManager

            try {
                if (locationManager.isProviderEnabled(LocationManager.GPS_PROVIDER)) {
                    locationManager.requestLocationUpdates(
                        LocationManager.GPS_PROVIDER,
                        5000,
                        1.0f,
                        object : LocationListener {
                            override fun onLocationChanged(location: Location) {
                                val latitude = location.latitude
                                val longitude = location.longitude

                                here = LatLng(latitude, longitude)
                                val destination = viewModel.getCordinnate()
                                val url = "http://maps.google.com/maps?saddr=${here.latitude},${here.longitude}&daddr=${destination.latitude},${destination.longitude}"
                                val mapIntent = Intent(Intent.ACTION_VIEW)

                                mapIntent.setPackage("com.google.android.apps.maps")
                                mapIntent.data = Uri.parse(url)

                                if (mapIntent.resolveActivity(packageManager) != null) {
                                    startActivity(mapIntent)
                                } else {
                                    Toast.makeText(
                                        this@DetailHolidayActivity, "vous avez besoin d'installer Google Map", Toast.LENGTH_LONG).show()
                                }
                            }

                            override fun onStatusChanged(provider: String?, status: Int, extras: Bundle?) {
                                // Ignorer pour cet exemple
                            }

                            override fun onProviderEnabled(provider: String) {
                                // Ignorer pour cet exemple
                            }

                            override fun onProviderDisabled(provider: String) {
                                // Ignorer pour cet exemple
                            }
                        }
                    )

                } else {
                    Toast.makeText(this@DetailHolidayActivity, "vous avez besoin d'installer Google Map", Toast.LENGTH_LONG).show()
                }
            } catch (e: SecurityException) {
                e.printStackTrace()
            }
        }

        binding.scheduleButton.setOnClickListener {
            startActivity(ScheduleActivity.newIntent(this@DetailHolidayActivity, EXTRA_ID_HOLIDAY))
        }
    }

    private fun addUser(){
        val builder = AlertDialog.Builder(this)
        val view = layoutInflater.inflate(R.layout.popup_add_user, null)
        builder.setView(view)

        builder.setPositiveButton("Enregistrer", null)

        builder.setNegativeButton("Annuler") { dialog, which ->
            dialog.dismiss()
        }

        val dialog = builder.create()

        dialog.setOnShowListener {
            val positiveButton = dialog.getButton(AlertDialog.BUTTON_POSITIVE)
            positiveButton.setOnClickListener {
                val emailInput = view.findViewById<EditText>(R.id.email_input).text.toString()
                val message = viewModel.addUser(emailInput)
                if (message.isNotEmpty()) {
                    view.findViewById<TextView>(R.id.error_message).text = message
                } else {
                    Toast.makeText(this, "$emailInput a été ajouter", Toast.LENGTH_LONG).show()
                    dialog.dismiss()
                }
            }
        }

        dialog.show()
    }

    private fun setMeteo(){
        val meteo = viewModel.getMeteo()
        if(viewModel.getIcon() != null){
            binding.meteo.text = meteo
            val resourceId = resources.getIdentifier("ic_" + viewModel.getIcon(), "drawable", packageName)
            binding.meteoPicture.setImageDrawable(resources.getDrawable(resourceId))
        }
    }

    companion object{
        fun newIntent(packageContext: Context, idHoliday: String): Intent {
            return Intent(packageContext, DetailHolidayActivity::class.java).apply{
                EXTRA_ID_HOLIDAY = idHoliday
            }
        }
    }

}