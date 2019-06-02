
<template>
<v-container v-show="this.$store.getters.getDisplayStatus.showDevicesList">
    <v-layout column>
        <v-flex py-2 v-for ="(value,name) in groups" :key="name" >
            <v-card flat color="grey lighten-3" class="text-xs-center">
                <v-chip label text-color='white' color="grey" class="headline" >
                <v-avatar>
                    <v-icon right>{{value.Icon}}</v-icon>
                </v-avatar>
                {{name}}
                </v-chip>
                <v-layout row wrap >
                    <v-flex px-3 py-2 xs12 sm6 lg4 v-for ="device in value.List" :key="device.id">
                        <v-card class="text-xs-center white--text headline" color="blue" >
                            <v-card-text class="text-xs-center">
                                <p class="display-1">
                                {{device.Type}}
                                </p>
                                <p class="subheading">
                                {{device.Name}}
                                </p>
                                <v-chip disabled class="hidden-md-and-down white--text text-xs-center headline" :class="StatusColor(device)">
                                    Status: {{device.State}}
                                </v-chip>
                            </v-card-text>
                            <v-card-actions class="hidden-lg-and-up">
                              <v-chip disabled v-if="device.State == 'Enabled'"  color="success" class="white--text headline">ON</v-chip>
                              <v-chip disabled v-if="device.State == 'Disabled'"   color="error" class="white--text headline">OFF</v-chip>
                              <v-chip disabled v-if="device.State != 'Disabled' && device.State != 'Enabled'"  color="warning" class="white--text headline">Working</v-chip>
                              <v-spacer></v-spacer>
                              <v-btn fab v-on:click="DisplayActions(device)">
                                  <v-icon color="Grey">notes</v-icon>
                              </v-btn>
                            </v-card-actions>
                            <v-card-actions class="hidden-md-and-down">
                                <v-layout row wrap justify-space-between>
                                    <v-flex py-1 v-for="action in GetListOfActions(device)" 
                                    :key="action"> 
                                        <v-btn large v-on:click="ChangeState(device,action)">{{action}}</v-btn>
                                    </v-flex>
                                </v-layout>
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
        DisplayActions(device){
            this.$store.dispatch('getActualDeviceState',device).then(()=>{
                this.$store.commit('changeActualDevice',device);
                this.$store.commit('display',{to:'showActionsList',from:'showDevicesList'});
            });
        },
        StatusColor(device){
            return{
                'success' : device.State == 'Enabled',
                'error' : device.State == 'Disabled',
                'warning' : device.State != 'Disabled' && device.State != 'Enabled'
            }
        },
        GetListOfActions(device){
            return this.$store.getters.getListOfActionForDevice(device).filter((ele)=>{
                return ele != device.State;
            });
        },
        ChangeState(device,newState){
            this.$store.dispatch('changeDeviceState',{device,newState});
        }
    }
}
</script>

<style>



</style>



