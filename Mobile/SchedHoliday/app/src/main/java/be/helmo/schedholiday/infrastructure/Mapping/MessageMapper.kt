package be.helmo.schedholiday.infrastructure.Mapping

import be.helmo.schedholiday.model.Message
import be.helmo.schedholiday.repository.Message.DTOMessage
import be.helmo.schedholiday.utils.EpochConverter

class MessageMapper {

    fun toMessage(dto : DTOMessage) : Message {
        return Message(
            dto.Content,
            EpochConverter.toLocalDate(dto.Epoch),
            dto.Sender,
            dto.HolidayId
        )
    }

    fun toDTOMessage(message : Message) : DTOMessage {
        return DTOMessage(
            message.content,
            EpochConverter.toEpochSeconds(message.date),
            message.sender,
            message.holidayId
        )
    }

    fun toManyMessage(messagesDTO : List<DTOMessage>) :  List<Message>{
        val listDTO : MutableList<Message> = mutableListOf()
        for(dto in messagesDTO){
            listDTO += toMessage(dto)
        }
        return listDTO
    }

    fun toManyDTOMessage(messages : List<Message>) : List<DTOMessage>{
        val listDTO : MutableList<DTOMessage> = mutableListOf()
        for(message in messages){
            listDTO += toDTOMessage(message)
        }
        return listDTO
    }

}