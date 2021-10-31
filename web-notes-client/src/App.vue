<template>
  <template v-if="!isAuthorized">
    <NavBar />

    <router-view />
  </template>
  <template v-else>
    <div class="container-fluid p-0 m-0 min-vh-100 d-flex flex-column">
      <div class="row p-0 m-0">
        <div class="col p-0 m-0">
          <NavBar />
        </div>
      </div>
      <div class="row flex-grow-1 p-0 m-0">
        <div class="col-md-2  p-0 m-0 bg-warning">
          <SideBar />
        </div>

        <div class="col p-0 m-0">
          <router-view />
        </div>
      </div>
    </div>
  </template>
</template>

<script>
import { mapGetters } from "vuex";
import NavBar from "@/components/NavBar";
import SideBar from "@/components/SideBar";

export default {
  name: "App",
  components: {
    NavBar,
    SideBar,
  },
  created() {
    this.$store.dispatch("Auth/checkAuth");
  },
  computed: {
    ...mapGetters("Auth", ["isAuthorized"]),
  },
};
</script>

<style>
html,
body,
#app {
  height: 100%;
}
</style>
