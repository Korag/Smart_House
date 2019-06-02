<template>
<v-container v-show="this.$store.getters.getDisplayStatus.showEditDevice">
    <v-layout>
        <v-flex>
            <v-form ref="addDeviceForm" v-model="valid" lazy-validation >
                <v-text-field
                v-model="actualDevice.Name"
                :rules="deviceNameRules"
                label="Device Name"
                required
                ></v-text-field>

                <v-select
                v-model="actualDevice.Type"
                :items="this.$store.getters.getListOfDevicesTypes"
                :rules="deviceTypeRules"
                label="Device Type"
                required
                ></v-select>

                <v-select
                v-model="actualDevice.Localization"
                :items="listOfLocalizations"
                :rules="deviceLocalizationRules"
                label="Device Localization"
                required
                ></v-select>
                <v-btn
                :disabled="!valid"
                color="warning"
                v-on:click="editDevice">
                Edit
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
        deviceNameRules:[
            v => !!v || 'Name is required'
        ],
        deviceTypeRules: [
            v=> !!v || 'Type is required'
        ],
        deviceLocalizationRules: [
            v=> !!v || 'Localization is required'
        ]
    }),
    computed:{
        listOfLocalizations(){
            var list = [];
            this.$store.getters.getListOfLocalizations.forEach(element => {
                list.push(element.Name);
            });
            return list;
        },
        actualDevice(){
            return this.$store.getters.getActualDevice;
        }
    },
    methods:{
        editDevice(){
            if(this.$refs.addDeviceForm.validate()){
                this.$store.dispatch('modifyDeviceInDB');
            }

        }
    }
}
</script>
