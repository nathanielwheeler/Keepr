<template>
	<div class="dash-keeps">
		<new-keep-button />
		<div class="card-columns">
			<keep-card v-for="keep in userKeeps" :keepProp="keep" :key="keep.id" />
		</div>
	</div>
</template>


<script>
import NewKeepButton from "../components/NewKeepButton.vue";
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
	components: { KeepCard, NewKeepButton }
};
</script>


<style scoped>
</style>