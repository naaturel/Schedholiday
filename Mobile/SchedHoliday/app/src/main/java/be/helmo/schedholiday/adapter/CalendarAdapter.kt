package be.helmo.schedholiday.adapter

import android.graphics.Color
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView
import be.helmo.schedholiday.R
import be.helmo.schedholiday.activity.IDisplayComponents
import be.helmo.schedholiday.databinding.ItemCalendarCellBinding
import be.helmo.schedholiday.model.Activity

class CalendarAdapter(
    private val schedule: Map<String, List<Activity>>,
    private val callBack: IDisplayComponents
) : RecyclerView.Adapter<CalendarAdapter.CalendarViewHolder>() {

    private var highlithedCell : TextView? = null

    class CalendarViewHolder(val binding: ItemCalendarCellBinding) : RecyclerView.ViewHolder(binding.root) {
        val layout = binding.layoutItemCell
        val dayCell = binding.cellDay
        val hasActivity = binding.hasActivity
        var dayActivities = mutableListOf<Activity>()

    }

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): CalendarViewHolder {

        val inflater = LayoutInflater.from(parent.context)
        val binding = ItemCalendarCellBinding.inflate(inflater, parent, false)
        return CalendarViewHolder(binding)
    }

    override fun onBindViewHolder(holder: CalendarViewHolder, position: Int) {

        val day = schedule.keys.elementAt(position)
        val activities = schedule[day]

        if(day.toInt() <= 0) return

        holder.apply {
            dayCell.text = day

            if (!activities.isNullOrEmpty()) {
                hasActivity.visibility = View.VISIBLE
                dayActivities.addAll(activities)
            }

            layout.setOnClickListener {

                highLightCell(dayCell)

                callBack.displayAddActivityButton()
                callBack.updateSelectedDate(day.toInt())

                callBack.displayDayActivities(activities!!)
            }
        }
    }

    override fun getItemCount(): Int = schedule.size

    private fun highLightCell(dayCell : TextView){
        highlithedCell?.setBackgroundColor(Color.parseColor("#ffffffff"))
        highlithedCell = dayCell
        dayCell.setBackgroundColor(Color.parseColor("#76f478"));
    }


}

