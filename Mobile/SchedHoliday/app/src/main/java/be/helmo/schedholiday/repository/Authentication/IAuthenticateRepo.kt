package be.helmo.schedholiday.repository.Authentication

import be.helmo.schedholiday.model.AuthenticationRequest
import be.helmo.schedholiday.model.User

interface IAuthenticateRepo {

    suspend fun authenticate(auth : AuthenticationRequest) : User

    companion object{
        private var INSTANCE : AuthenticationRepo? = null

        fun initialize(repo : AuthenticationRepo){
            if(INSTANCE == null) INSTANCE = repo;
        }

        fun get() : AuthenticationRepo{
            return INSTANCE ?: throw IllegalStateException("Unable to initialize");
        }
    }
}