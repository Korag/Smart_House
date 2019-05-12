<template>
    <div v-show="this.$store.getters.getDisplayStatusForDevicesList">
        <div class="menuItem" v-for="device in devices" v-bind:key="device.id">
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
