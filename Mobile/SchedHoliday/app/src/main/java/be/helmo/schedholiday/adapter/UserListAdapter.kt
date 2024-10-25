package be.helmo.schedholiday.adapter

import android.annotation.SuppressLint
import android.view.LayoutInflater
import android.view.ViewGroup
import androidx.recyclerview.widget.RecyclerView
import be.helmo.schedholiday.databinding.ActivityItemUserBinding
import be.helmo.schedholiday.model.User

class UserListAdapter (
    private val users: List<User>
) : RecyclerView.Adapter<UserListHolder>(){

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int) : UserListHolder {
        val inflater = LayoutInflater.from(parent.context)
        val binding = ActivityItemUserBinding.inflate(inflater, parent, false)

        return UserListHolder(binding)
    }

    override fun onBindViewHolder(holder: UserListHolder, position: Int) {
        holder.bind(users[position].firstName, users[position].lastName)
    }

    override fun getItemCount() = users.size

}

class UserListHolder(val binding: ActivityItemUserBinding) : RecyclerView.ViewHolder(binding.root) {
    @SuppressLint("SetTextI18n")
    fun bind(firstName : String, lastName : String) {
        binding.userItem.text = "$firstName $lastName"
    }
}