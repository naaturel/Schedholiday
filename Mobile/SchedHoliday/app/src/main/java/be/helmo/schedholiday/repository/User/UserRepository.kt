package be.helmo.schedholiday.repository.User

import be.helmo.schedholiday.infrastructure.Mapping.UserMapper
import be.helmo.schedholiday.model.User
import be.helmo.schedholiday.infrastructure.UserInfrastructure

class UserRepository : IUserRepository {

    private val userInfrasctructure = UserInfrastructure()
    private val userMapper = UserMapper()

    override suspend fun registerUser(user: User) = userInfrasctructure.registerUser(userMapper.toDTOUser(user))

    override suspend fun getUser(email: String) : User?{
        val user = userInfrasctructure.getUser(email)
        if(user == null) {
            return user
        }
        return userMapper.toUser(user)
    }

}