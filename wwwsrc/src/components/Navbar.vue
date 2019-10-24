<template>
	<div class="navbar d-flex justify-content-center">
		<router-link to="/" class="btn btn-outline">Dashboard</router-link>
		<router-link to="/vaults" class="btn btn-outline">Vaults</router-link>
		<router-link to="/keeps" class="btn btn-outline">Keeps</router-link>
		<button v-if="user.id" @click="logout" class="btn btn-outline">Logout</button>
		<router-link v-else :to="{name: 'login'}" class="btn btn-outline">Login</router-link>
	</div>
</template>


<script>
export default {
	name: "navbar",
	data() {
		return {};
	},
	computed: {
		user() {
			return this.$store.state.user;
		}
	},
	methods: {
		logout() {
			this.$store.dispatch("logout");
		},
		isMobile() {
			if (
				/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(
					navigator.userAgent
				) // ||
				// window.innerWidth < 768
			) {
				return true;
			} else {
				return false;
			}
		}
	},
	components: {}
};
</script>


<style scoped>
</style>