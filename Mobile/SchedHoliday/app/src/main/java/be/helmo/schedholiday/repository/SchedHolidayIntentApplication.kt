package be.helmo.schedholiday.repository

import android.app.Application
import be.helmo.schedholiday.repository.Activity.ActivityRepository
import be.helmo.schedholiday.repository.Activity.IActivityRepository
import be.helmo.schedholiday.repository.Authentication.AuthenticationRepo
import be.helmo.schedholiday.repository.Authentication.IAuthenticateRepo
import be.helmo.schedholiday.repository.Holiday.HolidayRepository
import be.helmo.schedholiday.repository.Holiday.IHolidayRepository
import be.helmo.schedholiday.repository.Message.IMessageRepo
import be.helmo.schedholiday.repository.Message.MessageRepository
import be.helmo.schedholiday.repository.User.IUserRepository
import be.helmo.schedholiday.repository.User.UserRepository
import be.helmo.schedholiday.repository.WeatherResponse.IWeatherResponseRepository
import be.helmo.schedholiday.repository.WeatherResponse.WeatherResponseRepository

class SchedHolidayIntentApplication : Application() {
    override fun onCreate() {
        super.onCreate()
        RoomRepo.initialize(this)
        IUserRepository.initialize(UserRepository())
        IHolidayRepository.initialize(HolidayRepository())
        IMessageRepo.initialize(MessageRepository())
        IActivityRepository.initialize(ActivityRepository())
        IAuthenticateRepo.initialize(AuthenticationRepo())
        IWeatherResponseRepository.initialize(WeatherResponseRepository())
    }
}