package be.helmo.schedholiday.repository.Activity

import be.helmo.schedholiday.infrastructure.ActivityInfrastructure
import be.helmo.schedholiday.infrastructure.Mapping.ActivityMapper
import be.helmo.schedholiday.model.Activity
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.MainScope
import kotlinx.coroutines.flow.Flow
import kotlinx.coroutines.launch
import java.lang.Exception

class ActivityRepository : IActivityRepository {

    private val activityInfra = ActivityInfrastructure()
    private val mapper = ActivityMapper()
    override suspend fun getActivities(id : String): List<Activity> {
        return mapper.toManyActivity(activityInfra.getActivities(id))
    }

    override suspend fun createActivity(activity : Activity) = activityInfra.createActivity(mapper.toDTOActivity(activity))

}