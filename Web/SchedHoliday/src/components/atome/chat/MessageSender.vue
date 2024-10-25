<template>
    <div>{{this.name}}</div>
</template>

<script>
export default {
    name: "MessageSender",
    props:{
        name:{
            type: String,
            required : true
        }
    },
}
</script>

<style scoped>

</style>