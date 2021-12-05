import { createRouter, createWebHistory } from "vue-router";
import Home from "../views/Home.vue";
import Login from "../views/Login.vue";
import Register from "../views/Register.vue";
import Notes from "../views/Notes.vue";
import CreateNote from "../views/CreateNote.vue";
import Users from "../views/Users.vue";
import SharedNote from "../views/SharedNote.vue";
import Store from "../store/index.js";

const routes = [
  {
    path: "/",
    name: "Home",
    component: Home,
  },
  {
    path: "/login",
    name: "Login",
    component: Login,
  },
  {
    path: "/register",
    name: "Register",
    component: Register,
  },
  {
    path: "/notes",
    name: "Notes",
    component: Notes,
    meta: { requiresAuth: true },
  },
  {
    path: "/createnote",
    name: "CreateNote",
    component: CreateNote,
    meta: { requiresAuth: true },
  },
  {
    path: "/users",
    name: "Users",
    component: Users,
    meta: { requiresAuth: true },
  },
  {
    path: "/shared",
    name: "Shared",
    component: SharedNote,
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

router.beforeEach((to, from, next) => {
  if (to.meta.requiresAuth && !Store.getters["Auth/isAuthorized"])
    next({ name: "Login" });
  else next();
});

export default router;
