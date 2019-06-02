import Vue from 'vue';
import Vuex from 'vuex';
import VueResource from 'vue-resource';

Vue.use(Vuex);
Vue.use(VueResource);

var api = 'http://localhost:61635/';

export const store = new Vuex.Store({
    state:{
        menu:[
            {id:1, name:'My House',icon:'home', display: true,action:'showMyHouse'},
            {id:2, name:'Devices Manager',icon:'important_devices', display: true,action:'showDevicesManager'},
            {id:3, name:'Localizations Manager',icon:'location_searching', display: true,action:'showLocalizationsManager'},
            {id:4, name:'Actions Manager',icon:'filter_list', display: true,action:'d'}
        ],
        displayStatus: {showMenu:true,showMyHouse:false,showActionsList:false,
                        showDevicesManager:false,showAddDevice:false,showEditDevice:false,
                        showLocalizationsManager:false},
        lastPages:[],
        actualPage:[],
        listOfDevices: [],
        listOfAvailableActionsForAllTypes: [],
        actualDevice:{},
        categories: [],
        localizations:[],
        groups: {},
        devicesTypes: []

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
        },
        getActualDevice(state){
            return state.actualDevice;
        },
        getListOfDevicesTypes(state){
            return state.devicesTypes;
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
        updateListOfDevicesTypes(state,newList){
            state.devicesTypes = newList;
        }
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
            return new Promise((resolve,reject)=>{
                Vue.http.get(api+'api/GetStateOfSingleSmartDevice?id='+device.Id).then(response => {
                    context.commit('updateDeviceState',{device,newState:response.body});
                    resolve(response);
                },error=>{
                    reject(error);
                });
            })

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
        },
        getDevicesTypes(context){
            return new Promise((resolve,reject)=>{
                Vue.http.get(api+'api/GetAvailableTypes').then(response=>{
                    context.commit('updateListOfDevicesTypes',response.body);
                    resolve(response);
                },error=>{
                    reject(error);
                })
            })
        },
        addDeviceToDB(context,device){
            Vue.http.post(api+'api/AddSmartDevice?type='+device.Type+'&name='+device.Name+'&state='+device.State+'&disabled=true&localization='+device.Localization)
            .then((response)=>{
                if(response.ok){
                    context.dispatch('getDevices');
                }
        });
        },
        deleteDeviceFromDB(context,device){
            Vue.http.post(api+'api/DeleteSmartDeviceFromCollection?id='+device.Id)
            .then((response)=>{
                if(response.ok){
                    context.dispatch('getDevices');
                }
            });
        },
        modifyDeviceInDB(context){
            var device = context.getters.getActualDevice;
            for (const property in device) {
                if(property !== "Id" && property !=="Disabled" && property !=="State"){
                    Vue.http.post(api+'api/SetSpecificPropertyOfSingleSmartDevice?id='+device.Id+'&propertyName='+property+'&propertyValue='+device[property])
                    .then((response)=>{
                    }); 
                }
                
            }
        },
        deleteLocalizationFromDB(context,localization){
            Vue.http.post(api+'api/DeleteLocalization?name='+localization.Name)
            .then((response)=>{
                if(response.ok){
                    context.dispatch('getDevices');
                }
            });
        },
        addLocalizationToDB(context,localization){
            Vue.http.post(api+'api/AddNewLocalization?name='+localization.Name+'&icon='+location.Icon)
            .then((response)=>{
                if(response.ok){
                    context.dispatch('getDevices');
                }
            });
        }
    }
});

