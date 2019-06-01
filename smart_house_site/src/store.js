import Vue from 'vue';
import Vuex from 'vuex';
import VueResource from 'vue-resource';

Vue.use(Vuex);
Vue.use(VueResource);

var api = 'http://localhost:61635/';

export const store = new Vuex.Store({
    state:{
        menu:[
            {id:1, name:'Lista urządzeń',icon:'list_alt', display: true},
            {id:2, name:'Dodaj urządzenie',icon:'add_to_queue', display: true},
            {id:3, name:'Ustawienia',icon:'settings', display: true},
        ],
        displayStatus: {showMenu:true,showDevicesList:false,showActionsList:false},
        lastPages:[],
        actualPage:[],
        listOfDevices: [],
        listOfAvailableActionsForAllTypes: [],
        actualDevice:{},
        categories: [],
        localizations:[],
        groups: {}

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
        getLastPage(state){
            return state.lastPage;
        },
        getActualPage(state){
            return state.actualPage;
        },
        getListOfLocalizations(state){
            return state.localizations;
        },
        getGroups(state){
            return state.groups;
        },
        getListOfActionForDevice(state){
            return device => state.listOfAvailableActionsForAllTypes.find((element)=>{
                return element.Type == device.Type;
            }).AvailableActions;
        }
        
    },
    mutations:{
        loadDevices(state, listOfNewDevices){
            state.listOfDevices = listOfNewDevices;
        },
        loadActions(state,listOfNewActions){
            state.listOfAvailableActionsForAllTypes = listOfNewActions;
        },
        loadLocalizations(state,listOfLocalizations){
            state.localizations = listOfLocalizations;
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
        changeActualDevice(state,device){
            state.actualDevice = device;
        },
        createGroups(state){
            state.localizations.forEach(function(loc){
                state.groups[loc.Name] = {List:state.listOfDevices.filter(function(device){
                    return device.Localization == loc.Name;
                }),Icon: loc.Icon}
            })
            state.groups['Other'] ={List: state.listOfDevices.filter(function(device){
                for(var loc of state.localizations){
                    if(loc.Name == device.Localization){
                        return false
                    }
                }
                return true
            }),Icon:'devices_other'}
        
            for(var group in state.groups){
                if(state.groups[group]['List'].length == 0){
                    delete state.groups[group]
                }
            }
        },
        updateDeviceState(state,{device,newState}){
            var index = state.groups[device.Localization]['List'].findIndex(dev=> dev.Id == device.Id);
            state.groups[device.Localization]['List'][index].State = newState;
        },
    },
    actions:{
        getDevices(context){
            return new Promise((resolve,reject)=>{
                Vue.http.get(api+'api/GetAllSmartDevices').then(response => {
                    context.commit('loadDevices',response.body);
                    resolve(response);
                },error =>{
                    reject(error);
                });
            })
        },
        getActions(context){
            return new Promise((resolve,reject)=>{
                Vue.http.get(api+'api/GetTypesOfSmartDevicesWithAvailableActions').then(response => {
                    context.commit('loadActions',response.body);
                    resolve(response);
                   // context.commit('filterActionsForDevice');
                },error =>{
                    reject(error);
                });
            })
        },
        getActualDeviceState(context,device){
            Vue.http.get(api+'api/GetStateOfSingleSmartDevice?id='+device.Id).then(response => {
                context.commit('updateDeviceState',{dev:device,res: response.body});
            });
        },
        getLocalizations(context){
            return new Promise((resolve,reject) =>{
                Vue.http.get(api+'api/GetAvailableLocalizations').then(response=>{
                    context.commit('loadLocalizations',response.body);
                    resolve(response);
                }, error =>{
                    reject(error);
                })
            })
        },
        changeDeviceState(context,{device,newState}){
            Vue.http.post(api+'api/SetSpecificPropertyOfSingleSmartDevice?id='+device.Id+'&propertyName=State&propertyValue='+newState)
                .then((response)=>{
                    if(response.ok){
                        context.commit('updateDeviceState',{device,newState});
                    }
            });
        }
    }
});

