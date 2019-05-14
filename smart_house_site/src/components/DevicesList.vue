<template>
    <div v-show="this.$store.getters.getDisplayStatus.showDevicesList">
        <div class="menuItem" v-for="device in devices" v-bind:key="device.id" v-on:click="DisplayActions(device.Type,device.Id)">
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
        DisplayActions(deviceType,deviceId){
            this.$store.commit('changeActualDevice',{deviceType: deviceType,deviceId: deviceId});
            this.$store.dispatch('getActions');
            this.$store.dispatch('getActualDeviceState');
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
    font-size: 20px;
    text-align: center;
    color: white;
}
</style>
