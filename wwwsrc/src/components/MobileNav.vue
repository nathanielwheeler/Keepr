<template>
	<div class="mobile-nav">
		<router-link to="/vaults" class="btn btn-outline">Vaults</router-link>
		<router-link to="/keeps" class="btn btn-outline">Keeps</router-link>
		<button v-if="user.id" @click="logout" class="btn btn-outline">Logout</button>
		<router-link v-else :to="{name: 'login'}" class="btn btn-outline">Login</router-link>
	</div>
</template>


<script>
export default {
	name: "mobile-nav",
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
		}
	},
	components: {}
};
</script>


<style scoped>
</style>