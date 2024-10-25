<script>
    import {getKeyMeteo} from '../icons/key'
    import {getDay,getWeather,getIcon} from '../icons/dayMeteo'
    import ItemMeteo from '../molecule/ItemMeteo.vue'
    import {convertEpochToDate} from '../icons/date'
    import {convertKelvinToCelsius} from '../icons/temperature'
    export default{
        name:"Details",
        components : {
            ItemMeteo,
        },
        async created(){
            await this.getMeteo()
        },
        data(){
            return {
                responseMeteo: ""
            }
        },
        props:{
            latitude:{
                type: Number,
                required: true,
                default: 0.0
            },
            longitude:{
                type: Number,
                required: true,
                default: 0.0
            }
        },
        watch: {
            latitude: 'getMeteo',
            longitude: 'getMeteo'
        },
        methods:{
            async getMeteo(){
                const user = this.$store.getters['getUserConnected']
                try {
                    await fetch(`https://porthos-intra.cg.helmo.be/Q210044/api/Meteo/${this.latitude}&${this.longitude}`, {
                        method: 'GET',
                        headers: {
                            'Content-Type': 'application/json',
                            'Authorization': `Bearer ${user.Token}`,
                        }
                    })
                    .then(response => response.json())
                    .then(data => this.responseMeteo = getDay(data.list))
                } catch (error) {
                    console.error('Erreur lors de la récupération des données météo :', error)
                }
            },
            convertDate(date) {
                return convertEpochToDate(date);
            },
            convertTemp(kelvin) {
                return convertKelvinToCelsius(kelvin);
            },
            getWeatherFR(weather){
                return getWeather(weather)
            },
            getImage(icon){
                return getIcon(icon)
            }
        }
    }
</script>

<template>
    <h2> Météo </h2>
    <div id="meteo">
        <ItemMeteo v-if="this.responseMeteo.length > 0" v-for="day in this.responseMeteo" 
            :dateEpoch=convertDate(day.dt) :temp=convertTemp(day.main.temp) :weather= getWeatherFR(day.weather[0].main) :icon=getImage(day.weather[0].icon)>
        </ItemMeteo>

        <div v-else>
            Chargement des données météo...
        </div>

    </div>
</template>

<style scoped>

#meteo{
    width: 100%;
    display : flex;
    justify-content: center;
    flex-flow: row wrap;
    row-gap: 20px;
}

</style>