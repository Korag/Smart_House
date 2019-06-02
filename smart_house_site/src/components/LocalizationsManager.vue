<template>
<v-container v-show="this.$store.getters.getDisplayStatus.showLocalizationsManager">
    <v-layout column>
        <v-flex py-1 v-for ="localization in localizationList" :key="localization.Id" >
            <v-card flat class="blue white--text">
                <v-layout row wrap text-xs-center >
                    <v-flex xs12 sm12 md1 lg1 xl1>
                        <v-icon size="60px" color="white" left>{{localization.Icon}}</v-icon>
                    </v-flex>
                    <v-flex  xs12 sm12 md3 lg3 xl1 offset-lg3 offset-xl4>
                        <div class="black--text caption">Localization Name</div>
                        <div class="headline">{{localization.Name}}</div>
                    </v-flex>
                    <v-flex sm12 md1 lg1 xl1 offset-lg3 offset-md6 offset-xl5>
                        <v-btn large color="error" v-on:click="deleteLocalizationFromDB(localization)">Delete</v-btn>
                    </v-flex>
                </v-layout>
            </v-card>
        </v-flex>
              <v-btn large  bottom right fixed fab color="green" v-on:click="showAddLocalization">
                <v-icon color="white">add</v-icon>
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
        deleteLocalizationFromDB(localization){
            this.$store.dispatch('deleteLocalizationFromDB',localization);
        },
        showAddLocalization(device){
                this.$store.commit('display',{to:'showAddLocalization',from:'showLocalizationsManager'});
        }
    }
}
</script>

