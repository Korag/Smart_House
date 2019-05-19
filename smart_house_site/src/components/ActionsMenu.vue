<template>
    <div v-if="this.$store.getters.getDisplayStatus.showActionsList">
        <div class="actualState">Aktualny stan: {{actualState}}</div>
        <div class="menuItem" v-for="action in actions
            .filter((e)=>{
            return e !=actualState})"
            v-bind:key="action"
            v-on:click='changeState(action)'>
            <div>{{action}}</div>
        </div>
    </div>
</template>

<script>
export default {
    computed:{
        actions(){
            return this.$store.getters.getActionsForDevice;
        },
        actualState(){
            return this.$store.getters.getActualDeviceState;
        }
    },
    methods:{
        changeState(newState){
            this.$store.dispatch('changeDeviceState',newState);
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
.actualState{
    height: 20vh;
    width: 96vw;
    background: #166fff;
    border-style: solid;
    border-color: white;
    border-width: 2vw;
    font-size: 40px;
    text-align: center;
    color: white;
}
</style>
