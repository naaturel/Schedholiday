package be.helmo.schedholiday.activity

import android.content.Context
import android.content.Intent
import android.os.Bundle
import android.widget.Toast
import androidx.activity.viewModels
import androidx.appcompat.app.AppCompatActivity
import be.helmo.schedholiday.viewModel.RegisterViewModel
import be.helmo.schedholiday.databinding.ActivityRegisterBinding

class RegisterActivity : AppCompatActivity() {

    private lateinit var binding: ActivityRegisterBinding
    private val registerViewModel: RegisterViewModel by viewModels()

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityRegisterBinding.inflate(layoutInflater)
        setButton()
        setContentView(binding.root)
    }

    private fun setButton(){
        binding.connectionButton.setOnClickListener{
            onBackPressed()
            //startActivity(Intent(this, ConnectionActivity::class.java))
        }

        binding.registerButton.setOnClickListener {
            registerUser()
        }
    }

    private fun registerUser(){
        val lastName = binding.nameInput.text.toString()
        val firstName = binding.firstnameInput.text.toString()
        val email = binding.emailInput.text.toString()
        val password = binding.passwordInput.text.toString()
        val confirm = binding.confirmInput.text.toString()
        val message = registerViewModel.checkInput(lastName, firstName, email, password, confirm)
        if(message === ""){
            if(registerViewModel.createUser(lastName, firstName, email, password)){
                Toast.makeText(this, "votre compte a bien été créé", Toast.LENGTH_LONG).show()
                startActivity(Intent(this, MainActivity::class.java))
            }else{
                binding.errorMessageRegister.text = "une erreur est survenu"
            }
        }else{
            binding.errorMessageRegister.text = message
        }
    }

    companion object{
        fun newInstent(packageContext: Context): Intent {
            return Intent(packageContext, RegisterActivity::class.java, ).apply{

            }
        }
    }

}