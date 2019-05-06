<template>
  <div id="app">
    <Menu></Menu>
    <DevicesList></DevicesList>
  </div>
</template>

<script>
import Menu from './components/Menu.vue';
import DevicesList from './components/DevicesList.vue'


export default {
  name: 'app',
  components: {
    Menu,
    DevicesList
  }
}
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
