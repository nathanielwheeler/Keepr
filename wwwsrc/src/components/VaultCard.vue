<template>
	<div class="vault-card card">
		<h6 class="card-header">{{vaultProp.name}}</h6>
	</div>
</template>


<script>
export default {
	name: "vault-card",
	data() {
		return {};
	},
	computed: {},
	props: ["vaultProp"],
	methods: {},
	components: {}
};
</script>


<style scoped>
.vault-card {
	max-width: 400px;
	min-width: 400px;
	margin-right: 7.5px;
	margin-left: 7.5px;
}
</style>