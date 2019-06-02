<template>
<v-container v-show="this.$store.getters.getDisplayStatus.showAddDevice">
    <v-layout>
        <v-flex>
            <v-form ref="addDeviceForm" v-model="valid" lazy-validation >
                <v-text-field
                v-model="deviceName"
                :rules="deviceNameRules"
                label="Device Name"
                required
                ></v-text-field>

                <v-select
                v-model="deviceType"
                :items="this.$store.getters.getListOfDevicesTypes"
                :rules="deviceTypeRules"
                label="Device Type"
                required
                ></v-select>

                <v-select
                v-model="deviceLocalization"
                :items="listOfLocalizations"
                :rules="deviceLocalizationRules"
                label="Device Localization"
                required
                ></v-select>
                <v-btn
                :disabled="!valid"
                color="success"
                v-on:click="addDevice">
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
        deviceNameRules:[
            v => !!v || 'Name is required'
        ],
        deviceType: '',
        deviceTypeRules: [
            v=> !!v || 'Type is required'
        ],
        deviceLocalization: '',
        deviceLocalizationRules: [
            v=> !!v || 'Localization is required'
        ],
        deviceState: 'Disabled',
    }),
    computed:{
        listOfLocalizations(){
            var list = [];
            this.$store.getters.getListOfLocalizations.forEach(element => {
                list.push(element.Name);
            });
            return list;
        },
    },
    methods:{
        showDevicesList(){
            Promise.all([this.$store.dispatch('getDevices'),this.$store.dispatch('getLocalizations'),this.$store.dispatch('getActions')]).then(()=>{
                this.$store.commit('createGroups');
                 this.$store.commit('display',{to:'showDevicesList',from:'showMenu'});
            })
        },
        addDevice(){
            var device = {
                Name: this.deviceName,
                Type: this.deviceType,
                Localization: this.deviceLocalization,
                State: this.deviceState

            }  
            if(this.$refs.addDeviceForm.validate()){
                this.$store.dispatch('addDeviceToDB',device);
            }

        }
    }
}
</script>
