<template>
<form @submit.prevent="register">
  <h2>Register</h2>
  <div class="md-3">
    <label for="userName" class="form-label">First Name</label>
    <input class="form-control" type="text" id="userName" v-model="registerModel.firstName" />
  </div>
  <div class="md-3">
    <label for="userName" class="form-label">Last Name</label>
    <input class="form-control" type="text" id="userName" v-model="registerModel.lastName" />
  </div>
  <div class="md-3">
    <label for="userName" class="form-label">Email</label>
    <input class="form-control" type="email" id="userName" v-model="registerModel.email" />
  </div>
  <div class="md-3">
    <label for="userName" class="form-label">User Name</label>
    <input class="form-control" type="text" id="userName" v-model="registerModel.userName" />
  </div>

  <div class="md-3">
    <label for="password" class="form-label">Password</label>
    <input
      class="form-control"
      type="password"
      id="password"
      v-model="registerModel.password"
    />
  </div>
  <div class="md-3">
    <label for="comparePassword" class="form-label">Repeat Password</label>
    <input
      class="form-control"
      type="password"
      id="comparePassword"
      v-model="registerModel.comparePassword"
    />
  </div>

  <button class="btn btn-primary" type="submit">Register</button>

  <hr />
  <router-link to="/login">Login</router-link>
</form>
</template>

<script>
export default {
  name: "Register",
  data() {
    return {
      registerModel: {
        userName: "",
        comparePassword: "",
        password: "",
        firstName: "",
        lastName: "",
      },
    };
  },
  methods: {
    register() {
      this.$store.dispatch("Auth/register", this.registerModel);
    },
  },
};
</script>
