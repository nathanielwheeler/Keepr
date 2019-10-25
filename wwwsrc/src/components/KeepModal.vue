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
				<button @click="logKeep()" type="button" class="btn btn-outline">Keep to Vault!</button>
			</footer>
		</div>
	</div>
</template>


<script>
export default {
	name: "modal",
	data() {
		return {
			shareLink: `https://localhost:8080/#/keeps/${keepProp.id}` //FIXME update once deployed
		};
	},
	computed: {},
	props: ["keepProp"],
	methods: {
		close() {
			this.$emit("close");
		},
		logShare() {
			this.$store.dispatch("logShare", this.keepProp.id);
		},
		logKeep() {
			this.$store.dispatch("logKeep", this.keepProp.id);
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
</style>