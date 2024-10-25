<script>
    import Title from '../atome/Title.vue'
    import {decodeCredential} from "vue3-google-login";

    export default {
        components:{
            Title,
        },
        data() {
            return {
                email: '',
                password: '',
            };
        },
        methods: {
            async handleLogin() {
                try {
                    await this.$store.dispatch('login', {
                        email: this.email,
                        password: this.password,
                    });

                    if(this.$store.getters['getUserConnected']){
                        this.$router.push({ name: 'home' });
                    } else {

                    }
                    
                } catch (error) {
                    alert(error);
                }
            },

            async authenticateByOAuth(response){
                try{
                    await this.$store.dispatch('loginByOAuth', {
                        token : response.credential
                    })

                } catch (error) {
                    alert(`Impossible vous connecter via OAuth : ${error.message}`);
                }
            }
        },
    };
    
</script>

<template>
    <Title name="Connexion"></Title>
    <form class="card secondaryColor" @submit.prevent="handleLogin">

        <input type="email" id="email" class="formField" v-model="email" placeholder="Adresse mail">

        <input type="password" id="password" class="formField" v-model="password" placeholder="Mot de passe">

        <button type="submit" class="button tertiaryColor">Se connecter</button>
    </form>

    <GoogleLogin :callback="authenticateByOAuth"/>

</template>

<style scoped>

form
{
    display: flex;
    flex-direction: column;
    justify-content:space-between;
    align-items: center;
    width: 20%;
    height: 50%;
    margin-bottom: 2%;
}

</style>