import { createStore } from "vuex";
import AuthStoreModule from "../store/auth.js";

export default createStore({
  // state: {},
  // mutations: {},
  // actions: {},
  modules: {
    Auth: AuthStoreModule
  },
});
