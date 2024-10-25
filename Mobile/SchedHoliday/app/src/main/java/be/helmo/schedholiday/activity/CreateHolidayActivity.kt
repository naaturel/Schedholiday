package be.helmo.schedholiday.activity

import  android.app.AlertDialog
import android.app.DatePickerDialog
import android.content.Context
import android.content.Intent
import android.location.Address
import android.location.Geocoder
import android.location.Location
import android.location.LocationListener
import android.location.LocationManager
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.util.Log
import android.widget.Toast
import androidx.activity.viewModels
import be.helmo.schedholiday.R
import be.helmo.schedholiday.viewModel.CreateHolidayViewModel
import be.helmo.schedholiday.databinding.ActivityCreateHolidayBinding
import com.google.android.gms.maps.CameraUpdateFactory
import com.google.android.gms.maps.SupportMapFragment
import com.google.android.gms.maps.model.LatLng
import com.google.android.gms.maps.model.Marker
import com.google.android.gms.maps.model.MarkerOptions
import java.text.SimpleDateFormat
import java.util.Calendar
import java.util.Locale

class CreateHolidayActivity : AppCompatActivity() {

    private lateinit var binding:ActivityCreateHolidayBinding
    private val createHolidayViewModel: CreateHolidayViewModel by viewModels()

    private var dialog: AlertDialog? = null
    private var currentMarker: Marker? = null
    private var latitude :Double = 0.0
    private var longitude :Double = 0.0

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityCreateHolidayBinding.inflate(layoutInflater)
        setButton()
        setContentView(binding.root)
    }

    private fun setButton(){
        binding.buttonBackButton.setOnClickListener{
            onBackPressed()
        }

        binding.dateStartInput.setOnClickListener {
            showDatePicker(Calendar.getInstance(), true)
        }

        binding.dateEndInput.setOnClickListener {
            showDatePicker(Calendar.getInstance(), false)
        }

        binding.mapButton.setOnClickListener{
            if(dialog == null){
                val builder = AlertDialog.Builder(this)
                val popupMap = layoutInflater.inflate(R.layout.popup_create_holiday_map, null)
                builder.setView(popupMap)

                builder.setNegativeButton("Retour") { dialog, which ->
                    dialog.dismiss()
                }
                dialog = builder.create()
            }
            val message = setCoordinate()
            if(message == ""){
                dialog?.show()
            }
            binding.errorMessageCreateHoliday.text = message

        }

        binding.createButton.setOnClickListener {
            setCoordinate()
            createHoliday()
        }
    }

    private fun setCoordinate() : String{
        val street = binding.streetInput.text.toString()
        val num = binding.numInput.text.toString()
        val locality = binding.localityInput.text.toString()
        val code = binding.codeInput.text.toString()

        if(street.isNotEmpty() && num.isNotEmpty() && locality.isNotEmpty() && code.isNotEmpty()){
            val destination = "$street $num, $code $locality"
            val addresses: MutableList<Address>? = Geocoder(this).getFromLocationName(destination, 1)

            if (!addresses.isNullOrEmpty()) {
                latitude = addresses[0].latitude
                longitude = addresses[0].longitude
                addMarker(LatLng(latitude, longitude), destination)
            }else{
                return "adresse que vous avez mentionné est introuvable"
            }
        }
        return ""
    }

    private fun addMarker(coordinate : LatLng, destination : String){
        val mapFragment = supportFragmentManager.findFragmentById(R.id.map_fragment) as? SupportMapFragment
        val locationManager = getSystemService(Context.LOCATION_SERVICE) as LocationManager
        val locationListener = object : LocationListener {
            override fun onLocationChanged(location: Location) {
                mapFragment?.getMapAsync { googleMap ->
                    currentMarker?.remove()

                    //val coordinate = LatLng(location.latitude, location.longitude)
                    currentMarker = googleMap.addMarker(
                        MarkerOptions()
                            .title(destination)
                            .position(coordinate)
                    )
                    googleMap.animateCamera(CameraUpdateFactory.newLatLng(coordinate))
                }
            }

            override fun onStatusChanged(provider: String?, status: Int, extras: Bundle?) {
                // Gérer le changement de statut ici si nécessaire
            }

            override fun onProviderEnabled(provider: String) {
                // Gérer l'activation du fournisseur ici si nécessaire
            }

            override fun onProviderDisabled(provider: String) {
                // Gérer la désactivation du fournisseur ici si nécessaire
            }
        }

        try {
            locationManager.requestLocationUpdates(LocationManager.GPS_PROVIDER, 1000000, 0f, locationListener)
        } catch (e: SecurityException) {
            e.printStackTrace()
        }
    }

    private fun showDatePicker(calendar: Calendar, start : Boolean){
        val datePickerDialog = DatePickerDialog(
            this, {DatePicker, year: Int, monthOfYear: Int, dayOfMonth: Int ->
                val selectedDate = Calendar.getInstance()
                selectedDate.set(year, monthOfYear, dayOfMonth)
                val dateFormat = SimpleDateFormat("dd/MM/yyyy", Locale.getDefault())
                val formattedDate = dateFormat.format(selectedDate.time)
                if(start){
                    binding.dateStartInput.text = formattedDate
                }else{
                    binding.dateEndInput.text = formattedDate
                }

            },
            calendar.get(Calendar.YEAR),
            calendar.get(Calendar.MONTH),
            calendar.get(Calendar.DAY_OF_MONTH)
        )
        datePickerDialog.show()
    }

    private fun createHoliday(){
        val name = binding.nameInput.text.toString()
        val dateStart = binding.dateStartInput.text.toString()
        val dateEnd = binding.dateEndInput.text.toString()
        val messageCheck = createHolidayViewModel.checkInput(name, dateStart, dateEnd, longitude, latitude)
        if(messageCheck == ""){
            if(createHolidayViewModel.createHoliday(name, dateStart, dateEnd, longitude, latitude)){
                Toast.makeText(this, "votre voyage a bien été créé", Toast.LENGTH_LONG).show()
                onBackPressed()
            }else {
                binding.errorMessageCreateHoliday.text = "erreur pendant la création du voyage"
            }
        }else{
            binding.errorMessageCreateHoliday.text = messageCheck
        }
    }

    companion object{
        fun newInstent(packageContext: Context): Intent {
            return Intent(packageContext, CreateHolidayActivity::class.java).apply{

            }
        }
    }

}