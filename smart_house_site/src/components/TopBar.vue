<template>
    <div class="topBar" v-on:click="goBack" >
        <img v-if="!this.$store.getters.getDisplayStatusForMenu" class="arrow" :src="require('@/assets/arrow.svg')">
        Smart House</div>
</template>

<script>
export default {
    methods:{
        goBack: function(){
            this.$store.commit('displayListOfDevices');
            this.$store.commit('displayMenu');
        }
    }
}
</script>

<style scoped>
.topBar{
    background: #166fff;
    height: 5vh;
    text-align: center;
    color: white;
    font-size: 30px;
}
.arrow{
    float: left;
}
</style>
