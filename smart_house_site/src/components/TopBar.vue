<template>
  <v-toolbar class="blue darken-1">
    <v-btn flat color="black" fab right v-on:click="goBack" v-if="!this.$store.getters.getDisplayStatus.showMenu" class="btn-back">
        <v-icon large>arrow_back</v-icon>
    </v-btn>
    <v-spacer></v-spacer>
    <v-toolbar-title class="white--text display-2 text-uppercase site-title">
        <span class="font-weight-light font-italic">Smart</span> House
    </v-toolbar-title>
    <v-spacer></v-spacer>
  </v-toolbar>
</template>

<script>
export default {
    methods:{
        goBack: function(){
            this.$store.commit('goBack');
        }
    }
}
</script>

