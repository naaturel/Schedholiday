<script>
    export default{
        name: "ErrorMessage",
        props:{
            message:{
                type: String,
                required: true,
                default: "My Title"
            }
        }
    }
</script>

<template>
    <p> {{ message }}</p>
</template>

<style scoped>
    p{
        color:red;
        font-size: 1.5em;
        display: none;
    }
</style>