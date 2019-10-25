<template>
	<div class="dash-keeps card-columns">
		<keep-card v-for="keep in userKeeps" :keepProp="keep" :key="keep.id" />
	</div>
</template>


<script>
import KeepCard from "../components/KeepCard.vue";
export default {
	name: "dash-keeps",
	data() {
		return {};
	},
	mounted() {
		this.$store.dispatch("getUserKeeps");
	},
	computed: {
		userKeeps() {
			return this.$store.state.userKeeps;
		}
	},
	methods: {},
	components: { KeepCard }
};
</script>


<style scoped>
</style>