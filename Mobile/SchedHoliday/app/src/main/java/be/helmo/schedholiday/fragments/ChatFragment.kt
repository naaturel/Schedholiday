package be.helmo.schedholiday.fragments

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.fragment.app.Fragment
import androidx.fragment.app.activityViewModels
import androidx.lifecycle.Observer
import be.helmo.schedholiday.adapter.ChatAdapter
import be.helmo.schedholiday.databinding.FragmentChatBinding
import be.helmo.schedholiday.model.Message
import be.helmo.schedholiday.viewModel.ChatViewModel

class ChatFragment : Fragment() {

    private var _binding : FragmentChatBinding? = null
    private val binding
        get() = checkNotNull(_binding) {
            "Cannot access binding because it is null. Is the view is Visible ?"
        }

    private val messageObserver = Observer<MutableList<Message>> { messages ->
        binding.chatRecyclerView.adapter = ChatAdapter(messages)
    }

    private val viewModel : ChatViewModel by activityViewModels()

    override fun onCreateView(
        inflater: LayoutInflater,
        container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View {
        _binding = FragmentChatBinding.inflate(inflater, container, false)

        return binding.root
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)
        viewModel.liveMessages.observe(viewLifecycleOwner, messageObserver)
    }
}