package be.helmo.schedholiday.fragments

import android.content.Context
import android.os.Bundle
import android.util.Log
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.fragment.app.Fragment
import androidx.fragment.app.activityViewModels
import androidx.lifecycle.Lifecycle
import androidx.lifecycle.lifecycleScope
import androidx.lifecycle.repeatOnLifecycle
import be.helmo.schedholiday.adapter.ChatAdapter
import be.helmo.schedholiday.adapter.HolidayListAdapter
import be.helmo.schedholiday.adapter.ISwitchMain
import be.helmo.schedholiday.viewModel.MainViewModel
import be.helmo.schedholiday.databinding.FragmentListHolidayBinding
import kotlinx.coroutines.launch

class HolidayListFragment : Fragment() {

    private val viewModel: MainViewModel by activityViewModels()
    private lateinit var switchMain: ISwitchMain

    private var _binding: FragmentListHolidayBinding? = null
    private val binding
        get() = checkNotNull(_binding) {
            "Cannot access binding bacause it is null. Is the view is Visible ?"
        }

    override fun onCreateView(inflater: LayoutInflater, container: ViewGroup?, savedInstanceState: Bundle?): View? {
        _binding = FragmentListHolidayBinding.inflate(inflater, container, false)

        binding.createHolidaysButton.setOnClickListener {
            switchMain.switchCreateHoliday()
        }

        return binding.root
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)
        viewLifecycleOwner.lifecycleScope.launch{
            viewModel.holidays.observeForever{
                binding.holidayRecyclerView.adapter = HolidayListAdapter(it.toList(), switchMain)
            }
        }
    }
    
    override fun onDestroyView() {
        super.onDestroyView()
        _binding = null
    }

    override fun onAttach(context: Context) {
        super.onAttach(context)
        if(context is ISwitchMain){
            switchMain = context
        }
    }
}