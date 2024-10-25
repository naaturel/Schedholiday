package be.helmo.schedholiday.viewModel

import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import be.helmo.schedholiday.exception.UserException
import be.helmo.schedholiday.model.User
import be.helmo.schedholiday.repository.User.IUserRepository
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch
import kotlinx.coroutines.runBlocking
import java.util.UUID

class RegisterViewModel: ViewModel() {

    private val userRepo = IUserRepository.get()

    fun checkInput(firstName:String, lastName:String, email:String, password:String, confirm:String) : String{
        if(firstName.isEmpty() || lastName.isEmpty() || email.isEmpty() || password.isEmpty() || confirm.isEmpty()){
            return "Veuillez remplir tous les champs"
        }else if(password === confirm){
            return "Les mots de passe ne sont pas les mêmes"
        }
        return ""
    }

    fun createUser(firstName:String, lastName:String, email:String, password:String) :Boolean{
        val user = User(UUID.randomUUID().toString(), firstName, lastName, email)
        var result = false;
        return try{
            viewModelScope.launch(Dispatchers.IO) {
                result = userRepo.registerUser(user)
            }
            result
        }catch(e : UserException){
            result
        }
    }

}