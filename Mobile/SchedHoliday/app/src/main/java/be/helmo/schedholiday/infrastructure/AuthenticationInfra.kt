package be.helmo.schedholiday.infrastructure

import be.helmo.schedholiday.exception.UserException
import be.helmo.schedholiday.repository.Authentication.DTOAuthenticationRequest
import be.helmo.schedholiday.repository.User.DTOAuthenticationResponse
import be.helmo.schedholiday.repository.User.DTOUser
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.withContext
import okhttp3.MediaType
import okhttp3.OkHttpClient
import okhttp3.Request
import okhttp3.RequestBody
import java.io.IOException


class AuthenticationInfra : Infra() {

    private val URL = super.BASE_URL+ "Authentication"

    suspend fun authenticate(auth: DTOAuthenticationRequest) : DTOAuthenticationResponse {

        try {
            val JSON = MediaType.parse("application/json; charset=utf-8")
            val client = OkHttpClient()

            val body: RequestBody = RequestBody.create(JSON, auth.toJson());

            val request: Request = Request.Builder()
                .url(URL)
                .post(body)
                .build()

            val response = withContext(Dispatchers.IO) {
                client.newCall(request).execute()
            }
            if (response.isSuccessful) {
                val userInfo: String? = response.body()?.string()
                return DESERIALIZER.fromJson(userInfo, DTOAuthenticationResponse::class.java)
            }

            throw UserException("Bad credentials")

        } catch (e: IOException) {
            throw UserException("Une erreur est survenue lors de la connexion.")
        }
    }

}