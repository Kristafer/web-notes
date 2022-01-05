<template>
  <div>
    <div class="div-center shadow p-3 bg-body rounded">
      <div class="content">
        <h3 class="text-center">Регистрация</h3>
        <hr />

        <form @submit.prevent="register">
          <div class="form-group pb-1">
            <label for="userName" class="form-label">Имя</label>
            <input
              class="form-control"
              type="text"
              id="userName"
              v-model="registerModel.firstName"
              required
            />
          </div>
          <div class="form-group pb-1">
            <label for="userName" class="form-label">Фамилия</label>
            <input
              class="form-control"
              type="text"
              id="userName"
              v-model="registerModel.lastName"
              required
            />
          </div>
          <div class="form-group pb-1">
            <label for="userName" class="form-label">Email</label>
            <input
              class="form-control"
              type="email"
              id="userName"
              v-model="registerModel.email"
              required
            />
          </div>
          <div class="form-group pb-1">
            <label for="userName" class="form-label">Имя пользователя</label>
            <input
              class="form-control"
              type="text"
              id="userName"
              v-model="registerModel.userName"
              required
            />
          </div>

          <div class="form-group pb-1">
            <label for="password" class="form-label">Пароль</label>
            <input
              class="form-control"
              type="password"
              id="password"
              v-model="registerModel.password"
              required
            />
          </div>
          <div class="form-group pb-1">
            <label for="comparePassword" class="form-label"
              >Повторить Пароль</label
            >
            <input
              class="form-control"
              type="password"
              id="comparePassword"
              v-model="registerModel.comparePassword"
              required
            />
          </div>
          <div class="text-center pt-2">
            <button class="btn btn-primary" type="submit">Регистрация</button>
          </div>
          <hr />
          <p>
            Если у вас есть аккаунт вы можете войти:
            <router-link to="/login">Вход</router-link>
          </p>
        </form>
      </div>
    </div>
  </div>
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
      this.$store.dispatch("Auth/register", this.registerModel).then(() => {
        this.$router.push("CreateNote");
      });
    },
  },
};
</script>
