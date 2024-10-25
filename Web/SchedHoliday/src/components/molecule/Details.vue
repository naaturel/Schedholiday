<script>
    import Date from '../atome/Date.vue'
    import {convertEpochToDate} from '../icons/date.js'
    export default{
        name:"Details",
        components : {
            Date,
        },
        props:{
            EpochStart:{
                type: Number,
                required: true,
                default: 0
            },
            EpochEnd:{
                type: Number,
                required: true,
                default: 0
            },
            Location:{
                type: String,
                required:true,
                default:"Nowhere"
            }
        },

        data(){
            return {
                textStart: "date de départ ",
                textEnd: "date de fin "
            }
        },
        methods:{
            convertDate(date) {
                return convertEpochToDate(date);
            },

        }
    }
</script>

<template>
    <div class="card secondaryColor">
        <p> Adresse : {{this.Location}}</p>
        <Date :dateName=this.textStart :date=this.convertDate(this.EpochStart)></Date>
        <Date :dateName=this.textEnd :date=this.convertDate(this.EpochEnd)></Date>
    </div>
</template>

<style scoped>

div
{
    width: 100%;
}

</style>