<template>
	<div class="dash-vaults container-fluid">
		<h3>{{user.username}}'s Vaults</h3>
		<new-vault-button />
		<div class="grid-container">
			<vault-card
				v-for="(vault, index) in vaults"
				:vaultProp="vault"
				:key="vault.id"
				v-bind:style="{'grid-column-start': index+1}"
			/>
		</div>
	</div>
</template>


<script>
import VaultCard from "../components/VaultCard.vue";
import NewVaultButton from "../components/NewVaultButton.vue";

export default {
	name: "dash-vaults",
	data() {
		return {};
	},
	mounted() {
		this.$store.dispatch("getVaults");
	},
	computed: {
		user() {
			return this.$store.state.user;
		},
		vaults() {
			return this.$store.state.vaults;
		}
	},
	methods: {},
	components: { VaultCard, NewVaultButton }
};
</script>


<style scoped>
.grid-container {
	overflow-x: auto;
	display: grid;
	grid-template-columns: 400px;
	grid-column-gap: 15px;
	height: 80vh;
	width: 100%;
}
</style>