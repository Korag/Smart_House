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
                <div class="">Icon:</div>
                <v-item-group v-model="activeIcon" mandatory>
                    <v-layout row wrap>
                        <v-flex
                        v-for="(icon,index) in iconsList"
                        :key="index"
                        md1 lg1 xl1 py-1 px-1
                        >
                        <v-item>
                            <v-card class="text-xs-center" 
                            slot-scope="{ active, toggle }"
                            :color="active ? 'blue' : 'white'"
                            @click="toggle">
                            <v-icon :color="active ? 'white' : ''" size="50px">{{icon}}</v-icon>
                            </v-card>
                        </v-item>
                        </v-flex>
                    </v-layout>
                </v-item-group>
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
        iconsList:['account_balance','assessment','accessibility','accessible','build','delete','extension','favorite','grade',
        'accessible','change_history','verified_user','work','airplay','movie','radio'
        ],
        activeIcon:'0'
    }),
    methods:{
        addLocalization(){
            var location = {
                Name: this.localizationName,
                Icon: this.iconsList[this.activeIcon]

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
