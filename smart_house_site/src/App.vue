<template>
  <div id="app">
    <TopBar></TopBar>
    <Menu></Menu>
    <DevicesList></DevicesList>
    <ActionsMenu></ActionsMenu>
  </div>
</template>

<script>
import Menu from './components/Menu.vue';
import DevicesList from './components/DevicesList.vue';
import TopBar from './components/TopBar.vue';
import ActionsMenu from './components/ActionsMenu.vue';


export default {
  name: 'app',
  components: {
    Menu,
    DevicesList,
    TopBar,
    ActionsMenu
  }
}
</script>

<style>

html, body {
  height: 100%;
  margin: 0;
  padding: 0;
}

#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  height: 100%;
  width: 100%;
}
</style>
