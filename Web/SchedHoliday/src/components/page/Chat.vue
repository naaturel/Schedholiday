<template>

    <Title name="Chat"></Title>

    <ul>
        <li v-for="message in messages">
            {{message}}
        </li>
    </ul>


    <form>
        <input placeholder="Tapez un message..."/>
        <button><i class="fa fa-paper-plane"></i></button>
    </form>

</template>


<script>
import Title from "@/components/atome/Title.vue";
import Message from "@/components/atome/chat/MessageContent.vue";

export default {
    name: "Chat",
    components: {Message, Title},
    data() {
        return {
            messages: ["Test 1", "Test 2"]
        }
    },
    methods:{
        connect(){
            /*// Enable pusher logging - don't include this in production
            Pusher.logToConsole = true;
            let pusher = new Pusher('5e77f1f417a1d7ef35aa', {
                cluster: 'eu'
            });

            var channel = pusher.subscribe('my-channel');
            channel.bind('my-event', function(data) {
                app.messages.push(JSON.stringify(data));
            });

            // Vue application
            const app = new Vue({
            el: '#app',
            data: {
            messages: [],
            }});*/
        }
    }
}
</script>


<style scoped>


ul{
    display: flex;
    flex-direction: column;
    justify-content: start;
    list-style-type: none;
    width: 50%;
    height: 50%;
    margin-bottom: 5%;
}

li{

    display: flex;
    align-items: center;
    justify-content: center;

    font-size: 0.95em;

    background: #eeeeee;
    border-radius: 25px 25px 25px 5px;
    box-shadow: rgba(0, 0, 0, 0.25) 0 3px 3px;
    margin-bottom: 5%;

    min-width: 75px;
    max-width: 95%;
    width: fit-content;

    height: fit-content;

    word-wrap: break-word;

    padding: 3%;
}

</style>