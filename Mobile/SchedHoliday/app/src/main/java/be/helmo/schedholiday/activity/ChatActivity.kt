package be.helmo.schedholiday.activity

import android.content.Context
import android.content.Intent
import be.helmo.schedholiday.databinding.ActivityChatBinding
import android.os.Bundle
import android.widget.Toast
import androidx.activity.viewModels
import androidx.appcompat.app.AppCompatActivity
import androidx.lifecycle.lifecycleScope
import be.helmo.schedholiday.adapter.ChatAdapter
import be.helmo.schedholiday.viewModel.ChatViewModel
import kotlinx.coroutines.launch

private var EXTRA_ID_HOLIDAY = ""
interface IDisplayChatStatus{
    fun notifyConnectionState(msg : String)
}

class ChatActivity : AppCompatActivity(), IDisplayChatStatus{

    private lateinit var binding: ActivityChatBinding
    private val viewModel : ChatViewModel by viewModels()

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityChatBinding.inflate(layoutInflater)

        viewModel.loadMessages(EXTRA_ID_HOLIDAY)

        viewModel.connect(EXTRA_ID_HOLIDAY)

        lifecycleScope.launch {
            viewModel.liveMessages.observeForever{ messages ->
                binding.chatRecyclerView.adapter = ChatAdapter(messages)
            }
        }

        viewModel.setCallBackInterfaces(this)

        binding.sendMessageButton.setOnClickListener{
            val content = binding.editMessageContent.text.toString()
            viewModel.sendMessage(content, EXTRA_ID_HOLIDAY)
            binding.editMessageContent.text.clear()
        }

        setContentView(binding.root)
    }

    override fun onStop() {
        super.onStop()
        viewModel.disconnect()
    }

    override fun onPause() {
        super.onPause()
        viewModel.disconnect()
    }

    override fun onDestroy() {
        super.onDestroy()
        viewModel.disconnect()
    }

    override fun notifyConnectionState(msg : String) {
        Toast.makeText(this@ChatActivity, msg, Toast.LENGTH_SHORT).show()
    }

    companion object{
        fun newIntent(packageContext: Context, idHoliday: String): Intent {
            return Intent(packageContext, ChatActivity::class.java).apply{
                    EXTRA_ID_HOLIDAY = idHoliday
            }
        }
    }


}