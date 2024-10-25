<script>
    export default{
        name: "Holiday Item",
        props:{
            UserRegister:{
                type: Number,
                required: true,
                default: 0
            },
            UserInHoliday:{
                type: String,
                required: true,
                default: "0"
            },
        }
    }
</script>

<template>
    <div id="Users">
        <p> {{ UserRegister }} utilisateurs inscrits </p>
        <p> {{ UserInHoliday }} vacances créées </p>
    </div>
</template>

<style scoped>
    p{
        font-size: 1.25em;
        margin-top: 5%;
        margin-bottom: 5%;
    }
</style>