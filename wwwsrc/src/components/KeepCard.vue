<template>
	<div @click="showModal()" class="keep-card card">
		<h6 class="card-header text-left">{{keepProp.name}}</h6>
		<img :src="keepProp.img" class="card-img-top" />
		<p class="card-footer d-flex justify-content-around">
			<span>Views: {{keepProp.views}}</span>
			<span>Shares: {{keepProp.shares}}</span>
			<span>Keeps: {{keepProp.keeps}}</span>
		</p>
		<modal v-show="isModalVisible" @close="closeModal()" />
	</div>
</template>


<script>
import Modal from "./Modal.vue";

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
		},
		closeModal() {
			this.isModalVisible = false;
		}
	},
	components: { Modal }
};
</script>


<style scoped>
</style>