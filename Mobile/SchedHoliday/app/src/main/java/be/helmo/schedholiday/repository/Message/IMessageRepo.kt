package be.helmo.schedholiday.repository.Message

import androidx.lifecycle.LiveData
import be.helmo.schedholiday.infrastructure.Mapping.ActivityMapper
import be.helmo.schedholiday.infrastructure.MessageInfrastructure
import be.helmo.schedholiday.model.Activity
import be.helmo.schedholiday.model.Message
import kotlinx.coroutines.flow.Flow

interface IMessageRepo {

    suspend fun getMessages(holidayId : String) : List<Message>

    suspend fun sendMessage(msg : Message) : Boolean

    suspend fun connect(holidayId: String)

    fun disconnect()

    fun setCallBack(callBack : MessageRepository.ITransferMessages)

    companion object {
        private var INSTANCE : MessageRepository? = null

        fun initialize(repo:MessageRepository){
            if(INSTANCE == null){
                INSTANCE = repo
            }
        }

        fun get() : MessageRepository {
            return INSTANCE ?: throw IllegalStateException("MessageRepository must be initialized")
        }

    }

}