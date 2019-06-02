<template>
<v-container v-show="this.$store.getters.getDisplayStatus.showDevicesManager">
    <v-layout column>
        <v-flex py-1 v-for ="device in devicesList" :key="device.Id" >
            <v-card flat class="blue white--text">
                <v-layout row wrap text-xs-center >
                    <v-flex lg4 sm12 xs12 px-4 >
                        <div class="black--text caption">Device Name</div>
                        <div class="headline">{{device.Name}}</div>
                    </v-flex>
                    <v-flex xs6 sm6 lg2 >
                        <div class="black--text caption">Device Type</div>
                        <div class="title">{{device.Type}}</div>
                    </v-flex>
                    <v-flex xs6 sm6 lg2>
                        <div class="black--text caption">Device Localization</div>
                        <div class="title">{{device.Localization}}</div>
                    </v-flex>
                    <v-flex sm12 md12 lg2 offset-lg2  >
                        <v-btn large color="warning">Edit</v-btn>
                        <v-btn large color="error" v-on:click="deleteDeviceFromDB(device)">Delete</v-btn>
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
        devicesList(){
            return this.$store.getters.getListOfDevices;
        }
    },
    methods:{
        showAddDevice(){
            Promise.all([this.$store.dispatch('getDevicesTypes'),this.$store.dispatch('getLocalizations')]).then(()=>{
                this.$store.commit('display',{to:'showAddDevice',from:'showDevicesManager'});
            })
        },
        deleteDeviceFromDB(device){
            this.$store.dispatch('deleteDeviceFromDB',device);
        }
    }
}
</script>

