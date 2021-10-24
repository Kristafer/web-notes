<template>
  <div id="nav">
    <router-link to="/">Home</router-link> |
    <router-link to="/about">About</router-link>|
    <div v-if="isAuthorized">
      <router-link to="/logout">Logout</router-link>|
    </div>
    <div v-else>
      <router-link to="/login">Login</router-link>|

      <router-link to="/register">Register</router-link>
    </div>
  </div>
</template>

<script>
import { mapGetters } from "vuex";
export default {
  name: "NavBar",
  computed: {
    ...mapGetters("Auth", ["isAuthorized"]),
  },
};
</script>

<style></style>
