package be.helmo.schedholiday.activity

import android.Manifest
import android.app.Activity
import android.content.Context
import android.content.Intent
import android.content.pm.PackageManager
import android.os.Bundle
import androidx.activity.viewModels
import androidx.appcompat.app.AppCompatActivity
import androidx.core.app.ActivityCompat
import androidx.core.content.ContextCompat
import be.helmo.schedholiday.R
import be.helmo.schedholiday.databinding.ActivityConnectionBinding
import be.helmo.schedholiday.exception.UserException
import be.helmo.schedholiday.viewModel.AuthenticationViewModel
import java.lang.Exception
import java.util.ArrayList

class AuthenticationActivity : AppCompatActivity() {

    private lateinit var binding: ActivityConnectionBinding
    private val viewModel: AuthenticationViewModel by viewModels()

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityConnectionBinding.inflate(layoutInflater)

        viewModel.user.observe(this){
            startActivity(Intent(this, MainActivity::class.java))
        }

        setButton()
        checkPermissions(this)
        setContentView(binding.root)

    }

    private fun checkPermissions(context: Context){
        val permissionsToRequest = ArrayList<String>()

        if (ContextCompat.checkSelfPermission(context, Manifest.permission.INTERNET) != PackageManager.PERMISSION_GRANTED) {
            permissionsToRequest.add(Manifest.permission.INTERNET)
        }

        if (ContextCompat.checkSelfPermission(context, Manifest.permission.ACCESS_FINE_LOCATION) != PackageManager.PERMISSION_GRANTED) {
            permissionsToRequest.add(Manifest.permission.ACCESS_FINE_LOCATION)
        }

        if (ContextCompat.checkSelfPermission(context, Manifest.permission.ACCESS_COARSE_LOCATION) != PackageManager.PERMISSION_GRANTED) {
            permissionsToRequest.add(Manifest.permission.ACCESS_COARSE_LOCATION)
        }

        if (permissionsToRequest.isNotEmpty()) {
            ActivityCompat.requestPermissions(context as Activity, permissionsToRequest.toTypedArray(), 100)
        }
    }

    private fun setButton(){
        binding.connectionButton.setOnClickListener{
            authenticate()
        }

        binding.registerButton.setOnClickListener {
            startActivity(Intent(this, RegisterActivity::class.java))
        }
    }

    private fun authenticate(){
        val email = binding.emailInput.text.toString()
        val password = binding.passwordInput.text.toString()

        try{

            disableButtons()
            viewModel.authenticate(email, password)

        } catch (ue : UserException) {
            binding.errorMessageRegister.text = ue.message

        } catch (e : Exception){
            binding.errorMessageRegister.text = e.message
        }
    }

    private fun disableButtons(){

        binding.cardConnectionButton.elevation = 0F
        binding.connectionButton.apply {
            setBackgroundColor(ContextCompat.getColor(context, R.color.gray))
            isEnabled = false
            isClickable = false
        }

        binding.cardRegisterButton.elevation = 0F
        binding.registerButton.apply {
            setBackgroundColor(ContextCompat.getColor(context, R.color.gray))
            isEnabled = false
            isClickable = false
        }

    }

    companion object{
        fun newInstent(packageContext: Context): Intent {
            return Intent(packageContext, AuthenticationActivity::class.java).apply{

            }
        }
    }

}