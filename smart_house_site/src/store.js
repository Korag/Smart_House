import Vue from 'vue';
import Vuex from 'vuex';

Vue.use(Vuex);

export const store = new Vuex.Store({
    state:{
        menu:[
            {id:1, name:'Lista urządzeń',image:'', display: true},
            {id:2, name:'Dodaj urządzenie',image:'', display: true},
            {id:3, name:'Ustawienia',image:'', display: true},
        ],
        listOfDevices: [],
        categories: [],
        groups: []
    },
    getters:{
        menuOptions(state){
            return state.menu;
        }
    }
});

