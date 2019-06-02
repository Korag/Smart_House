<template>
  <v-app>
    <TopBar></TopBar>
    <v-content class="grey lighten-5">
      <Menu></Menu>
      <MyHouse></MyHouse>
      <ActionsMenu></ActionsMenu>
      <DevicesManager></DevicesManager>
      <AddDevice></AddDevice>
      <EditDevice></EditDevice>
      <LocalizationManager></LocalizationManager>
      <AddLocalization></AddLocalization>
    </v-content>
  </v-app>
</template>

<script>
import Menu from './components/Menu.vue';
import MyHouse from './components/MyHouse.vue';
import TopBar from './components/TopBar.vue';
import ActionsMenu from './components/ActionsMenu.vue';
import AddDevice from './components/AddDevice.vue';
import DevicesManager from './components/DevicesManager.vue';
import EditDevice from './components/EditDevice.vue';
import LocalizationManager from "./components/LocalizationsManager.vue"
import AddLocalization from "./components/AddLocalization.vue"

export default {
  name: 'app',
  components: {
    Menu,
    MyHouse,
    TopBar,
    ActionsMenu,
    AddDevice,
    DevicesManager,
    EditDevice,
    LocalizationManager,
    AddLocalization
  },
  data () {
    return {
      //
    }
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
