package be.helmo.schedholiday.infrastructure.Mapping

import be.helmo.schedholiday.model.User
import be.helmo.schedholiday.repository.User.DTOUser


class UserMapper {

    fun toUser(dto : DTOUser) : User {
        return User(
            dto.Id,
            dto.LastName,
            dto.FirstName,
            dto.Email,
        )
    }

    fun toDTOUser(user : User) : DTOUser {
        return DTOUser(
            user.id,
            user.lastName,
            user.firstName,
            user.email,
        )
    }

    fun toManyUser(usersDTO : List<DTOUser>) :  List<User>{
        val listDTO : MutableList<User> = mutableListOf()
        for(dto in usersDTO){
            listDTO += User(
                dto.Id,
                dto.LastName,
                dto.FirstName,
                dto.Email,
            )
        }
        return listDTO
    }

    fun toManyDTOUser(users : List<User>) : List<DTOUser>{
        val listDTO : MutableList<DTOUser> = mutableListOf()
        for(user in users){
            listDTO += DTOUser(
                user.id,
                user.lastName,
                user.firstName,
                user.email,
            )
        }
        return listDTO
    }

}