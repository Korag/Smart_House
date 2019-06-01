<template>
    <v-container v-if="this.$store.getters.getDisplayStatus.showActionsList">
        <v-layout>
            <v-flex>
                <v-card flat color="blue" class="text-xs-center">
                    <v-chip class="white--text text-xs-center headline" :class="StatusColor(actualDevice)">
                        Aktualny stan: {{actualDevice.State}}
                    </v-chip>
                <v-card-actions>
                    <v-layout>
                        <v-flex v-for="action in listOfActions(actualDevice)" :key="action">
                            <v-btn v-on:click="ChangeState(actualDevice,action)">{{action}}</v-btn>
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
            });;
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
