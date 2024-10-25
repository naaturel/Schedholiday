<script>
  import Header from './components/layout/Header.vue'
  import Footer from './components/layout/Footer.vue'
  export default{
    components:{
      Header,
      Footer
    },  
    created() {
      const user = this.$store.getters['getUserConnected']
      if(user === null){
        this.$store.dispatch('setUser', JSON.parse(localStorage.getItem('userConnected')))
      }
    }
  }
</script>

<template>
  <Header></Header>
  <main>
    <router-view></router-view>
  </main>
  <Footer></Footer>
</template>

<style>

*{
    font-family: Arial,serif;
}

</style>
