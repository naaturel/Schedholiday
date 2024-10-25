<script>
    import Label from '../atome/Label.vue' 
    export default{
        name:"FormContact",
        components : {
            Label
        },
        created(){
            if(this.$store.getters['isConnected']){
                this.emailUser=this.$store.getters['getUserConnected'].Email
            }
        },
        data() {
            return {
                emailUser: "",
                topic : "",
                message : "",
                formText :{
                    emailText: "email",
                    topicText: "sujet",
                    messageText: "message"
                }
            };
        },
        methods:{
            async sendEmail() {
                if(this.emailUser === "" || this.topic === "" || this.message === ""){
                    alert("veuillez remplir tous les champs")
                }else{
                    try {
                        await fetch('https://porthos-intra.cg.helmo.be/Q210044/api/Mail', {
                            method: 'POST',
                            headers: {
                                'Content-Type': 'application/json'
                            },
                            body: JSON.stringify({ email: this.emailUser, topic: this.topic, message: this.message}),
                        })
                        .then(response =>{
                            if(response.ok){
                                alert(`mail envoyé`)
                                this.$router.push({ name: 'home' })
                            }else{
                                alert(`une erreur est survenu pendant l'envoi du mail`)
                            }
                        })
                    } catch (error) {
                        console.error(`Erreur lors de la récupération de l'envoi du mail :`, error)
                    }
                }
            }
        }
    }
</script>

<template>
    <form class="card secondaryColor" @submit.prevent="sendEmail">
        <input class="formField" type="text" :id="this.formText.emailText" v-model="this.emailUser" placeholder="Email">

        <input class="formField" type="text" :id="this.formText.topicText" v-model="this.topic" placeholder="Sujet">

        <textarea :id="this.formText.messageText" class="textareaContact formField"
                  rows="10" cols="33" v-model="this.message" placeholder="Décrivez votre problème"></textarea>

        <button class="button" type="submit">envoyer</button>
    </form>
</template>

<style scoped>


.textareaContact
{
    max-width: 100%;
    margin-bottom: 2%;
}

</style>