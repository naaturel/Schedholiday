<script>
export default {
    name: "DeleteHoliday",
    props : {
        id : {
            type: Number,
            required: true
        }
    },
    methods:{
        async delete(){
            await fetch("https://porthos-intra.cg.helmo.be/Q210044/swagger/index.html/api/Holiday", {
                method : "DELETE",
                headers : {
                    //TODO complete this method
                }
            })
        }
    }
}
</script>

<template>
  <button class="button">Supprimer</button>
</template>

<style scoped>

</style>