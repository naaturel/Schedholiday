package be.helmo.schedholiday.repository.User

import be.helmo.schedholiday.model.User

interface IUserRepository{

    suspend fun registerUser(user: User) : Boolean

    suspend fun getUser(email : String) : User?

    companion object {
        private var INSTANCE : UserRepository? = null

        fun initialize(repo:UserRepository){
            if(INSTANCE == null){
                INSTANCE = repo
            }
        }

        fun get() : UserRepository {
            return INSTANCE ?: throw IllegalStateException("UserRepository must be initialized")
        }

    }

}