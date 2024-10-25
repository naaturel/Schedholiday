<script>
  export default{
    computed: {
      isLoggedIn() {
        return this.$store.getters['getUserConnected'];
      }
    }
  }
  
</script>

<template>
  <header class="primaryColor">
    <span> 
      <router-link :to="{name: 'home'}">SchedHoliday</router-link> 
    </span>
    <nav>
      <router-link v-if="isLoggedIn" :to="{name: 'createHoliday'}">Créer un voyage</router-link>
      <router-link :to="{name: 'contact'}">Contact</router-link>
      <router-link v-if="isLoggedIn" :to="{name: 'profile'}">Profile</router-link>
      <router-link v-if="!isLoggedIn" :to="{name: 'connexion'}">Connexion</router-link>
      <router-link v-if="!isLoggedIn" :to="{name: 'register'}">Inscription</router-link>
      <router-link v-if="isLoggedIn" :to="{name: 'deconnexion'}">Déconnexion</router-link>
    </nav>
  </header>
</template>

<style scoped>

header {
    display: flex;
    justify-content: space-between;
    align-items: center;
    width:100%;
    height: 15vh;
    padding: 0 20px;
}

header span{
    font-size: 2em;
    text-decoration: none;
}

span a{
    color: black;
}
</style>