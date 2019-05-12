<template>
    <div class="topBar" v-on:click="goBack" >
        <img v-if="!this.$store.getters.getDisplayStatus.showMenu" class="arrow" :src="require('@/assets/arrow.svg')">
        Smart House</div>
</template>

<script>
export default {
    methods:{
        goBack: function(){
            this.$store.commit('goBack');
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
