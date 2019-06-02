<template>
<v-container v-show="this.$store.getters.getDisplayStatus.showAddDevice">
    <v-layout>
        <v-flex>
            <v-form ref="addLocalizationForm" v-model="valid" lazy-validation >
                <v-text-field
                v-model="localizationName"
                :rules="localizationNameRules"
                label="Localization Name"
                required
                ></v-text-field>

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
        localizationName: '',
        localizationNameRules:[
            v => !!v || 'Name is required'
        ]
    }),
    methods:{
        addLocalization(){
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
