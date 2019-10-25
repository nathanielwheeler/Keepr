<template>
	<div class="new-keep-button">
		<h6 v-if="!formVisible" @click="showForm()" class="btn btn-outline">New Keep</h6>
		<form v-if="formVisible" @submit.prevent="addKeep()" class="form-group">
			<div class="input-group">
				<div class="input-group-prepend">
					<button @click="showForm()" class="btn btn-outline no-margin">X</button>
					<span class="input-group-text">Private:</span>
					<div class="input-group-text">
						<input type="checkbox" name="keep-is-private" v-model="isPrivate" />
					</div>
				</div>
				<input type="text" class="form-control" placeholder="Keep Name" name="keep-name" v-model="name" />
				<input type="text" class="form-control" placeholder="Image URL" name="keep-img" v-model="img" />
				<input
					type="text"
					class="form-control"
					placeholder="Description"
					name="keep-description"
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
	name: "new-keep-button",
	data() {
		return {
			formVisible: false,
			name: "",
			img: "",
			description: "",
			isPrivate: false
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
		addKeep() {
			let keep = {
				name: this.name,
				img: this.img,
				description: this.description,
				isPrivate: this.isPrivate
			};
			this.$store.dispatch("addKeep", keep);
			this.keep = {};
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
.input-group-text {
	background: #201d19;
	border-color: #6b747c;
}
input {
	background: #201d19;
	border-color: #6b747c;
}
</style>