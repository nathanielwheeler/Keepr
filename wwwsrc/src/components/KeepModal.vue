<template>
	<div class="modal-backdrop">
		<div class="modal" role="dialog">
			<header class="modal-header">
				<h1>{{keepProp.name}}</h1>
				<button @click="close()" type="button" class="btn btn-outline">X</button>
			</header>
			<section class="modal-body">
				<img class="container-fluid modal-image" :src="keepProp.img" />
				<br />
				<div class="d-flex justify-content-around">
					<span></span>
					<span>Views: {{keepProp.views}}</span>
					<span>Shares: {{keepProp.shares}}</span>
					<span>Keeps: {{keepProp.keeps}}</span>
					<span></span>
				</div>
				<br />
				<p class="text-left container">{{keepProp.description}}</p>
			</section>
			<footer class="modal-footer">
				<button
					@click="logShare()"
					v-clipboard:copy="shareLink"
					type="button"
					class="btn btn-outline"
				>Share to Clipboard!</button>
				<div class="input-group half-width">
					<select v-model="vaultId" class="custom-select">
						<option>(Select Vault)</option>
						<option v-for="vault in vaults" :value="vault.id" :key="vault.id">{{vault.name}}</option>
					</select>
					<div class="input-group-append">
						<button class="btn btn-outline no-margin" @click="addVaultKeep">Add to Vault!</button>
					</div>
				</div>
			</footer>
		</div>
	</div>
</template>


<script>
export default {
	name: "keep-modal",
	data() {
		return {
			vaultId: 0,
			shareLink: "https://localhost:8080/#/keeps/" + keepProp.id
		};
	},
	computed: {
		vaults() {
			return this.$store.state.vaults;
		}
	},
	props: ["keepProp"],
	methods: {
		close() {
			this.$emit("close");
		},
		logShare() {
			this.$store.dispatch("logShare", this.keepProp.id);
		},
		addVaultKeep(vaultId) {
			let payload = {};
			payload.vaultId = vaultId;
			payload.keepId = this.keepProp.id;
			this.$store.dispatch("addVaultKeep", payload);
		}
	},
	components: {}
};
</script>


<style scoped>
.modal-backdrop {
	position: fixed;
	top: 0;
	bottom: 0;
	left: 0;
	right: 0;
	background-color: rgba(0, 0, 0, 0.3);
	display: flex;
	justify-content: center;
	align-items: center;
}
.modal {
	background: #201d19;
	box-shadow: 2px 2px 20px 1px;
	overflow-x: auto;
	overflow-y: auto;
	display: flex;
	flex-direction: column;
}
.modal-header,
.modal-footer {
	padding: 15px;
	display: flex;
}
.modal-header {
	border-bottom: 1px solid #be862c;
	color: #f9d094;
	justify-content: space-between;
}
.modal-footer {
	border-top: 1px solid #be862c;
	justify-content: space-around;
}
.modal-body {
	position: relative;
	padding: 20px 10px;
}
.modal-image {
	max-height: 60vh;
	width: auto;
}
.no-margin {
	margin: 0;
}
.half-width {
	width: 50%;
}
.custom-select {
	background: #2e2a24;
}
</style>