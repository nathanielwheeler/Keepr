<template>
	<div class="vault-card card">
		<div class="card-header d-flex justify-content-between">
			<h3 class="align-self-end">{{vaultProp.name}}</h3>
			<button @click="deleteVault(vaultProp.id)" class="btn btn-outline">X</button>
		</div>
		<div class="card-body">
			<keep-card v-for="keep in vKeeps" :key="keep.id" />
		</div>
	</div>
</template>


<script>
import KeepCard from "./KeepCard.vue";
export default {
	name: "vault-card",
	data() {
		return {};
	},
	mounted() {
		this.$store.dispatch("getVaultKeeps", this.id);
	},
	computed: {
		vKeeps() {
			return this.$store.state.vaultKeeps[this.id];
		}
	},
	props: ["vaultProp"],
	methods: {
		deleteVault(vaultId) {
			console.log(vaultId);
			this.$store.dispatch("deleteVault", vaultId);
		}
	},
	components: { KeepCard }
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