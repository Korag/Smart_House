<template>
    <v-container v-if="this.$store.getters.getDisplayStatus.showActionsList">
        <v-layout>
            <v-flex>
                <v-card flat color="grey lighten-3" class="text-xs-center">
                    <div>Aktualny stan: {{actualDevice.State}}</div>
                <v-card-actions>
                    <v-layout>
                        <v-flex v-for="action in listOfActions(actualDevice)" :key="action">
                            <v-btn>{{action}}</v-btn>
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
        changeState(newState){
            this.$store.dispatch('changeDeviceState',newState);
        },
        listOfActions(actualDevice){
            return this.$store.getters.getListOfActionForDevice(actualDevice).filter((ele)=>{
                return ele != actualDevice.State;
            });;
        }
    }
}
</script>
