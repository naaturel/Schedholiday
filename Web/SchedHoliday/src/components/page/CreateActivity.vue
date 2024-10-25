<script>
    import Title from '../atome/Title.vue' 
    import FormCreateActivity from '../organisme/FormCreateActivity.vue'
    export default{
        name:"Create Activity",
        components : {
            Title,
            FormCreateActivity
        },
    }
</script>

<template>
    <Title name="Créer une Activité"></Title>
    <FormCreateActivity :idHoliday=this.$route.params.id></FormCreateActivity>
</template>

<style scoped>

</style>