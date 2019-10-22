<template>
	<div class="keep-card card">
		<div class="card-header text-left">Title</div>
		<img src="https://place-hold.it/200x200" class="card-img-top" />
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