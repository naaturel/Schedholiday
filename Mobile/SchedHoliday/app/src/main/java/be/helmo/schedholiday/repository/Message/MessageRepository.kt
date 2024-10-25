package be.helmo.schedholiday.repository.Message

import be.helmo.schedholiday.infrastructure.Mapping.MessageMapper
import be.helmo.schedholiday.infrastructure.MessageInfrastructure
import be.helmo.schedholiday.model.Message

class MessageRepository : IMessageRepo, MessageInfrastructure.IMapMessages {

    private val _msgInfra = MessageInfrastructure()
    private val _msgMapper = MessageMapper()
    private lateinit var callBack : ITransferMessages

    interface ITransferMessages{
        fun transfer(msg : Message)
    }

    override suspend fun getMessages(holidayId: String): List<Message> {
        return _msgMapper.toManyMessage(_msgInfra.getMessages(holidayId))
    }

    override suspend fun sendMessage(msg: Message) : Boolean{
        return _msgInfra.sendMessages(_msgMapper.toDTOMessage(msg))
    }

    override suspend fun connect(holidayId: String) {
        _msgInfra.connect(holidayId, this)
    }

    override fun disconnect() {
        _msgInfra.disconnect()
    }

    override fun setCallBack(callBack : ITransferMessages) {
        this.callBack = callBack
    }

    override fun onReceived(dtoMsg : DTOMessage) {
        val msg = _msgMapper.toMessage(dtoMsg)
        callBack.transfer(msg)
    }
}