<template>
	<div class="vault-card card">
		<h6 class="card-header">{{vaultProp.name}}</h6>
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
			return this.$store.vaults[this.id].vKeeps;
		}
	},
	props: ["vaultProp"],
	methods: {},
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