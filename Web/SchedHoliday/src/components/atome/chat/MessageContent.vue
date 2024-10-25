

<script>
export default {
    name: "message",
    props:{
        content:{
            type: String,
            required : true
        }
    },
}
</script>

<template>
    <div class="tertiaryColor">{{this.content}}</div>
</template>

<style scoped>

div
{
    word-wrap: anywhere;
    max-width: 95%;
    width: fit-content;
    border-radius: 5px;
    padding: 5%;
}
</style>