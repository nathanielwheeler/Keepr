<template>
	<div class="desktop-dash">
		(desktop-dash)
		<div class="card-columns">
			<keep-card
				v-for="keep in keeps"
				v-bind:name="keep.name"
				v-bind:img="keep.img"
				v-bind:key="keep.id"
			>What is love?</keep-card>
		</div>
	</div>
</template>


<script>
import KeepCard from "./KeepCard";
export default {
	name: "desktop-dash",
	data() {
		return {};
	},
	mounted() {
		this.$store.dispatch("getKeeps");
	},
	computed: {
		keeps() {
			return this.$store.state.keeps;
		}
	},
	props: [],
	methods: {},
	components: {
		KeepCard
	}
};
</script>


<style scoped>
</style>