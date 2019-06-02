<template>
<v-container v-show="this.$store.getters.getDisplayStatus.showAddLocalization">
    <v-layout>
        <v-flex>
            <v-form ref="addLocalizationForm" v-model="valid" >
                <v-text-field
                v-model="localizationName"
                :rules="localizationNameRules"
                label="Localization Name"
                required
                ></v-text-field>
                <v-text-field
                v-model="localizationIcon"
                :rules="localizationIconRules"
                label="Localization Icon"
                required
                ></v-text-field>

                <v-btn
                :disabled="!valid"
                color="success"
                v-on:click="addLocalization">
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
        ],
        localizationIcon: '',
        localizationIconRules:[
            v => !!v || 'Icon is required'
        ],
    }),
    methods:{
        addLocalization(){
            var location = {
                Name: this.localizationName,
                Icon: this.localizationIcon

            }  
            if(this.$refs.addLocalizationForm.validate()){
                this.$store.dispatch('addLocalizationToDB',location).then((response)=>{
                    if(response.ok){
                        this.$refs.addLocalizationForm.reset()
                    }
                })
            }

        }
    }
}
</script>
