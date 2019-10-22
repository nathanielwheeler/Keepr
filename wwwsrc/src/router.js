import Vue from 'vue'
import Router from 'vue-router'
// @ts-ignore
import Dashboard from './views/Dashboard.vue'
// @ts-ignore
import Login from './views/Login.vue'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'dashboard',
      component: Dashboard
    },
    {
      path: '/login',
      name: 'login',
      component: Login
    }
  ]
})
