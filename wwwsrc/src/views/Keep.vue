<template>
	<div class="keep">
		<header class="header">
			<h1>{{keep.name}}</h1>
		</header>
		<section class="body">
			<img class="container-fluid keep-image" :src="keep.img" />
			<br />
			<br />
			<p class="text-left container">{{keep.description}}</p>
		</section>
		<footer class="footer"></footer>
	</div>
</template>


<script>
export default {
	name: "keep",
	data() {
		return {};
	},
	mounted() {
		let keepId = this.$route.params.keepId;
		this.$store.dispatch("getKeepById", keepId);
	},
	computed: {
		keep() {
			return this.$store.state.selectedKeep;
		}
	},
	props: ["keepId"],
	methods: {},
	components: {}
};
</script>


<style scoped>
.keep {
	display: flex;
	flex-direction: column;
	justify-content: center;
	align-items: center;
}
.header,
.footer {
	padding: 15px;
}
.header {
	border-bottom: 1px solid #be862c;
	color: #f9d094;
	justify-content: space-between;
}
.footer {
	border-top: 1px solid #be862c;
	justify-content: space-around;
}
.body {
	padding: 20px 10px;
}
.image {
	max-height: 60vh;
	width: auto;
}
</style>