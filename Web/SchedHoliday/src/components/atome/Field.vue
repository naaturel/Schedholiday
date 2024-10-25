<template>

    <div>
        <div class="descriptor"> {{descriptor}} </div>
        <div class="value"> {{value}} </div>
    </div>


</template>

<script>

export default {
    name: "Field",
    props:{
        descriptor:{
            type: String,
            required: true,
            default: "field_descriptor_placeholder"
        },
        value:{
            type: String,
            required: true,
            default: "field_value_placeholder"
        },
    }
}
</script>

<style scoped>

div{
    display: flex;
    justify-content: space-evenly;
    font-size: 1.15em;
}

</style>