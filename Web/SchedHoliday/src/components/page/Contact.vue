<script>
    import Title from '../atome/Title.vue' 
    import FormContact from '../organisme/FormContact.vue' 
    export default{
        name:"Contact",
        components : {
            Title,
            FormContact
        }
    }
    
</script>

<template>
    <Title name="Contacter un Admin"></Title>
    <FormContact></FormContact>
</template>

<style scoped>

</style>