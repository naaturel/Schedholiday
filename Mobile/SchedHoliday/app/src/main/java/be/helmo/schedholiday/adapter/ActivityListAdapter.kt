package be.helmo.schedholiday.adapter

import android.view.LayoutInflater
import android.view.ViewGroup
import androidx.recyclerview.widget.RecyclerView
import be.helmo.schedholiday.databinding.ItemActivityBinding
import be.helmo.schedholiday.model.Activity

class ActivityListAdapter(
    private val activities : List<Activity>
)  : RecyclerView.Adapter<ActivityListAdapter.ActivityViewHolder>() {

    class ActivityViewHolder(
        val binding: ItemActivityBinding) : RecyclerView.ViewHolder(binding.root){
            val infos = binding.itemInfos
    }

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ActivityViewHolder {
        val inflater = LayoutInflater.from(parent.context)
        val binding = ItemActivityBinding.inflate(inflater, parent, false)

        return ActivityViewHolder(binding)
    }

    override fun onBindViewHolder(holder: ActivityViewHolder, position: Int) {
        holder.apply {
            infos.text = activities[position].toString()
        }
    }

    override fun getItemCount(): Int = activities.count()

}