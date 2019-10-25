<template>
	<div class="modal-backdrop">
		<div class="modal" role="dialog">
			<header class="modal-header">
				<slot name="header">Header</slot>
				<button @click="close()" type="button" class="btn btn-outline">X</button>
			</header>
			<section class="modal-body">
				<slot name="body">Body</slot>
			</section>
			<footer class="modal-footer">
				<slot name="footer">
					Footer
					<button @click="close()" type="button" class="btn btn-outline"></button>
					<button @click="close()" type="button" class="btn btn-outline"></button>
					<button @click="close()" type="button" class="btn btn-outline"></button>
				</slot>
			</footer>
		</div>
	</div>
</template>


<script>
export default {
	name: "modal",
	data() {
		return {};
	},
	computed: {},
	methods: {
		close() {
			this.$emit("close");
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
</style>