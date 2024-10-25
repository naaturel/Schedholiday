<script>
import MessageContent from "@/components/atome/chat/MessageContent.vue";
import MessageSender from "@/components/atome/chat/MessageSender.vue";
import MessageDate from "@/components/atome/chat/MessageDate.vue";

export default {
    name: "ChatItem",
    components: {MessageDate, MessageSender, MessageContent},
    props:{
        content:{
            type : String,
            required : true,
            default : "message_placeholder"
        },
        sender:{
            type : String,
            required : true,
            default : "sender_placeholder"
        },
        date:{
            type : String,
            required : true,
            default : "date_placeholder"
        }

    }
}
</script>

<template>

  <div id="item">
      <div id="msgInfos">
          <MessageSender id="sender" :name="this.sender"></MessageSender>
          <MessageDate id="date" :date="this.date"></MessageDate>
      </div>
      <MessageContent id="content" :content="this.content"></MessageContent>
  </div>

</template>

<style scoped>

div
{

}

#msgInfos
{
    display: flex;
    flex-direction: row;
}

#sender
{
    margin-right:2%;
}


#item
{
    width: 90%;
    margin-bottom: 4%;
}

</style>