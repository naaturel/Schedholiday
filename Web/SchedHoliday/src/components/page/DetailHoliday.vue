<script>
import Details from '../molecule/Details.vue'
import UserList from '../organisme/UserList.vue'
import Meteo from '../organisme/Meteo.vue'
import Title from '../atome/Title.vue'
import ActivityList from '../organisme/ActivityList.vue'
import Chat from "@/components/organisme/Chat.vue";
import {getKeyGoogle} from "@/components/icons/key";

export default{
    name:"Detail Holiday",
    components : {
        Chat,
        Details,
        Title,
        UserList,
        Meteo,
        ActivityList
    },
     async created(){
         await this.getHoliday()
         await this.getLocationFromCoords({lat: this.holiday.Latitude, lng: this.holiday.Longitude})
    },

    data(){
        return {
            holiday: "",
            location:""
        }
    },
    methods:{
        async getHoliday(){
            const user = this.$store.getters['getUserConnected']
            try {
                const response = await fetch(`https://porthos-intra.cg.helmo.be/Q210044/api/Holiday/${this.$route.params.id}`, {
                    method: 'GET',
                    headers: {
                        'Content-Type': 'application/json',
                        'Authorization': `Bearer ${user.Token}`,
                    }
                })
                .then(response => response.json())
                .then(data => this.holiday = data)
            } catch (error) {
                console.error('Erreur lors du chargement du voyage:', error.message);
            }
        },

        async getLocationFromCoords({ lat, lng }) {
            try {
                const key = await getKeyGoogle('../key.json')
                const response = await fetch(`https://maps.googleapis.com/maps/api/geocode/json?latlng=${lat},${lng}&key=${key}`);
                this.$data.location = await response.json().then(data => {
                    return data.results[0].formatted_address
                })
            } catch (error) {
                console.error('Erreur lors de la récupération du pays:', error);
                return null;
            }
        }
    }
}
</script>

<template>
    <Title :name=this.holiday.Name></Title>

    <div id="body">

        <div id="infos">

            <div id="activities">
                <ActivityList :idHoliday="this.$route.params.id"></ActivityList>
            </div>

            <div id="meteo">
                <Meteo v-if="this.holiday && this.holiday.Latitude && this.holiday.Longitude" :latitude="holiday.Latitude" :longitude="holiday.Longitude"></Meteo>
            </div>

        </div>

        <div id="side">
            <div id="date">
                <Details :EpochStart=this.holiday.EpochStart :EpochEnd=this.holiday.EpochEnd :Location=this.$data.location></Details>
            </div>

            <Chat></Chat>

            <div id="users">
                <UserList :idHoliday=this.$route.params.id></UserList>
            </div>
        </div>

    </div>


</template>

<style scoped>


#body
{
    display: flex;
    flex-direction: row;
    justify-content: space-between;
    width: 95%;
}


#infos
{
    display: flex;
    flex-direction: column;
    width: 70%;
}

#side
{
    display: flex;
    flex-direction: column;
    width: 25%;
}

#date
{
    margin-bottom: 5%;
}

#activities, #meteo
{
    padding: 2%;
    margin-bottom: 5%;
    border: solid black 1px;
    border-radius: 5px;
    box-shadow: rgba(0, 0, 0, 0.25) 0 5px 10px;
}

</style>