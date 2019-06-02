<template>
<v-container v-show="this.$store.getters.getDisplayStatus.showAddDevice">
    <v-layout>
        <v-flex>
            <v-form ref="addDeviceForm" v-model="valid" lazy-validation >
                <v-text-field
                v-model="deviceName"
                label="Device Name"
                required
                ></v-text-field>

                <v-select
                v-model="deviceType"
                :items="this.$store.getters.getListOfDevicesTypes"
                label="Device Type"
                required
                ></v-select>

                <v-select
                v-model="deviceLocalizatin"
                :items="this.$store.getters.getListOfLocalizations"
                label="Device Localization"
                required
                ></v-select>
                <v-btn
                :disabled="!valid"
                color="success">
                Add
                </v-btn>
            </v-form>
        </v-flex>
    </v-layout>
</v-container>
</template>

<script>
export default {
    data: () =>({
        valid: true,
        deviceName: '',
        deviceType: '',
        deviceLocalizatin: '',
        deviceState: 'Disabled',
    }),
    computed:{
        listOfLocalizations(){
            return this.$store.getters.getListOfLocalizations.filter((ele)=>{
                
            });
        },
    },
    methods:{
        showDevicesList: function(){
            Promise.all([this.$store.dispatch('getDevices'),this.$store.dispatch('getLocalizations'),this.$store.dispatch('getActions')]).then(()=>{
                this.$store.commit('createGroups');
                 this.$store.commit('display',{to:'showDevicesList',from:'showMenu'});
            })
        }
    }
}
</script>
