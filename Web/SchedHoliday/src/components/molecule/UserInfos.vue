<template>

  <ul id="userInfosList">
      <li class="card secondaryColor"><Field descriptor="UID" v-model:value="this.user.Id" ></Field></li>
      <li class="card secondaryColor"><Field descriptor="Prénom" v-model:value="this.user.FirstName" ></Field></li>
      <li class="card secondaryColor"><Field descriptor="Nom" v-model:value="this.user.LastName" ></Field></li>
      <li class="card secondaryColor"><Field descriptor="Mail" v-model:value="this.user.Email" ></Field></li>
  </ul>

</template>

<script>
import Field from "@/components/atome/Field.vue";
export default {
    name: "UserInfos",
    components: {Field},
    props:{
        user:{
            type: Object,
            required : true
        }
    },
}
</script>

<style scoped>

ul{
    min-width: 65%;
    list-style-type: none;
    padding: 0;
}

li{
    margin-bottom: 2%;
    padding: 1%;
}

.card
{
    width: 100%;
    flex-direction: row;
    justify-content: space-between;
}

</style>