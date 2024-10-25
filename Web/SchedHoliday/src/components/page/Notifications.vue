<script>

import NotificationItem from "@/components/organisme/NotificationItem.vue";

export default {
    components:{
        NotificationItem
    },

    created() {
        this.loadInvites()
    },

    methods:{

        async loadInvites(){

        }
    }


}

</script>

<template>

    <NotificationItem ></NotificationItem>

</template>

<style scoped>

</style>