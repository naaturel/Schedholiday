<script>
    import Title from '../atome/Title.vue' 
    export default{
        name:"Error",
        components : {
            Title
        }
    }
    
</script>

<template>
    <Title name="Erreur"></Title>
    <div class="container">
        <div class="text">
            <p> Une erreur est servenu</p>
            <p> Essayer de recharger la page ou de revenir en arrrière</p>
            <p> Si le problème persiste, merci de contacter un admin</p>
        </div>
    </div>
</template>

<style scoped>
    .container {
      display: flex;
      flex-direction: row;
      align-items: flex-start;
    }
    
    .text {
      flex: 1;
    }

    .text p{
        font-size:2.5em;
        padding-bottom: 10%;
        width:100%;
    }

    img {
        width:50%;
        height:40%;
    }
</style>