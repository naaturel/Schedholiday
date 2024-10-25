<script>
    import {convertEpochToDateAndHours,triCroissant,triDecroissant,convertEpochToDateCalender} from '../icons/date'
    import ActivityItem from '../molecule/ActivityItem.vue'
    export default{
        name:"Details",
        components : {
            ActivityItem,
        },
        props:{
            idHoliday:{
                type: String,
                required: true,
                default: ""
            },
        },
        async created(){
            await this.getActivity()
        },
        data(){
            return {
                activityList: [],
                sortOrder: 'asc'
            }
        },
        watch:{
            idHoliday: 'getActivity'
        },
        methods:{
            async getActivity(){
                const user = this.$store.getters['getUserConnected']
                try {
                    await fetch(`https://porthos-intra.cg.helmo.be/Q210044/api/Activity/holiday/${this.idHoliday}`, {
                        method: 'GET',
                        headers: {
                            'Content-Type': 'application/json',
                            'Authorization': `Bearer ${user.Token}`,
                        }
                    })
                    .then(response => response.json())
                    .then(data => this.activityList = triCroissant(data))
                } catch (error) {
                    console.error('Erreur lors de la récupération des données activités :', error)
                }
            },
            convertDate(date) {
                return convertEpochToDateAndHours(date);
            },
            trierActivityCroissant(activities) {
                return triCroissant(activities);
            },
            trierActivityDecroissant(activities) {
                return triDecroissant(activities);
            },
            sortedActivities() {
                if (this.sortOrder === 'asc') {
                    this.sortOrder = 'desc'
                    this.activityList = this.trierActivityDecroissant(this.activityList);
                } else {
                    this.sortOrder = 'asc'
                    this.activityList = this.trierActivityCroissant(this.activityList);
                }
                
            },
            importActivity(){
                let icsBody = 'BEGIN:VCALENDAR\n' +
                    'VERSION:2.0\n' +
                    'PRODID:Calendar\n' +
                    'CALSCALE:GREGORIAN\n' +
                    'METHOD:PUBLISH\n'
                this.activityList.forEach(activity => {
                    icsBody +='BEGIN:VEVENT\n' +
                    `SUMMARY: ${activity.Name} \n` +
                    'UID:@Default\n' +
                    'SEQUENCE:0\n' +
                    'STATUS:CONFIRMED\n' +
                    'TRANSP:TRANSPARENT\n' +
                    `DTSTART;TZID=Paris:${convertEpochToDateCalender(activity.EpochStart)}\n` +
                    `DTEND;TZID=Paris:${convertEpochToDateCalender(activity.EpochEnd)}\n` +
                    `DTSTAMP:${convertEpochToDateCalender(Date.now()/1000)}\n` +
                    `DESCRIPTION:${activity.Description}\n` +
                    'END:VEVENT\n'
                })
                
                icsBody += 'END:VCALENDAR\n'

                var blob = new Blob([icsBody], { type: 'text/calendar' })
                var url = window.URL.createObjectURL(blob)

                const link = document.createElement('a')
                link.href = url
                link.download = 'calendrier.ics'
                link.style.display = 'none'

                document.body.appendChild(link)
                link.click()

                document.body.removeChild(link)
                URL.revokeObjectURL(url)
            }
        }
    }
</script>

<template>
    <h2> Emploi du temps </h2>

    <div id="optionsSchedule">
        <router-link :to="{ name: 'createActivity', params: { id: this.$route.params.id } }">créer une activité</router-link>
        <button @click="sortedActivities">Changer l'ordre</button>
        <button @click="importActivity">importer dans calendrier</button>
    </div>
    
    <div id="schedule">
        <ActivityItem class="card secondaryColor" v-if="this.activityList.length > 0" v-for="activity in this.activityList"
            :name="activity.Name" :description="activity.Description" :dateStart="this.convertDate(activity.EpochStart)" :dateEnd="this.convertDate(activity.EpochEnd)">
        </ActivityItem>

        <div v-else>Aucune activité pour le moment...</div>

    </div>
</template>

<style scoped>

#schedule{
    width: 100%;
    display : flex;
    justify-content: center;
    flex-direction: row;
    flex-wrap: wrap;
    margin-top: 2%;
}

#optionsSchedule{
    width: 50%;
    display : flex;
    justify-content: space-around;
    flex-direction: row;
    flex-wrap: wrap;
}


</style>