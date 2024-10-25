package be.helmo.schedholiday.infrastructure

import android.util.Log
import be.helmo.schedholiday.exception.HolidayException
import be.helmo.schedholiday.repository.Message.DTOMessage
import com.google.gson.reflect.TypeToken
import com.pusher.client.Pusher
import com.pusher.client.PusherOptions
import com.pusher.client.connection.ConnectionEventListener
import com.pusher.client.connection.ConnectionState
import com.pusher.client.connection.ConnectionStateChange
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.withContext
import okhttp3.MediaType
import okhttp3.OkHttpClient
import okhttp3.Request
import okhttp3.RequestBody
import java.io.IOException


class MessageInfrastructure : Infra() {

    private val URL = "${super.BASE_URL}Chat"

    private var options : PusherOptions = PusherOptions()
    private var pusher : Pusher

    init{
        options.setCluster("eu");
        pusher = Pusher("0794d85e3c42a590d8bc", options)
    }

    interface IMapMessages{
        fun onReceived(dtoMsg : DTOMessage)
    }

    suspend fun getMessages(holidayId : String) : List<DTOMessage> {
        try{
            val request : Request = Request.Builder()
                .url("${URL}/${holidayId}")
                .addHeader(
                    "Authorization",
                    "Bearer ${super.roomRepo.getAuthenticatedUser()?.token}")
                .build()

            val client = OkHttpClient()
            val response = withContext(Dispatchers.IO) {
                client.newCall(request).execute()
            }

            if(!response.isSuccessful) throw IOException("Response probably unsuccessful. Is authorization token valid ?")

            val msgs: String? = response.body()?.string()
            val itemType = object : TypeToken<ArrayList<DTOMessage>>() {}.type
            return DESERIALIZER.fromJson<ArrayList<DTOMessage>>(msgs, itemType)

        }catch(e: IOException){

            //TODO : Create MessageException class
            throw HolidayException(e.message.toString())
        }
    }

    suspend fun sendMessages(dtoMsg : DTOMessage) : Boolean {
        try{

            val user = super.roomRepo.getAuthenticatedUser()
            dtoMsg.Sender = user!!.id

            val JSON = MediaType.parse("application/json; charset=utf-8")

            val body: RequestBody = RequestBody.create(JSON, dtoMsg.toJson());

            val request : Request = Request.Builder()
                .url(URL)
                .addHeader(
                    "Authorization",
                    "Bearer ${user.token}")
                .post(body)
                .build()

            val client = OkHttpClient()
            val response = withContext(Dispatchers.IO) {
                client.newCall(request).execute()
            }

            return response.isSuccessful

        }catch(e: IOException){
            throw HolidayException("An error occured while sending the message")
        }
    }

    suspend fun connect(idHoliday : String, callBackInterface : IMapMessages){
        pusher.connect(object : ConnectionEventListener {
            override fun onConnectionStateChange(change: ConnectionStateChange) {
                Log.i("Pusher", "State changed from ${change.previousState} to ${change.currentState}")
            }

            override fun onError(
                message: String?,
                code: String?,
                e: Exception?
            ) {
                Log.i("Pusher", "There was a problem connecting! message ($message), exception($e)")
            }
        }, ConnectionState.ALL)

        var channel = pusher.getChannel("$idHoliday-channel")

        if(channel === null ){
            channel = pusher.subscribe("$idHoliday-channel")

            channel.bind("$idHoliday-event") { event ->
                val itemType = object : TypeToken<DTOMessage>() {}.type
                val msg = DESERIALIZER.fromJson<DTOMessage>(event.data, itemType)
                callBackInterface.onReceived(msg)
            }
        }
    }

    fun disconnect(){
        pusher.disconnect()
    }

}