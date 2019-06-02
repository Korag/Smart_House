<template>
    <v-container v-if="this.$store.getters.getDisplayStatus.showActionsList">
        <v-layout>
            <v-flex>
                <v-card flat color="blue" class="text-xs-center white--text">
                    <p class="headline">Type: {{actualDevice.Type}}</p>
                    <p class="headline">Localization: {{actualDevice.Localization}}</p>
                    <p class="headline">Name: {{actualDevice.Name}}</p>
                    <v-chip disabled class="white--text text-xs-center headline" :class="StatusColor(actualDevice)">
                        Aktualny stan: {{actualDevice.State}}
                    </v-chip>
                <v-card-actions>
                    <v-layout row wrap>
                        <v-flex v-for="action in listOfActions(actualDevice)" :key="action" justify-space-between py-1 grow>
                            <v-btn large v-on:click="ChangeState(actualDevice,action)">{{action}}</v-btn>
                        </v-flex>
                    </v-layout>
                </v-card-actions>
                </v-card>
            </v-flex>
        </v-layout>
    </v-container>
</template>

<script>
export default {
    computed:{
        actualDevice(){
            return this.$store.getters.getActualDevice;
        }
    },
    methods:{
        ChangeState(device,newState){
            this.$store.dispatch('changeDeviceState',{device,newState});
        },
        listOfActions(actualDevice){
            return this.$store.getters.getListOfActionForDevice(actualDevice).filter((ele)=>{
                return ele != actualDevice.State;
            });
        },
        StatusColor(actualDevice){
            return{
                'success' : actualDevice.State == 'Enabled',
                'error' : actualDevice.State == 'Disabled',
                'warning' : actualDevice.State != 'Disabled' && actualDevice.State != 'Enabled'
            }
        },
    }
}
</script>
