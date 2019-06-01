<template>
<v-container v-show="this.$store.getters.getDisplayStatus.showMenu">
    <v-layout row wrap v-show="this.$store.getters.getDisplayStatus.showMenu">
        <v-flex px-3 py-2 xs12 sm6 lg4 v-for ="option in menu" :key="option.id" v-on:click="showDevicesList">
            <v-card class="text-xs-center white--text headline" color="blue">
                <v-icon size="100px" color="white">{{option.icon}}</v-icon>
                <v-card-text>
                {{option.name}}
                </v-card-text>
            </v-card>
        </v-flex>
    </v-layout>
</v-container>
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
            Promise.all([this.$store.dispatch('getDevices'),this.$store.dispatch('getLocalizations')]).then(()=>{
                this.$store.commit('createGroups');
                 this.$store.commit('display',{to:'showDevicesList',from:'showMenu'});
            })
        }
    }
}
</script>

