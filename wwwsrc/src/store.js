import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'
import AuthService from './AuthService'
import { generateKeyPairSync } from 'crypto'

Vue.use(Vuex)

let baseUrl = location.host.includes('localhost') ? 'https://localhost:5001/' : '/'

let api = Axios.create({
	baseURL: baseUrl + "api/",
	timeout: 3000,
	withCredentials: true
})

export default new Vuex.Store({
	state: {
		user: {},
		keeps: [],
		selectedKeep: {},
		userKeeps: [],
		vaults: {},
		vaultKeeps: {}
	},
	mutations: {
		setUser(state, user) {
			state.user = user
		},
		resetState(state) {
			//clear the entire state object of user data
			state.user = {}
		},
		setKeeps(state, keeps) {
			state.keeps = keeps;
		},
		setUserKeeps(state, userKeeps) {
			state.userKeeps = userKeeps;
		},
		setSelectedKeep(state, keep) {
			state.selectedKeep = keep
		},
		setVaults(state, vaults) {
			state.vaults = vaults;
		},
		setVaultKeeps(state, payload) {
			state.vaultKeeps[payload.vaultId] = payload;
		}
	},
	actions: {
		// #region Auth

		async register({ commit, dispatch }, creds) {
			try {
				let user = await AuthService.Register(creds)
				commit('setUser', user)
				router.push({ name: "dashboard" })
			} catch (e) {
				console.warn(e.message)
			}
		},
		async login({ commit, dispatch }, creds) {
			try {
				let user = await AuthService.Login(creds)
				commit('setUser', user)
				router.push({ name: "dashboard" })
			} catch (e) {
				console.warn(e.message)
			}
		},
		async logout({ commit, dispatch }) {
			try {
				let success = await AuthService.Logout()
				if (!success) { }
				commit('resetState')
				router.push({ name: "login" })
			} catch (e) {
				console.warn(e.message)
			}
		},

		// #endregion
		// #region Keeps

		async getKeeps({ commit, dispatch }) {
			console.log("Getting keeps...")
			try {
				let res = await api.get('keeps')
				commit('setKeeps', res.data)
			} catch (error) { console.error(error) }
		},
		async getKeepById({ commit, dispatch }, keepId) {
			try {
				let res = await api.get(`keeps/${keepId}`)
				commit('setSelectedKeep', res.data)
			} catch (error) { console.error(error) }
		},
		async getUserKeeps({ commit, dispatch }) {
			try {
				let res = await api.get('keeps/user')
				commit('setUserKeeps', res.data)
			} catch (error) { console.error(error) }
		},
		async logView({ commit, dispatch }, keepId) {
			try {
				await api.put(`keeps/${keepId}/view`)
				dispatch('getKeeps')
			} catch (error) { console.error(error) }
		},
		async logShare({ commit, dispatch }, keepId) {
			try {
				await api.put(`keeps/${keepId}/share`)
				dispatch('getKeeps')
			} catch (error) { console.error(error) }
		},
		async addKeep({ commit, dispatch }, newKeep) {
			try {
				await api.post('keeps', newKeep)
				dispatch('getKeeps')
				dispatch('getUserKeeps')
			} catch (error) { console.error(error) }
		},



		// #endregion
		// #region Vaults

		async getVaults({ commit, dispatch }) {
			console.log("Getting vaults...")
			try {
				let res = await api.get('vaults')
				commit('setVaults', res.data)
			} catch (error) { console.error(error) }
		},
		async addVault({ commit, dispatch }, payload) {
			console.log("Adding vault...")
			try {
				await api.post('vaults', payload)
				dispatch('getVaults')
			} catch (error) { console.error(error) }
		},
		async deleteVault({ commit, dispatch }, vaultId) {
			try {
				await api.delete(`vaults/${vaultId}`)
				dispatch('getVaults')
			} catch (error) { console.error(error) }
		},

		// #endregion
		// #region VaultKeeps

		async getVaultKeeps({ commit, dispatch }, vault) {
			console.log(`Getting keeps from '${vault.name}'...`)
			try {
				let payload = {}
				payload.vaultId = vault.id
				payload.res = await api.get('vaultkeeps/' + vault.id)
				commit('setVaultKeeps', payload)
			} catch (error) { console.error(error) }
		},
		async addVaultKeep({ commit, dispatch }, payload) {
			try {
				await api.post('vaultkeeps', payload)
				dispatch('getVaultKeeps')
			} catch (error) { console.error(error) }
		},
		async removeVaultKeep({ commit, dispatch }, payload) {
			try {
				await api.put('vaultkeeps', payload)
				dispatch('getVaultKeeps')
			} catch (error) { console.error(error) }
		},


		// #endregion
	}
})
