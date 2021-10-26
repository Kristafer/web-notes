<template>
  <template v-if="!isAuthorized">
    <NavBar />

    <router-view />
  </template>
  <template v-else>
     <NavBar />
    <div class="container-fluid">
      <div class="row flex-nowrap">
        <div class="col-md-3 py-3">
        <SideBar />
        </div>

        <div class="col py-3">
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
/* html,body, #app {
  height: 100%;
} */
/* #app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: #2c3e50;
}

#nav {
  padding: 30px;
}

#nav a {
  font-weight: bold;
  color: #2c3e50;
}

#nav a.router-link-exact-active {
  color: #42b983;
} */
</style>
