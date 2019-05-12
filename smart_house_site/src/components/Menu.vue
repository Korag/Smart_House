<template>
    <div v-show="this.$store.getters.getDisplayStatusForMenu">
        <div v-on:click="test" class="menuItem" v-for="option in menu" v-bind:key="option.id">
            <img :src=option.image>
            <div>{{option.name}}</div>
        </div>
    </div>
</template>

<script>
export default {
    computed:{
        menu(){
            return this.$store.getters.menuOptions;
        }
    },
    methods:{
        test: function(){
            this.$store.commit('displayMenu');
            this.$store.commit('displayListOfDevices');
            this.$store.dispatch('getDevices');
        }
    }
}
</script>

<style scoped>
.menuItem {
    height: 20vh;
    width: 46vw;
    border-style: solid;
    border-color: white;
    border-width: 2vw;
    float: left;
    position: relative;
    background: #166fff;
    font-size: 30px;
    text-align: center;
    color: white;
}
.menuText{
    position: absolute;
    bottom: 10vh;
    right: 15vw;
}
.topBar{
    background: #166fff;
    height: 5vh;
    text-align: center;
    color: white;
    font-size: 30px;
}

</style>
