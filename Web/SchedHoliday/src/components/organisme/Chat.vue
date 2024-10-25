

<script>

import ChatItem from "@/components/molecule/ChatItem.vue";
import HolidayItem from "@/components/molecule/HolidayItem.vue";
import Pusher from "pusher-js";
import Input from "@/components/atome/Input.vue";
import {convertEpochToDate} from "@/components/icons/date";
import {da} from "date-fns/locale";

const KEY = "0794d85e3c42a590d8bc"
const CLUSTER = "eu"
let pusher = null

export default {

    name: "Chat",
    components: {Input, ChatItem},
    data() {
        return {
            messages: [],
            toSend: "",
        };
    },
    async created(){
        await this.fetchData()
        await this.connectToPusher()
        await this.subscribeToChannel()
    },

    unmounted() {
        this.disconnectFromPusher()
    },

    destroyed() {
        this.disconnectFromPusher()
    },

    methods:{
        convertEpochToDate,
        async fetchData() {
            await this.$store.dispatch('fetchMessages', {holidayId : this.$route.params.id});
            this.messages = this.$store.getters['getMessages']
        },

        async connectToPusher(){
            try{
                if(pusher === null
                    || pusher.connection.state !== "connected"
                    || pusher.connection.state !== "connecting"){
                    pusher = new Pusher(KEY, {cluster: CLUSTER});
                    await pusher.connect()
                }
            } catch (error){
                console.log("Unable to connect to chat.")
            }
        },

        async disconnectFromPusher(){
            pusher.disconnect()
            console.log(pusher.connection.state)
        },

        async subscribeToChannel(){

            let channelName = `${this.$route.params.id}-channel`
            let eventName = `${this.$route.params.id}-event`


            let channel = pusher.channel(channelName)

            if(channel === null || channel === undefined) {
                channel = pusher.subscribe(channelName);
            }

            channel.bind(eventName, (data) => {this.onNewMessage(data)})

            console.log(channel)
        },

        async onNewMessage(data){
            console.log(data)
            this.$store.dispatch('addMessage', data)
        },

        async sendMessage(){
            const user = this.$store.getters['getUserConnected']
            if(user == null) return

            let time = Math.floor(new Date().getTime() / 1000)

            await fetch(`https://porthos-intra.cg.helmo.be/Q210044/api/Chat/`, {
                method : 'POST',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${user.Token}`
                },
                body: JSON.stringify({content: this.toSend, epoch:time, sender:user.Id, holidayId:this.$route.params.id
                })})
                .catch(error => {
                    console.error('Erreur lors de la récupération des messages. Cause :', error);
                });
        },
    }
}
</script>

<template>
    <div id="chat" class="card secondaryColor">
        <div id="messagesBox">
            <ChatItem v-for="msg in this.messages" :content="msg.Content" :sender="msg.Sender" :date="convertEpochToDate(msg.Epoch)"></ChatItem>
        </div>

        <div id="sendingBox">
            <form @submit.prevent="sendMessage">
                <input class="formField" v-model="toSend">
                <button class="button" type="submit">Envoyer</button>
            </form>
        </div>

    </div>

</template>

<style scoped>

#chat
{
    height: 450px;
    width: 100%;
}

#messagesBox
{
    display: flex;
    flex-direction: column;
    border-bottom: solid black 1px;
    overflow: auto;
}

#messagesBox, #sendingBox
{
    width: 100%;
}

#sendingBox
{
    height: 25%;
}

form
{
    display: flex;
    flex-direction: row;
    margin-top: 2%;
}

.formField
{
    width: 70%;
}

.button
{
    width: 20%;
    height: inherit;
    margin-left: 1%;
}

#chat:hover
{
    cursor: pointer;
}

#chat
{
    margin-bottom: 5%;
}

</style>