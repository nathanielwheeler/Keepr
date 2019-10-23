<template>
	<div class="dashboard container">
		<h3>{{user.username}}'s Dashboard</h3>
		<dash />
	</div>
</template>

<script>
import Dash from "../components/Dash.vue";
export default {
	name: "dashboard",
	computed: {
		user() {
			return this.$store.state.user;
		}
	},
	methods: {},
	components: {
		Dash
	}
};
</script>