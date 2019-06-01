<template>
<v-container v-show="this.$store.getters.getDisplayStatus.showDevicesList">
    <v-layout column>
        <v-flex py-2 v-for ="(value,name) in groups" :key="name" >
            <v-card flat color="grey lighten-3" style="border-left: 4px solid grey" class="text-xs-center">
                <v-chip label text-color='white' color="grey" class="headline" >
                <v-avatar>
                    <v-icon>{{value.Icon}}</v-icon>
                </v-avatar>
                {{name}}
                </v-chip>
                <v-layout row wrap >
                    <v-flex px-3 py-2 xs12 sm6 lg4 v-for ="device in value.List" :key="device.id">
                        <v-card class="text-xs-center white--text headline" color="blue" v-on:click="DisplayActions(device.Type,device.Id)">
                            <v-card-text>
                            {{device.Type}}
                            {{device.Name}}
                            </v-card-text>
                            <v-card-actions>
                              <v-btn small fab color="success">ON</v-btn>
                              <v-btn small fab color="error">OFF</v-btn>
                              <v-btn small fab color="warning">Working</v-btn>
                              <v-spacer></v-spacer>
                              <v-btn small fab>
                                  <v-icon color="Grey">notes</v-icon>
                              </v-btn>
                            </v-card-actions>
                        </v-card>
                    </v-flex>
                </v-layout>
            </v-card>
        </v-flex>
    </v-layout>
</v-container>

</template>

<script>
export default {
    data:function(){
        return {
            list: {}
        }
    },
    computed:{
        groups(){
            return this.$store.getters.getGroups;
        }
    },
    methods:{
        DisplayActions(deviceType,deviceId){
            this.$store.commit('changeActualDevice',{deviceType: deviceType,deviceId: deviceId});
            this.$store.dispatch('getActions');
            this.$store.dispatch('getActualDeviceState');
        }
    }
}
</script>

<style>



</style>



