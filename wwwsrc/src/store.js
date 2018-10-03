import Vue from 'vue'
import Vuex from 'vuex'

import Axios from 'axios'

const server = Axios.create({
  baseURL: '//localhost:5000/api/',
  timeout: 3000
})

Vue.use(Vuex)

const logError = error => console.log(
  '%c[ERROR]\n',
  'font-weight: bold; color: #222; font-size: 0.85rem; border-bottom: solid 1px #222; padding: 0.15rem; background-color: rgba(0, 0, 0, 0.015);',
  error
)

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
        const { data: burgers } = await server.get('burgers')
        commit('setBurgers', burgers)
      } catch (error) {
        logError(error)
      }
    }
  }
})
