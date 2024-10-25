<script>
    import Title from '../atome/Title.vue' 
    import ButtonComponent from '../atome/ButtonComponent.vue'
    import {convertDateToEpoch} from '../icons/date.js'
    import { getKeyGoogle } from '../icons/key';
    export default{
        name:"Create Holiday",
        components : {
            Title,
            ButtonComponent
        },
        data() {
            return {
                name: "",
                street : "",
                numero : "",
                locality : "",
                codePostal : "",
                dateStart : "",
                dateEnd : "",
            };
        },
        methods:{
            convertDate(date) {
                return convertDateToEpoch(date);
            },
            async convertirAdresseEnCoordonnees() {
                const adresse = `${this.street} ${this.numero}, ${this.locality} ${this.codePostal}`
                const key = await getKeyGoogle()
                const user = this.$store.getters['getUserConnected']
                const apiUrl = `https://maps.googleapis.com/maps/api/geocode/json?address=${encodeURIComponent(adresse)}&key=${key}`;
                let latitude = undefined
                let longitude = undefined
                await fetch(apiUrl)
                    .then(response => response.json())
                    .then(data => {
                        if (data.status === 'OK') {
                            latitude = data.results[0].geometry.location.lat
                            longitude = data.results[0].geometry.location.lng
                        } 
                    })
                    .catch(error => console.error('Erreur de réseau:', error))

                if(latitude === undefined && longitude === undefined){
                    alert("adresse encodé nexiste pas")
                }else if(this.convertDate(this.dateStart) > this.convertDate(this.dateEnd)){
                    alert("la date de départ ne peux pas être antérieur à la date de fin")
                }else{
                    const response = await fetch('https://porthos-intra.cg.helmo.be/Q210044/api/Holiday', {
                            method: 'POST',
                            headers: {
                                'Content-Type': 'application/json',
                                'Authorization': `Bearer ${user.Token}`,
                            },
                            body: JSON.stringify({ 
                                name: this.name, creatorId : user.Id, epochStart : this.convertDate(this.dateStart), 
                                epochEnd : this.convertDate(this.dateEnd), longitude : longitude, latitude : latitude
                            }),
                    });

                    if(response.ok){
                        alert(`le voyage ${this.name} a bien été créer`)
                        this.$router.push({ name: 'home' });
                    }else{
                        alert(`une erreur est survenu pendant la création du voyage`)
                    }
                }
            }
        }
    }
    
</script>

<template>
    <Title name="Créer un voyage"></Title>
    <form class="card secondaryColor" @submit.prevent="convertirAdresseEnCoordonnees">
        <input class="formField" type="text" id="name" v-model="name" placeholder="Nom du voyage">

        <input class="formField" type="text" id="street" v-model="street" placeholder="Rue">

        <input class="formField" type="number" id="numero" v-model="numero" placeholder="Numéro">

        <input class="formField" type="text" id="locality" v-model="locality" placeholder="Localité">

        <input class="formField" type="number" id="codePostal" v-model="codePostal" placeholder="Code postal">

        <input class="formField" type="date" id="dateStart" v-model="dateStart" placeholder="Date de début">

        <input class="formField" type="date" id="dateEnd" v-model="dateEnd" placeholder="Date de fin">

        <button class="button" type="submit">créer</button>
    </form>
</template>

<style scoped>



</style>