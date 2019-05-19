<template>
    <div v-show="this.$store.getters.getDisplayStatus.showMenu">
        <div v-on:click="showDevicesList" class="menuItem" v-for="option in menu" v-bind:key="option.id">
            <img :src=option.image>
            <div>{{option.name}}</div>
        </div>
    </div>
</template>

<script>
export default {
    computed:{
        menu(){
            return this.$store.getters.getMenuOptions;
        }
    },
    methods:{
        showDevicesList: function(){
            this.$store.dispatch('getDevices');
            this.$store.commit('display',{to:'showDevicesList',from:'showMenu'});
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

</style>
