<template>
    <div id="menu">
        <div class="menu" v-for="device in devices" v-bind:key="device.id">
            <div>{{device.Localization}}</div>
            <div>{{device.Name}}</div>
            <div>{{device.State}}</div>
            <div>{{device.Type}}</div>
        </div>
    </div>
</template>

<script>
export default {
    computed:{
        devices(){
            return this.$store.getters.getListOfDevices;
        }
    },
    methods:{
    }
}
</script>

<style scoped>
.menu {
    border: 2px solid blue;
    border-radius: 5px;
    height: 45vh;
    width: 45vw;
    float: left;
    margin: 1vh 1vh;
    position: relative;
}
.menuText{
    position: absolute;
    bottom: 10vh;
    right: 15vw;
    
}
</style>
