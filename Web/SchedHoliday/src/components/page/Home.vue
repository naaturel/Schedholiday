<script>
    import Title from '../atome/Title.vue' 
    import HolidayItem from '../molecule/HolidayItem.vue' 
    import StatUserItem from '../molecule/StatUserItem.vue' 
    import { getKeyGoogle } from '../icons/key';
    import {convertDateToEpoch} from '../icons/date'
    import Input from "@/components/atome/Input.vue";
    import Label from "../atome/Label.vue"
    export default{
        name:"Home",
        components : {
            Input,
            Title,
            HolidayItem,
            StatUserItem,
            Label
        },
        data() {
            return {
                formData: {
                    dateStart: "",
                    dateEnd: "",
                    Holidays : "",
                    countUser:0,
                    periods:[],
                    uniqueCountries: [],
                    textStart: "date de départ",
                    textEnd: "date de fin",
                },
            };
        },
        created() {
            this.fetchData()
            this.getUsers()
        },
        mounted() {
            this.displayAllHolidays()
        },

        methods: {
            async submitForm() {
                this.formData.uniqueCountries = []
                if(this.formData.dateStart !== null && this.formData.dateEnd !== null){
                    const response = await fetch(`https://porthos-intra.cg.helmo.be/Q210044/api/UserHoliday/period/${convertDateToEpoch(this.formData.dateStart)}&${convertDateToEpoch(this.formData.dateEnd)}`)
                    .then(response => response.json())
                    .then(data => this.formData.periods = data)
                }
                for (const holiday of this.formData.periods) {
                    const country = await this.getCountryFromCoordinates({lat :holiday.Latitude, lng:holiday.Longitude});
                    if(country !== null && holiday.NumberUser > 0){
                        this.ajouterNombreUtilisateurs(country, holiday.NumberUser)
                    }          
                }
                console.log(this.formData.uniqueCountries)
            },
            ajouterNombreUtilisateurs(country, numberUser) {
                for (let i = 0; i < this.formData.uniqueCountries.length; i++) {
                    if (this.formData.uniqueCountries[i].country === country) {
                        this.formData.uniqueCountries[i].numberUser += numberUser;
                        return;
                    }
                }
                this.formData.uniqueCountries.push({ country: country, numberUser: numberUser });
            },
            async getCountryFromCoordinates({ lat, lng }) {
                try {
                    const key = await getKeyGoogle('key.json')
                    const response = await fetch(`https://maps.googleapis.com/maps/api/geocode/json?latlng=${lat},${lng}&key=${key}`);
                    const data = await response.json();
                    return this.extractCountry(data)
                } catch (error) {
                    console.error('Erreur lors de la récupération du pays:', error);
                    return null;
                }
            },
            extractCountry(data) {
                if(data.results !== undefined){
                    const addressComponents = data.results[0]?.address_components || [];
                    for (const component of addressComponents) {
                        if (component.types.includes('country')) {
                            return component.long_name;
                        }
                    }
                }
                
                return null;
            },
            async fetchData() {
                await this.$store.dispatch('fetchHolidays')
                this.formData.Holidays = this.$store.getters['getHolidays']
            },

            async getUsers() {
                const user = this.$store.getters['getUserConnected']
                if(user !== null){
                    const response = await fetch('https://porthos-intra.cg.helmo.be/Q210044/api/User', {
                        method: 'GET',
                        headers: {
                            'Content-Type': 'application/json',
                            'Authorization': `Bearer ${user.Token}`,
                        },
                    })
                    .then(response => response.json())
                    .then(data => {
                        this.formData.countUser = data.length
                    })
                    .catch(error => {
                        console.error('Erreur lors de la récupération des données:', error);
                    });
                }
            },

            displayUserHolidays(){
                this.formData.Holidays = this.$store.getters['getUserHolidays']

            },

            displayAllHolidays(){
                this.formData.Holidays = this.$store.getters['getHolidays']
            }
        },

    }
    
</script>

<template>

    <Title name="Accueil"></Title>

    <div class="content">

        <div id="infos">

            <div id="userStats" class="card secondaryColor">
                <StatUserItem :UserRegister=this.formData.countUser :UserInHoliday=this.formData.Holidays.length></StatUserItem>
            </div>

            <div id="holidaysFilter" class="card secondaryColor">
                <button class="button" @click="displayAllHolidays">Tous les voyages</button>
                <button class="button" @click="displayUserHolidays">Vos voyages</button>
            </div>

            <div id="filter" class="card secondaryColor">
                <form id="filterForm" @submit.prevent="submitForm">
                    <Label :name="dateStart" :textShow=this.formData.textStart></Label>
                    <input class="formField" type="date" id="dateStart" v-model="formData.dateStart">
                    <Label :name="dateEnd" :textShow=this.formData.textEnd></Label>
                    <input class="formField" type="date" id="dateEnd" v-model="formData.dateEnd">
                    <button class="button" type="submit">Filtrer</button>
                </form>
                <ul class="itemPeriod">
                    <li v-for="item in this.formData.uniqueCountries" :key="country">nombre de personne en {{ item.country }} : {{ item.numberUser }}</li>
                </ul>
            </div>

        </div>

        <section id="holidayItem">
            <HolidayItem v-for="holiday in formData.Holidays"  :Holiday=holiday></HolidayItem>
        </section>
        
    </div>
    
</template>

<style scoped>

.content
{
    display: flex;
    flex-direction: row;
    width: 100%;
    padding: 5%;
}

#infos
{
    min-width: 25%;
    display: flex;
    flex-direction: column;
    height: fit-content;
}

#userStats
{
    display: flex;
    align-items: center;
    width: 100%;
}


#dateStart, #dateEnd
{
    width: 100%;
}

#filter, #holidaysFilter{
    margin-top: 10%;
    width: 100%;
}

#holidaysFilter
{
    display: flex;
    flex-direction: row;
    justify-content: space-around;
}

input#date
{
    width: 60%;
}

#filterForm{
    display: flex;
    flex-direction: column;
    justify-content: space-around;
    width: 100%;
}

#date
{
    width: 30%;
    height: 35px;
    margin-right: 2%;
}

.itemPeriod{
    font-size: 1.2em;
}

.button
{
    width: 30%;
    height: inherit;
    margin-top:2%;
}

</style>