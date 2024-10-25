package be.helmo.schedholiday.adapter

import android.view.LayoutInflater
import android.view.ViewGroup
import androidx.recyclerview.widget.RecyclerView
import be.helmo.schedholiday.databinding.ItemScheduleBinding
import be.helmo.schedholiday.model.Activity

class ScheduleItemAdapter(
    private val activities: List<Activity>
) : RecyclerView.Adapter<ScheduleItemHolder>() {

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int) : ScheduleItemHolder{
        val inflater = LayoutInflater.from(parent.context)
        val binding = ItemScheduleBinding.inflate(inflater, parent, false)

        return ScheduleItemHolder(binding)
    }

    override fun onBindViewHolder(holder: ScheduleItemHolder, position: Int) {
        holder.bind(activities[position])
    }

    override fun getItemCount() = activities.size
}


class ScheduleItemHolder(val binding: ItemScheduleBinding) : RecyclerView.ViewHolder(binding.root){
    fun bind(activity: Activity){

        binding.itemName.text = activity.name
        binding.itemDescription.text = activity.description
        binding.itemStartDate.text = activity.startDate.toString()
        binding.itemEndDate.text = activity.endDate.toString()
    }
}
