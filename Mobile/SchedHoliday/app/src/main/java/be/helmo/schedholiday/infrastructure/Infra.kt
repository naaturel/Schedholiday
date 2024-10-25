package be.helmo.schedholiday.infrastructure

import be.helmo.schedholiday.model.User
import be.helmo.schedholiday.repository.Authentication.IAuthenticateRepo
import be.helmo.schedholiday.repository.RoomRepo
import com.google.gson.Gson

open class Infra {

    protected val BASE_URL : String = "https://porthos-intra.cg.helmo.be/Q210044/api/"
    protected val DESERIALIZER : Gson = Gson();
    protected val roomRepo = RoomRepo.get();
}