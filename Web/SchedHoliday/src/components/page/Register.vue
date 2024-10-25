<script>
    import Title from '../atome/Title.vue' 
    export default{
        name:"Register",
        components : {
            Title
        },
        data() {
            return {
                lastName:'',
                firstName:'',
                email: '',
                password: '',
                confirm:''
            };
        },
        methods: {
            checkInput(){
                if(this.lastName === "" || this.firstName === "" || this.email === "" || this.password === "" || this.confirm === ""){
                    return "veuillez remplir tous les champs"
                }else if(this.password !== this.confirm){
                    return "les mots de passe ne sont pas les mêmes"
                }
                return "";
            },
            async register() {
                try {
                    const message = this.checkInput()
                    if(message !== ""){
                        alert(message)
                    }else{
                        const response = await fetch('https://porthos-intra.cg.helmo.be/Q210044/api/User', {
                            method: 'POST',
                            headers: {
                            'Content-Type': 'application/json',
                            },
                            body: JSON.stringify({ firstName: this.firstName, lastName : this.lastName, email : this.email, password : this.password }),
                        });

                        if(response.ok){
                            await this.$store.dispatch('login', {
                                email: this.email,
                                password: this.password,
                            })
                            this.$router.push({ name: 'home' });
                        }else{
                            alert(`une erreur est survenu pendant l'inscription`)
                        }
                    }
                
                } catch (error) {
                    console.error('Erreur de connexion:', error.message);
                }
            },

            async registerOAuth(response){
                try{
                    await this.$store.dispatch('loginByOAuth', {
                        token : response.credential
                    })

                } catch (error) {
                    console.error('Unable to authenticate using OAuth. Cause :', error.message);
                }
            }

        },
    }
    
</script>

<template>
    <Title name="Inscription"></Title>
    <form class="card secondaryColor" @submit.prevent="register">
        <input class="formField" type="text" id="lastName" v-model="lastName" placeholder="Nom">

        <input class="formField" type="text" id="firstName" v-model="firstName" placeholder="Prenom">

        <input class="formField" type="email" id="email" v-model="email" placeholder="Mail">

        <input class="formField" type="password" id="password" v-model="password" placeholder="Mot de passe">

        <input class="formField" type="password" id="confirm" v-model="confirm" placeholder="Confirmer le mot de passe">

        <button class="button tertiaryColor" type="submit">s'inscrire</button>
    </form>

    <GoogleLogin :callback="registerOAuth"/>

</template>

<style scoped>

form
{
    margin-bottom: 2%;
}

</style>