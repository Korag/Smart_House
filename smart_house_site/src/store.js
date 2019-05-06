import Vue from 'vue';
import Vuex from 'vuex';
import VueResource from 'vue-resource';

Vue.use(Vuex);
Vue.use(VueResource);

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
    },
    mutations:{
        loadDevices(state, listOfNewDevices){
            state.listOfDevices = listOfNewDevices;
        }
    },
    actions:{
        getDevices(context){
            Vue.http.get('http://localhost:61635/api/GetAllSmartDevices').then(response => {
                context.commit('loadDevices',response.body);
            }, response =>{
                console.log(response);
            });
        }
    }
});

