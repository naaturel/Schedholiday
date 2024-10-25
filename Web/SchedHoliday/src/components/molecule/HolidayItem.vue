<script>
import ButtonComponent from '../atome/ButtonComponent.vue'
import {convertEpochToDate} from '../icons/date.js'
import DeleteHoliday from "@/components/organisme/DeleteHoliday.vue";
import {getKeyGoogle} from "@/components/icons/key";

export default{
        name: "Holiday Item",
        components : {
          DeleteHoliday,
            ButtonComponent,
        },
        props:{
            Holiday : {
                type:Object,
                required : true,
                default : null
            },
        },
        methods:{
            convertDate(date) {
                return convertEpochToDate(date);
            },

            goToDetails() {
                this.$router.push({ name: 'detailHoliday', params: { id: this.Holiday.Id } })
            },
        }
    }

</script>

<template>
    <div :id= this.Holiday.Id class="card secondaryColor" @click="goToDetails">
        <h3>{{this.Holiday.Name}}</h3>
        <p>Départ : {{ this.convertDate(this.Holiday.EpochStart) }}</p>
        <p>Retour : {{ this.convertDate(this.Holiday.EpochEnd) }}</p>
        <DeleteHoliday></DeleteHoliday>
    </div>
</template>

<style scoped>

div
{
    width:30%;
    margin-right: 2%;
    margin-bottom: 2%;
}

div:hover
{
    cursor: pointer;
}

h3, p
{
    word-wrap: anywhere;
}

h3
{
    text-align: center;
    font-size: 1.6em;
    padding-bottom: 20px;
}

p
{
    font-size: 1.4em;
    padding-bottom: 20px;
}
</style>