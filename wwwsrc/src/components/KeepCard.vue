<template>
	<div class="keep-card card">
		<h6 @click="showModal" class="card-header text-left">{{keepProp.name}}</h6>
		<img @click="showModal" :src="keepProp.img" class="card-img-top" />
		<p @click="showModal" class="card-footer d-flex justify-content-around">
			<span>Views: {{keepProp.views}}</span>
			<span>Shares: {{keepProp.shares}}</span>
			<span>Keeps: {{keepProp.keeps}}</span>
		</p>
		<keep-modal
			v-show="isModalVisible"
			@close="closeModal"
			:keepProp="keepProp"
			:header="keepProp.name"
			body
			footer="keepProp.description"
		/>
	</div>
</template>


<script>
import KeepModal from "./KeepModal.vue";

export default {
	name: "keep-card",
	data() {
		return {
			isModalVisible: false
		};
	},
	computed: {},
	props: ["keepProp"],
	methods: {
		showModal() {
			this.isModalVisible = true;
			this.logView();
		},
		closeModal() {
			this.isModalVisible = false;
		},
		logView() {
			this.$store.dispatch("logView", this.keepProp.id);
		}
	},
	components: { KeepModal }
};
</script>


<style scoped>
</style>