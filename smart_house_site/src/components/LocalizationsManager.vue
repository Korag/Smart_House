<template>
<v-container v-show="this.$store.getters.getDisplayStatus.showLocalizationsManager">
    <v-layout column>
        <v-flex py-1 v-for ="localization in localizationList" :key="localization.Id" >
            <v-card flat class="blue white--text">
                <v-layout row wrap text-xs-center >
                    <v-flex lg4 sm12 xs12 px-4 >
                        <div class="black--text caption">Localization Name</div>
                        <div class="headline">{{localization.Name}}</div>
                    </v-flex>
                    <v-flex sm12 md12 lg2 offset-lg2  >
                        <v-btn large color="error" v-on:click="deleteLocalizationFromDB(localization)">Delete</v-btn>
                    </v-flex>
                </v-layout>
            </v-card>
        </v-flex>
              <v-btn large  bottom right fixed fab color="green" v-on:click="showAddDevice">
                <v-icon white>add</v-icon>
              </v-btn>
    </v-layout>
</v-container>
</template>

<script>
export default {
    data(){
        return{
        }
    },
    computed:{
        localizationList(){
            return this.$store.getters.getListOfLocalizations;
        }
    },
    methods:{
        showAddDevice(){
            Promise.all([this.$store.dispatch('getDevicesTypes'),this.$store.dispatch('getLocalizations')]).then(()=>{
                this.$store.commit('display',{to:'showAddDevice',from:'showDevicesManager'});
            })
        },
        deleteLocalizationFromDB(localization){
            this.$store.dispatch('deleteLocalizationFromDB',localization);
        },
        showEditDevice(device){
            Promise.all([this.$store.dispatch('getDevicesTypes'),this.$store.dispatch('getLocalizations')]).then(()=>{
                this.$store.commit('changeActualDevice',device);
                this.$store.commit('display',{to:'showEditDevice',from:'showDevicesManager'});
            })
        }
    }
}
</script>

