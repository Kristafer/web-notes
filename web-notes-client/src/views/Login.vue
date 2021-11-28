<template>
  <div>
    <div class="div-center shadow p-3 bg-body rounded">
      <div class="content">
        <h3 class="text-center">Вход</h3>
        <hr />
        <form @submit.prevent="login">
          <div class="form-group pb-1">
            <label for="userName" class="form-label">Имя Пользователя</label>
            <input
              class="form-control"
              type="text"
              id="userName"
              v-model="loginModel.userName"
              required
            />
          </div>
          <div class="form-group pb-1">
            <label for="password" class="form-label">Пароль</label>
            <input
              class="form-control"
              type="password"
              id="password"
              v-model="loginModel.password"
              required
            />
          </div>
          <div class="pt-2 text-center">
            <button type="submit" class="btn btn-primary">Вход</button>
          </div>
          <hr />

          <p>
            Если у вас нет аккаунта вы можете зарегистрироваться:
            <router-link to="/register">Регистрация</router-link>
          </p>
        </form>
      </div>
    </div>
  </div>
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
      this.$store.dispatch("Auth/login", this.loginModel).then(() => {
        debugger;
        this.$router.push("Notes");
      });
    },
  },
};
</script>

<style>
.div-center {
  width: 500px;
  height: 400px;
  background-color: #fff;
  position: absolute;
  left: 0;
  right: 0;
  top: 60px;
  bottom: 0;
  margin: auto;
  max-width: 100%;
  max-height: 100%;
  overflow: auto;
  padding: 1em 2em;
  border-bottom: 2px solid #ccc;
  display: table;
}

div.content {
  display: table-cell;
  vertical-align: middle;
}
</style>
