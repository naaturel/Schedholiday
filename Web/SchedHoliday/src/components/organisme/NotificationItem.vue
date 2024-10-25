<script>

export default {
    name : "NotifcationItem",
    props :{
        holidayTitle : {
            type:String,
            required : true,
            default : "holiday_title_placeholder"
        },
        holidayId : {
            type:Number,
            required : true,
            default : 0
        }
    }

}

</script>

<template>

    <div class="card secondaryColor">

        <div>
            {{holidayTitle}}
        </div>

        <div class="button tertiaryColor"></div>

    </div>

</template>

<style scoped>

</style>