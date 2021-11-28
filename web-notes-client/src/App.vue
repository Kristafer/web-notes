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
        <router-view />
      </div>
    </div>
  </template>
</template>

<script>
import { mapGetters } from "vuex";
import NavBar from "@/components/NavBar";

export default {
  name: "App",
  components: {
    NavBar,
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
  overflow: hidden;
}

::-webkit-scrollbar-track {
  -webkit-box-shadow: inset 0 0 6px rgba(0, 0, 0, 0.3);
  box-shadow: inset 0 0 6px rgba(0, 0, 0, 0.3);
  border-radius: 10px;
  background-color: #f5f5f5;
}

::-webkit-scrollbar {
  width: 12px;
  background-color: #f5f5f5;
}

::-webkit-scrollbar-thumb {
  border-radius: 10px;
  -webkit-box-shadow: inset 0 0 6px rgba(0, 0, 0, 0.3);
  box-shadow: inset 0 0 6px rgba(0, 0, 0, 0.3);
  background-color: #555;
}
.sidebar {
  background-color: #10b981;
  color: white;
}
</style>
