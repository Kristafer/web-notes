import api from "../providers/api.js";

export default {
  namespaced: true,
  state: {
    user: {},
  },
  getters: {
    isAuthorized: (state) => {
      return !!state.user.token;
    },
  },
  mutations: {
    setUser(state, user) {
      state.user = user;
    },
  },
  actions: {
    checkAuth(context) {
      context.commit("setUser", JSON.parse(localStorage.getItem("auth")) || {});
    },
    login(context, loginData) {
      return api.post("/Users/Authenticate", loginData).then(({ data }) => {
        console.log(data);
        context.commit("setUser", data);
        localStorage.setItem("auth", JSON.stringify(data));
      });
    },
    register(context, registerData) {
      return api.post("/Users/Register", registerData).then(({ data }) => {
        console.log(data);
        context.commit("setUser", data);
        localStorage.setItem("auth", JSON.stringify(data));
      });
    },
    logout(context) {
      context.commit("setUser", {});
      localStorage.setItem("auth", JSON.stringify({}));
    },
  },
};
