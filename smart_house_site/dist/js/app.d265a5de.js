(function(t){function e(e){for(var n,c,o=e[0],r=e[1],u=e[2],f=0,p=[];f<o.length;f++)c=o[f],a[c]&&p.push(a[c][0]),a[c]=0;for(n in r)Object.prototype.hasOwnProperty.call(r,n)&&(t[n]=r[n]);l&&l(e);while(p.length)p.shift()();return s.push.apply(s,u||[]),i()}function i(){for(var t,e=0;e<s.length;e++){for(var i=s[e],n=!0,o=1;o<i.length;o++){var r=i[o];0!==a[r]&&(n=!1)}n&&(s.splice(e--,1),t=c(c.s=i[0]))}return t}var n={},a={app:0},s=[];function c(e){if(n[e])return n[e].exports;var i=n[e]={i:e,l:!1,exports:{}};return t[e].call(i.exports,i,i.exports,c),i.l=!0,i.exports}c.m=t,c.c=n,c.d=function(t,e,i){c.o(t,e)||Object.defineProperty(t,e,{enumerable:!0,get:i})},c.r=function(t){"undefined"!==typeof Symbol&&Symbol.toStringTag&&Object.defineProperty(t,Symbol.toStringTag,{value:"Module"}),Object.defineProperty(t,"__esModule",{value:!0})},c.t=function(t,e){if(1&e&&(t=c(t)),8&e)return t;if(4&e&&"object"===typeof t&&t&&t.__esModule)return t;var i=Object.create(null);if(c.r(i),Object.defineProperty(i,"default",{enumerable:!0,value:t}),2&e&&"string"!=typeof t)for(var n in t)c.d(i,n,function(e){return t[e]}.bind(null,n));return i},c.n=function(t){var e=t&&t.__esModule?function(){return t["default"]}:function(){return t};return c.d(e,"a",e),e},c.o=function(t,e){return Object.prototype.hasOwnProperty.call(t,e)},c.p="/";var o=window["webpackJsonp"]=window["webpackJsonp"]||[],r=o.push.bind(o);o.push=e,o=o.slice();for(var u=0;u<o.length;u++)e(o[u]);var l=r;s.push([0,"chunk-vendors"]),i()})({0:function(t,e,i){t.exports=i("56d7")},"034f":function(t,e,i){"use strict";var n=i("64a9"),a=i.n(n);a.a},"06ec":function(t,e,i){},1:function(t,e){},"25e5":function(t,e,i){"use strict";var n=i("56bc"),a=i.n(n);a.a},"2df3":function(t,e,i){},4011:function(t,e,i){},"56bc":function(t,e,i){},"56d7":function(t,e,i){"use strict";i.r(e);i("cadf"),i("551c"),i("f751"),i("097d");var n=i("2b0e"),a=function(){var t=this,e=t.$createElement,i=t._self._c||e;return i("div",{attrs:{id:"app"}},[i("TopBar"),i("Menu"),i("DevicesList"),i("ActionsMenu")],1)},s=[],c=function(){var t=this,e=t.$createElement,i=t._self._c||e;return i("div",{directives:[{name:"show",rawName:"v-show",value:this.$store.getters.getDisplayStatus.showMenu,expression:"this.$store.getters.getDisplayStatus.showMenu"}]},t._l(t.menu,function(e){return i("div",{key:e.id,staticClass:"menuItem",on:{click:t.showDevicesList}},[i("img",{attrs:{src:e.image}}),i("div",[t._v(t._s(e.name))])])}),0)},o=[],r={computed:{menu:function(){return this.$store.getters.getMenuOptions}},methods:{showDevicesList:function(){this.$store.dispatch("getDevices"),this.$store.commit("display",{to:"showDevicesList",from:"showMenu"})}}},u=r,l=(i("7f05"),i("2877")),f=Object(l["a"])(u,c,o,!1,null,"4164c634",null),p=f.exports,v=function(){var t=this,e=t.$createElement,i=t._self._c||e;return i("div",{directives:[{name:"show",rawName:"v-show",value:this.$store.getters.getDisplayStatus.showDevicesList,expression:"this.$store.getters.getDisplayStatus.showDevicesList"}]},t._l(t.devices,function(e){return i("div",{key:e.id,staticClass:"menuItem",on:{click:function(i){return t.DisplayActions(e.Type,e.Id)}}},[i("div",[t._v(t._s(e.Name))]),i("div",[t._v(t._s(e.State))]),i("div",[t._v(t._s(e.Type))])])}),0)},d=[],g={computed:{devices:function(){return this.$store.getters.getListOfDevices}},methods:{DisplayActions:function(t,e){this.$store.commit("changeActualDevice",{deviceType:t,deviceId:e}),this.$store.dispatch("getActions"),this.$store.dispatch("getActualDeviceState")}}},h=g,m=(i("8af5"),Object(l["a"])(h,v,d,!1,null,"63cac7f9",null)),D=m.exports,y=function(){var t=this,e=t.$createElement,n=t._self._c||e;return n("div",{staticClass:"topBar",on:{click:t.goBack}},[this.$store.getters.getDisplayStatus.showMenu?t._e():n("img",{staticClass:"arrow",attrs:{src:i("b94f")}}),t._v("\n    Smart House")])},S=[],A={methods:{goBack:function(){this.$store.commit("goBack")}}},b=A,w=(i("debd"),Object(l["a"])(b,y,S,!1,null,"1f970e5a",null)),_=w.exports,O=function(){var t=this,e=t.$createElement,i=t._self._c||e;return this.$store.getters.getDisplayStatus.showActionsList?i("div",[i("div",{staticClass:"actualState"},[t._v("Aktualny stan: "+t._s(t.actualState))]),t._l(t.actions.filter(function(e){return e!=t.actualState}),function(e){return i("div",{key:e,staticClass:"menuItem",on:{click:function(i){return t.changeState(e)}}},[i("div",[t._v(t._s(e))])])})],2):t._e()},$=[],L={computed:{actions:function(){return this.$store.getters.getActionsForDevice},actualState:function(){return this.$store.getters.getActualDeviceState}},methods:{changeState:function(t){this.$store.dispatch("changeDeviceState",t)}}},P=L,T=(i("25e5"),Object(l["a"])(P,O,$,!1,null,"62e941a2",null)),k=T.exports,M={name:"app",components:{Menu:p,DevicesList:D,TopBar:_,ActionsMenu:k}},j=M,x=(i("034f"),Object(l["a"])(j,a,s,!1,null,null,null)),I=x.exports,B=(i("7514"),i("2f62")),F=i("28dd");n["a"].use(B["a"]),n["a"].use(F["a"]);var C="https://smarthouseapii.azurewebsites.net/",z=new B["a"].Store({state:{menu:[{id:1,name:"Lista urządzeń",image:"",display:!0},{id:2,name:"Dodaj urządzenie",image:"",display:!0},{id:3,name:"Ustawienia",image:"",display:!0}],displayStatus:{showMenu:!0,showDevicesList:!1,showActionsList:!1},lastPages:[],actualPage:[],listOfDevices:[],listOfAvailableActionsForAllTypes:[],actualListOfAction:[],actualDeviceType:"",actualDeviceId:"",actualDeviceState:"",categories:[],groups:[]},getters:{getMenuOptions:function(t){return t.menu},getListOfDevices:function(t){return t.listOfDevices},getDisplayStatus:function(t){return t.displayStatus},getActionsForDevice:function(t){return t.actualListOfAction},getLastPage:function(t){return t.lastPage},getActualPage:function(t){return t.actualPage},getActualDeviceState:function(t){return t.actualDeviceState},getActualDeviceId:function(t){return t.actualDeviceId}},mutations:{loadDevices:function(t,e){t.listOfDevices=e},loadActions:function(t,e){t.listOfAvailableActionsForAllTypes=e},loadActualDeviceState:function(t,e){t.actualDeviceState=e},display:function(t,e){var i=e.to,n=e.from;t.displayStatus[i]=!0,t.displayStatus[n]=!1,t.actualPage=i,t.lastPages.push(n)},goBack:function(t){t.displayStatus[t.actualPage]=!1,t.actualPage=t.lastPages.pop(),t.displayStatus[t.actualPage]=!0},changeActualDevice:function(t,e){t.actualDeviceType=e.deviceType,t.actualDeviceId=e.deviceId},filterActionsForDevice:function(t){t.actualListOfAction=t.listOfAvailableActionsForAllTypes.find(function(e){return e.Type==t.actualDeviceType}).AvailableActions}},actions:{getDevices:function(t){n["a"].http.get(C+"api/GetAllSmartDevices").then(function(e){t.commit("loadDevices",e.body)})},getActions:function(t){n["a"].http.get(C+"api/GetTypesOfSmartDevicesWithAvailableActions").then(function(e){t.commit("loadActions",e.body),t.commit("filterActionsForDevice"),t.commit("display",{to:"showActionsList",from:"showDevicesList"})})},getActualDeviceState:function(t){n["a"].http.get(C+"api/GetStateOfSingleSmartDevice?id="+t.getters.getActualDeviceId).then(function(e){t.commit("loadActualDeviceState",e.body)})},changeDeviceState:function(t,e){n["a"].http.post(C+"api/SetSpecificPropertyOfSingleSmartDevice?id="+t.getters.getActualDeviceId+"&propertyName=State&propertyValue="+e).then(function(){t.dispatch("getActualDeviceState")})}}});n["a"].config.productionTip=!1,new n["a"]({store:z,render:function(t){return t(I)}}).$mount("#app")},"64a9":function(t,e,i){},"7f05":function(t,e,i){"use strict";var n=i("06ec"),a=i.n(n);a.a},"8af5":function(t,e,i){"use strict";var n=i("4011"),a=i.n(n);a.a},b94f:function(t,e,i){t.exports=i.p+"img/arrow.9089344d.svg"},debd:function(t,e,i){"use strict";var n=i("2df3"),a=i.n(n);a.a}});
//# sourceMappingURL=app.d265a5de.js.map