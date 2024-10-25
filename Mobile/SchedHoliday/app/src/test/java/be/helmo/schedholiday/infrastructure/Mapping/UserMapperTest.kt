package be.helmo.schedholiday.infrastructure.Mapping

import be.helmo.schedholiday.model.User
import be.helmo.schedholiday.repository.User.DTOUser
import org.junit.Assert.assertEquals
import org.junit.Test

class UserMapperTest {

    private val mapper = UserMapper()

    @Test
    fun testToUser() {
        val dto = DTOUser(
            "12", "test", "test",
            "test"
        )
        val user = mapper.toUser(dto)
        assertEquals(dto.Id, user.id)
        assertEquals(dto.LastName, user.lastName)
        assertEquals(dto.FirstName, user.firstName)
        assertEquals(dto.Email, user.email)
    }
    @Test
    fun testToDTOUser(){
        val user = User("12", "test", "test",
            "test")
        val dto = mapper.toDTOUser(user)
        assertEquals(dto.Id, user.id)
        assertEquals(dto.LastName, user.lastName)
        assertEquals(dto.FirstName, user.firstName)
        assertEquals(dto.Email, user.email)
    }
    @Test
    fun testToManyUser(){
        val listDTO = mutableListOf<DTOUser>()
        for(i in 1..4){
            listDTO += DTOUser((i+10).toString(), "test", "test",
                "email")
        }
        val listUser = mapper.toManyUser(listDTO)
        for(i in 0..3){
            assertEquals(listDTO[i].Id, listUser[i].id)
            assertEquals(listDTO[i].LastName, listUser[i].lastName)
            assertEquals(listDTO[i].FirstName, listUser[i].firstName)
            assertEquals(listDTO[i].Email, listUser[i].email)
        }

    }
    @Test
    fun testToManyDTOUser(){
        val listUser = mutableListOf<User>()
        for(i in 1..4){
            listUser += User((i+10).toString(), "test", "test",
                "email")
        }
        val listDTO = mapper.toManyDTOUser(listUser)
        for(i in 0..3){
            assertEquals(listDTO[i].Id, listUser[i].id)
            assertEquals(listDTO[i].LastName, listUser[i].lastName)
            assertEquals(listDTO[i].FirstName, listUser[i].firstName)
            assertEquals(listDTO[i].Email, listUser[i].email)
        }
    }

}