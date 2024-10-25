package be.helmo.schedholiday.viewModel

import android.util.Log
import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import be.helmo.schedholiday.model.AuthenticationRequest
import be.helmo.schedholiday.model.AuthenticationResponse
import be.helmo.schedholiday.repository.Authentication.IAuthenticateRepo
import be.helmo.schedholiday.repository.RoomRepo
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch
import kotlinx.coroutines.runBlocking
import java.lang.Exception

class AuthenticationViewModel: ViewModel() {


    private val repo = IAuthenticateRepo.get();
    private val room = RoomRepo.get();
    var user :  MutableLiveData<AuthenticationResponse> = MutableLiveData()

    fun authenticate(email : String, password : String) {

        if (email.isEmpty() || password.isEmpty()) throw Exception("No field should be empty")

        viewModelScope.launch(Dispatchers.IO){
            val data = repo.authenticate(AuthenticationRequest(email, password))
            user.postValue(data)
            room.addAuthenticatedUser(data)
        }
    }
}