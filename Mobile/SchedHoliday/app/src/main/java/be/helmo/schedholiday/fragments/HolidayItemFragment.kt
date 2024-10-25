package be.helmo.schedholiday.fragments

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.fragment.app.Fragment
import be.helmo.schedholiday.databinding.ActivityItemHolidayBinding
import be.helmo.schedholiday.databinding.ItemListHolidayBinding

class HolidayItemFragment : Fragment() {

    private var _binding: ItemListHolidayBinding? = null
    private val binding
        get() = checkNotNull(_binding) {
            "Cannot access binding bacause it is null. Is the view is Visible ?"
        }

    private lateinit var nameHoliday: String
    private lateinit var dateHoliday: String

    override fun onCreateView(
        inflater: LayoutInflater,
        container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        _binding = ItemListHolidayBinding.inflate(layoutInflater, container, false)
        return binding.root
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)
        binding.apply {
            itemHolidayTitle.text = nameHoliday
            itemHolidayDate.text = dateHoliday
        }
    }

    override fun onDestroyView() {
        super.onDestroyView()
        _binding = null
    }

}