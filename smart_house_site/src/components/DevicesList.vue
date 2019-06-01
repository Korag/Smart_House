<template>
<v-container v-show="this.$store.getters.getDisplayStatus.showDevicesList">
    <v-layout column>
        <v-flex py-2 v-for ="(value,name) in groups" :key="name" >
            <v-card flat color="grey lighten-3" style="border-left: 4px solid grey" class="text-xs-center">
                <v-chip label text-color='white' color="grey" class="headline" >
                <v-avatar>
                    <v-icon right>{{value.Icon}}</v-icon>
                </v-avatar>
                {{name}}
                </v-chip>
                <v-layout row wrap >
                    <v-flex px-3 py-2 xs12 sm6 lg4 v-for ="device in value.List" :key="device.id">
                        <v-card class="text-xs-center white--text headline" color="blue" >
                            <v-card-text>
                                <p class="display-1">
                                {{device.Type}}
                                </p>
                                <p class="subheading">
                                {{device.Name}}
                                </p>
                                <v-chip class="hidden-md-and-down white--text text-xs-center headline" :class="StatusColor(device)">
                                    Status: {{device.State}}
                                </v-chip>
                            </v-card-text>
                            <v-card-actions class="hidden-lg-and-up">
                              <v-btn v-if="device.State == 'Enabled'"  fab color="success" class="caption">ON</v-btn>
                              <v-btn v-if="device.State == 'Disabled'"  fab color="error" class="caption">OFF</v-btn>
                              <v-btn v-if="device.State != 'Disabled' && device.State != 'Enabled'"  fab color="warning" class="caption">Working</v-btn>
                              <v-spacer></v-spacer>
                              <v-btn fab v-on:click="DisplayActions(device.Type,device.Id)">
                                  <v-icon color="Grey">notes</v-icon>
                              </v-btn>
                            </v-card-actions>
                            <v-card-actions class="hidden-md-and-down">
                                <v-flex v-for="action in GetListOfActions(device)" :key="action" >
                                    <v-btn>{{action}}</v-btn>
                                </v-flex>
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
        },
        StatusColor(device){
            return{
                'success' : device.State == 'Enabled',
                'error' : device.State == 'Disabled',
                'warning' : device.State != 'Disabled' && device.State != 'Enabled'
            }
        },
        GetListOfActions(device){
            this.$store.getters.getListOfActionForDevice(device);
        }
    }
}
</script>

<style>



</style>



