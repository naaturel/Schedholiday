package be.helmo.schedholiday.infrastructure.Mapping

import be.helmo.schedholiday.model.Message
import be.helmo.schedholiday.repository.Message.DTOMessage
import be.helmo.schedholiday.utils.EpochConverter
import org.junit.Assert
import org.junit.Test
import java.text.SimpleDateFormat
import java.time.LocalDateTime

class MessageMapperTest {

    private val mapper = MessageMapper()

    @Test
    fun testToMessage(){
        val dto = DTOMessage("12", 0, "sender", "id")
        val message = mapper.toMessage(dto)
        Assert.assertEquals(dto.Content, message.content)
        Assert.assertEquals(dto.Epoch, EpochConverter.toEpochSeconds(message.date))
        Assert.assertEquals(dto.Sender, message.sender)
        Assert.assertEquals(dto.HolidayId, message.holidayId)
    }
    @Test
    fun testToDTOMessage(){
        val message = Message("12", LocalDateTime.now(), "sender", "id")
        val dto = mapper.toDTOMessage(message)
        Assert.assertEquals(dto.Content, message.content)
        Assert.assertEquals(dto.Epoch, EpochConverter.toEpochSeconds(message.date))
        Assert.assertEquals(dto.Sender, message.sender)
        Assert.assertEquals(dto.HolidayId, message.holidayId)
    }
    @Test
    fun testToManyMessage(){
        val listDTO = mutableListOf<DTOMessage>()
        for(i in 1..4){
            listDTO += DTOMessage("12", 0, "sender", "id")
        }
        val listMessage = mapper.toManyMessage(listDTO)
        for(i in 0..3){
            Assert.assertEquals(listDTO[i].Content, listMessage[i].content)
            Assert.assertEquals(listDTO[i].Epoch, EpochConverter.toEpochSeconds(listMessage[i].date))
            Assert.assertEquals(listDTO[i].Sender, listMessage[i].sender)
            Assert.assertEquals(listDTO[i].HolidayId, listMessage[i].holidayId)
        }

    }
    @Test
    fun testToManyDTOMessage(){
        val listMessage = mutableListOf<Message>()
        for(i in 1..4){
            listMessage += Message("12", LocalDateTime.now(), "sender", "id")
        }
        val listDTO = mapper.toManyDTOMessage(listMessage)
        for(i in 0..3){
            Assert.assertEquals(listDTO[i].Content, listMessage[i].content)
            Assert.assertEquals(listDTO[i].Epoch, EpochConverter.toEpochSeconds(listMessage[i].date))
            Assert.assertEquals(listDTO[i].Sender, listMessage[i].sender)
            Assert.assertEquals(listDTO[i].HolidayId, listMessage[i].holidayId)
        }
    }

}