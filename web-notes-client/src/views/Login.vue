<template>
  <form @submit.prevent="login">
    <h2>Login</h2>
    <div class="md-3">
      <label for="userName" class="form-label">User Name</label>
      <input
        class="form-control"
        type="text"
        id="userName"
        v-model="loginModel.userName"
      />
    </div>

    <div class="md-3">
      <label for="password" class="form-label">Password</label>
      <input
        class="form-control"
        type="password"
        id="password"
        v-model="loginModel.password"
      />
    </div>

    <button class="btn btn-primary" type="submit">Login</button>

    <hr />
    <router-link to="/register">Register</router-link>
  </form>
</template>

<script>
export default {
  name: "Login",
  data() {
    return {
      loginModel: {
        userName: "",
        password: "",
      },
    };
  },
  methods: {
    login() {
      this.$store.dispatch("Auth/login", this.loginModel);
    },
  },
};
</script>
