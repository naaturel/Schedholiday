package be.helmo.schedholiday.viewModel

import androidx.lifecycle.ViewModel

class ConnectionViewModel: ViewModel() {

    fun connexion(email:String, password:String) :Boolean{

        return email.isNotEmpty() && password.isNotEmpty()
    }
}