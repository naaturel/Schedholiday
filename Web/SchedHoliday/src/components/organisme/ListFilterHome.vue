<script>
    import Title from '../atome/Title.vue' 
    import HolidayItem from '../molecule/HolidayItem.vue' 
    import StatUserItem from '../molecule/StatUserItem.vue' 
    export default{
        name:"Home",
        components : {
            Title,
            HolidayItem,
            StatUserItem
        },
        props:{
            numberRegister:{
                type: Number,
                required : true,
                default:0
            }
        },
        data() {
            return {
                formData: {
                    date: "",
                    Holidays : ""
                },
            };
        },
        methods: {
            
        },
    }
    
</script>

<template>
    
</template>

<style scoped>


</style>