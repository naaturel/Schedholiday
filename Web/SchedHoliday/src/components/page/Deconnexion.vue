<script>
    import router from "@/Router";

    export default{
        name:'Deconnexion',
        created() {
            this.$store.dispatch('deconnexion')
            router.push({ name: 'connexion' })
        },
    }
</script>

<template>


</template>