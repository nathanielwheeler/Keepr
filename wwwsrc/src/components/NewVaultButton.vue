<template>
	<div class="new-vault-button">
		<h6 v-if="!formVisible" @click="showForm()" class="btn btn-outline">New Vault</h6>
		<form v-if="formVisible" @submit.prevent="addVault()" class="form-group">
			<div class="input-group">
				<div class="input-group-prepend">
					<button @click="showForm()" class="btn btn-outline no-margin">X</button>
				</div>
				<input
					type="text"
					class="form-control"
					placeholder="Vault Name"
					name="vault-name"
					v-model="name"
				/>
				<input
					type="text"
					class="form-control"
					placeholder="Description"
					name="vault-description"
					v-model="description"
				/>
				<div class="input-group-append">
					<button class="btn btn-outline no-margin" type="submit">Submit</button>
				</div>
			</div>
		</form>
	</div>
</template>


<script>
export default {
	name: "new-vault-button",
	data() {
		return {
			formVisible: false,
			name: "",
			description: ""
		};
	},
	computed: {
		user() {
			return this.$store.state.user;
		}
	},
	methods: {
		showForm() {
			if (this.formVisible === false) {
				this.formVisible = true;
			} else {
				this.formVisible = false;
			}
		},
		addVault() {
			console.log("Component method");
			let vault = {
				name: this.name,
				description: this.description,
				userId: this.user.id
			};
			this.$store.dispatch("addVault", vault);
			this.vault = {};
			this.formVisible = false;
		}
	},
	components: {}
};
</script>


<style scoped>
.no-margin {
	margin: 0px;
}
input {
	background: #201d19;
	border-color: #6b747c;
}
</style>