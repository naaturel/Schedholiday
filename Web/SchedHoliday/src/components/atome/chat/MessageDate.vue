<template>
    <div>{{this.date}}</div>
</template>

<script>
export default {
    name: "MessageDate",
    props: {
        date: {
            type: String,
            required: true
        }
    }
}
</script>

<style scoped>

</style>