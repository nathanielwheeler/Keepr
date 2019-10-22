<template>
	<div class="dashboard">
		<h1>{{user.username}}'s Dashboard</h1>
		<div v-if="!isMobile()">
			<desktop-dash />
		</div>
		<div v-else>
			<mobile-dash />
		</div>
	</div>
</template>

<script>
import MobileDash from "../components/MobileDash.vue";
import DesktopDash from "../components/DesktopDash.vue";
export default {
	name: "dashboard",
	computed: {
		user() {
			return this.$store.state.user;
		}
	},
	// created() {
	// 	document.addEventListener("resize", this.isMobile());
	// },
	// destroyed() {
	// 	document.removeEventListener("resize", this.isMobile());
	// },
	methods: {
		isMobile(e) {
			if (
				/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(
					navigator.userAgent
				) // ||
				// window.innerWidth < 768
			) {
				return true;
			} else {
				return false;
			}
		}
	},
	components: {
		MobileDash,
		DesktopDash
	}
};
</script>