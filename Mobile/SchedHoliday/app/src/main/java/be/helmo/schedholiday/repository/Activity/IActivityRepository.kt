package be.helmo.schedholiday.repository.Activity

import be.helmo.schedholiday.infrastructure.ActivityInfrastructure
import be.helmo.schedholiday.model.Activity
import kotlinx.coroutines.flow.Flow

interface IActivityRepository {

    suspend fun getActivities(id : String) : List<Activity>

    suspend fun createActivity(activity : Activity) : Boolean
    companion object {
        private var INSTANCE : ActivityRepository? = null

        fun initialize(repo :ActivityRepository){
            if(INSTANCE == null){
                INSTANCE = repo
            }
        }

        fun get() : ActivityRepository {
            return INSTANCE ?: throw IllegalStateException("ActivityRepository must be initialized")
        }

    }

}