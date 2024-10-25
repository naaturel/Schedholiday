<script>
    export default{
        name:"HomeFilterItem",
        props:{
            country:{
                type: String,
                required: true,
                default: ""
            },
            numberUser:{
                type: Number,
                required: true,
                default: 0
            }
        },
        data(){
            return {
                textStart: "date de départ ",
                textEnd: "date de fin "
            }
        },
    }
</script>

<template>
    <div class="card secondaryColor">
        <p>{{ this.country }} : {{ this.numberUser }}</p>
    </div>
</template>