import { createStore } from "vuex";
import AuthStoreModule from "../store/auth.js";

export default createStore({
  modules: {
    Auth: AuthStoreModule
  },
});
