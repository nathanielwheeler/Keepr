<template>
	<div class="keep-card card">
		<h6 class="card-header text-left">
			<slot></slot>
		</h6>
		<img v-bind:src="url" class="card-img-top" />
	</div>
</template>


<script>
export default {
	name: "keep-card",
	data() {
		return {};
	},
	computed: {},
	methods: {},
	components: {}
};
</script>


<style scoped>
.card {
	background-color: #201d19;
	border-radius: 0;
	margin: 10px;
}
.card-img-top {
	border-radius: 0;
}
</style>