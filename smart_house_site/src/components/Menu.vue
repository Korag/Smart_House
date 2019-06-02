<template>
<v-container v-show="this.$store.getters.getDisplayStatus.showMenu">
    <v-layout row wrap >
        <v-flex px-3 py-2 xs12 sm6 lg4 v-for ="option in menu" :key="option.id" >
            <v-card class="text-xs-center white--text headline" color="blue" v-on:click="useFunction(option.action)">
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
        useFunction(name){
            if(name == 'showMyHouse'){
                this.showMyHouse();
            }
            else if(name == 'showDevicesManager'){
                this.showDeviceManager();
            }
            else if(name == 'showLocalizationsManager'){
                this.showLocalizationsManager();
            }
        },
        showMyHouse: function(){
            Promise.all([this.$store.dispatch('getDevices'),this.$store.dispatch('getLocalizations'),this.$store.dispatch('getActions')]).then(()=>{
                this.$store.commit('createGroups');
                 this.$store.commit('display',{to:'showMyHouse',from:'showMenu'});
            })
        },
        showDeviceManager: function(){
            this.$store.dispatch('getDevices')
            this.$store.commit('display',{to:'showDevicesManager',from:'showMenu'});
        },
        showLocalizationsManager: function(){
            this.$store.dispatch('getLocalizations');
            this.$store.commit('display',{to:"showLocalizationsManager",from:'showMenu'})
        }
    }
}
</script>

