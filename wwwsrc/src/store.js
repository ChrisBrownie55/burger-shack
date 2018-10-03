import Vue from 'vue'
import Vuex from 'vuex'

import Axios from 'axios'

const server = Axios.create({
  baseURL: '//locahost:5000/api/',
  timeout: 3000
})

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    burgers: []
  },
  mutations: {
    setBurgers(state, burgers) {
      state.burgers = burgers;
    }
  },
  actions: {
    async getBurgers({ commit }) {
      try {
        const { data: burgers } = server.get('burgers')
        commit('setBurgers', burgers)
      } catch (error) {
        console.log("%c[ERROR] ", "font-weight: bold; color: red;", error)
      }
    }
  }
})
