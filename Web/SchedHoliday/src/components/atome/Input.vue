<script>
    export default{
        name: "Input",
        props:{
            typeInput:{
                type: String,
                required: true,
                default: "text"
            },
            id:{
                type: String,
                required: true,
                default: "id"
            }
        }
    }
</script>

<template>
    <input :type=this.typeInput :id=this.id>
</template>

<style scoped>
    
</style>