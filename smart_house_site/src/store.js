import Vue from 'vue';
import Vuex from 'vuex';
import VueResource from 'vue-resource';

Vue.use(Vuex);
Vue.use(VueResource);

var api = 'https://smarthouseapii.azurewebsites.net/';

export const store = new Vuex.Store({
    state:{
        menu:[
            {id:1, name:'Lista urządzeń',image:'', display: true},
            {id:2, name:'Dodaj urządzenie',image:'', display: true},
            {id:3, name:'Ustawienia',image:'', display: true},
        ],
        displayStatus: {showMenu:true,showDevicesList:false,showActionsList:false},
        lastPages:[],
        actualPage:[],
        listOfDevices: [],
        listOfAvailableActionsForAllTypes: [],
        actualListOfAction:[],
        actualDeviceType:"",
        actualDeviceId:"",
        actualDeviceState:"",
        categories: [],
        groups: []
    },
    getters:{
        getMenuOptions(state){
            return state.menu;
        },
        getListOfDevices(state){
            return state.listOfDevices;
        },
        getDisplayStatus(state){
            return state.displayStatus;
        },

        getActionsForDevice(state){
            return state.actualListOfAction;
        },
        getLastPage(state){
            return state.lastPage;
        },
        getActualPage(state){
            return state.actualPage;
        },
        getActualDeviceState(state){
            return state.actualDeviceState;
        },
        getActualDeviceId(state){
            return state.actualDeviceId;
        }
        
    },
    mutations:{
        loadDevices(state, listOfNewDevices){
            state.listOfDevices = listOfNewDevices;
        },
        loadActions(state,listOfNewActions){
            state.listOfAvailableActionsForAllTypes = listOfNewActions;
        },
        loadActualDeviceState(state,actualState){
            state.actualDeviceState = actualState;
        },
        display(state,{to,from}){
            state.displayStatus[to] = true;
            state.displayStatus[from] = false;
            state.actualPage = to;
            state.lastPages.push(from);
        },
        goBack(state){
            state.displayStatus[state.actualPage] = false;
            state.actualPage = state.lastPages.pop();
            state.displayStatus[state.actualPage] = true;
        },
        changeActualDevice(state,payload){
            state.actualDeviceType = payload.deviceType;
            state.actualDeviceId = payload.deviceId;
        },

        filterActionsForDevice(state){
            state.actualListOfAction = state.listOfAvailableActionsForAllTypes.find((element)=>{
                return element.Type == state.actualDeviceType;
            }).AvailableActions;
        }
    },
    actions:{
        getDevices(context){
            Vue.http.get(api+'api/GetAllSmartDevices').then(response => {
                context.commit('loadDevices',response.body);
            });
        },
        getActions(context){
            Vue.http.get(api+'api/GetTypesOfSmartDevicesWithAvailableActions').then(response => {
                context.commit('loadActions',response.body);
                context.commit('filterActionsForDevice');
                context.commit('display',{to:'showActionsList',from:'showDevicesList'});
            });
        },
        getActualDeviceState(context){
            Vue.http.get(api+'api/GetStateOfSingleSmartDevice?id='+context.getters.getActualDeviceId).then(response => {
                context.commit('loadActualDeviceState',response.body);
            });
        },
        changeDeviceState(context,newState){
            Vue.http.post(api+'api/SetSpecificPropertyOfSingleSmartDevice?id='+context.getters.getActualDeviceId+'&propertyName=State&propertyValue='+newState)
                .then(()=>{
                context.dispatch('getActualDeviceState');
            });
        }
    }
});

