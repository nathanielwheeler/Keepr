<template>
	<div class="keep-card card">
		<h6 class="card-header text-left">{{keepProp.name}}</h6>
		<img :src="keepProp.img" class="card-img-top" />
	</div>
</template>


<script>
export default {
	name: "keep-card",
	data() {
		return {
			name: "",
			img: ""
		};
	},
	computed: {},
	props: ["keepProp"],
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