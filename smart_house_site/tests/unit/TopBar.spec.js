import { shallowMount, createLocalVue, mount } from '@vue/test-utils'
import localVueFactory from './local-vue-factory'
import Vuex from 'vuex'
import TopBar from '@/components/TopBar.vue'
import Vuetify from 'vuetify'



describe('TopBar.vue',()=>{
    let mutations
    let store
    let getters
    let wrapper
    
    beforeEach(()=>{
        const localVue = localVueFactory.create()

        localVue.use(Vuex)
        localVue.use(Vuetify)

        getters ={
            getDisplayStatus: function(){
                return true
            }
        }
        mutations={
            goBack: jest.fn()
        }
        store = new Vuex.Store({
            mutations,
            getters
        })
        wrapper = mount(TopBar,{
            localVue:localVue,
            store
        })
    })

    it('commit "goBack" when button is clicked',()=>{
        wrapper.find('.btn-back').trigger('click')
        expect(mutations.goBack).toHaveBeenCalled()
    })
    it('show button when displayStatus is true',() =>{
        expect(wrapper.find('.btn-back').exists()).toBe(true)
    })
    it('getter getDisplayStatus returns true',() =>{
        expect(getters.getDisplayStatus()).toBe(true)
    })
    it('should display site name on tope',()=>{
        expect(wrapper.find('.site-title').exists()).toBe(true)
    })
})
