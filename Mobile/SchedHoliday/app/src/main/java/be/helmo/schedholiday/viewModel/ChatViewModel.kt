package be.helmo.schedholiday.viewModel

import android.util.Log
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import be.helmo.schedholiday.activity.IDisplayChatStatus
import be.helmo.schedholiday.model.Message
import be.helmo.schedholiday.repository.Message.IMessageRepo
import be.helmo.schedholiday.repository.Message.MessageRepository
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch
import java.time.LocalDateTime

class ChatViewModel : ViewModel(), MessageRepository.ITransferMessages {

    private lateinit var callBack : IDisplayChatStatus
    private var repo = IMessageRepo.get()

    val messages : MutableList<Message> = mutableListOf()
    val liveMessages : MutableLiveData<MutableList<Message>> = MutableLiveData(messages)

    fun setCallBackInterfaces(intrfc :  IDisplayChatStatus){
        callBack = intrfc
        repo.setCallBack(this)
    }

    fun loadMessages(holidayId : String) {
        viewModelScope.launch(Dispatchers.IO) {
            messages.clear()
            messages.addAll(repo.getMessages(holidayId).toMutableList())
            messages.sortBy { m -> m.date }
            liveMessages.postValue(messages)
        }
    }

    fun sendMessage(content : String, holidayId: String){
        viewModelScope.launch(Dispatchers.IO) {
            val msg = Message(content, LocalDateTime.now(), "", holidayId)
            val succeeded = repo.sendMessage(msg)

            if(!succeeded) callBack.notifyConnectionState("Message could not be sent")
        }
    }

    fun connect(holidayId: String){
        viewModelScope.launch(Dispatchers.IO) {
            repo.connect(holidayId)
        }
    }

    fun disconnect(){
        repo.disconnect()
    }

    override fun transfer(msg: Message) {
        Log.d("Transfer_msg", msg.content)
        messages.add(msg)
        messages.sortBy { m -> m.date }
        liveMessages.postValue(messages);
    }
}