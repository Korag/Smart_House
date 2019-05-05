<template>
    <div id="menu">
        <div class="menu" v-for="option in menu" v-bind:key="option.id">
            <img :src=option.image>
            <div class="menuText">{{option.name}}</div>
        </div>
    </div>
</template>

<script>
export default {
    computed:{
        menu(){
            return this.$store.getters.menuOptions;
        }
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
