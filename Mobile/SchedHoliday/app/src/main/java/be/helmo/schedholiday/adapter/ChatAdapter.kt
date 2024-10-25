package be.helmo.schedholiday.adapter

import android.view.LayoutInflater
import android.view.ViewGroup
import androidx.recyclerview.widget.RecyclerView
import be.helmo.schedholiday.R
import be.helmo.schedholiday.databinding.ItemChatBinding
import be.helmo.schedholiday.model.Message

class ChatAdapter(
    private val messages : MutableList<Message>
)  : RecyclerView.Adapter<ChatAdapter.MessageViewHolder>()  {

    class MessageViewHolder(
        val binding: ItemChatBinding,
    ) : RecyclerView.ViewHolder(binding.root){
        var sender = binding.messageSenderName
        var date = binding.messageDateTime
        var content = binding.chatMessageContent

    }

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int):  MessageViewHolder {
        val inflater = LayoutInflater.from(parent.context)
        val binding = ItemChatBinding.inflate(inflater, parent, false)
        return MessageViewHolder(binding)
    }

    override fun getItemCount(): Int = messages.count()

    override fun onBindViewHolder(holder: MessageViewHolder, position: Int) {

        val message = messages[position]

        holder.apply {
            content.text = message.content
            date.text = message.date.toString()
            sender.text = message.sender
        }
    }
}
