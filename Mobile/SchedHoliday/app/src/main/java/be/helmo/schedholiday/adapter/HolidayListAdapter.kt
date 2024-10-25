package be.helmo.schedholiday.adapter

import android.util.Log
import android.view.LayoutInflater
import android.view.ViewGroup
import androidx.recyclerview.widget.RecyclerView
import be.helmo.schedholiday.model.Holiday
import be.helmo.schedholiday.databinding.ActivityItemHolidayBinding
import be.helmo.schedholiday.databinding.ItemListHolidayBinding
import java.text.SimpleDateFormat

class HolidayListAdapter(
    private val holidays: List<Holiday>,
    private val interfaceMain: ISwitchMain) : RecyclerView.Adapter<HolidayListHolder>(){

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int) : HolidayListHolder {
        val inflater = LayoutInflater.from(parent.context)
        val binding = ItemListHolidayBinding.inflate(inflater, parent, false)

        return HolidayListHolder(binding)
    }

    override fun onBindViewHolder(holder: HolidayListHolder, position: Int) {
        val holiday = holidays[position]
        holder.bind(holiday, interfaceMain)
    }

    override fun getItemCount() = holidays.size

}

class HolidayListHolder(val binding: ItemListHolidayBinding) : RecyclerView.ViewHolder(binding.root){
    fun bind(holiday : Holiday, interfaceMain: ISwitchMain){

        binding.itemHolidayTitle.text = holiday.name
        binding.itemHolidayDate.text = holiday.getFormattedDate()

        binding.buttonDetails.setOnClickListener{
            interfaceMain.switchDetail(holiday.id)
        }

    }
}