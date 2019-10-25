import Vue from 'vue'
import Router from 'vue-router'
// @ts-ignore
import Dashboard from './views/Dashboard.vue'
// @ts-ignore
import Login from './views/Login.vue'
import DashKeeps from './views/DashKeeps.vue'
import Keep from './views/Keep.vue'
import DashVaults from './views/DashVaults.vue'


Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'dashboard',
      component: Dashboard
    },
    {
      path: '/vaults',
      name: 'dash-vaults',
      component: DashVaults
    },
    {
      path: '/keeps',
      name: 'dash-keeps',
      component: DashKeeps
    },
    {
      path: '/keeps/:keepId',
      name: 'keep',
      props: true,
      component: Keep
    },
    {
      path: '/login',
      name: 'login',
      component: Login
    },

  ]
})
