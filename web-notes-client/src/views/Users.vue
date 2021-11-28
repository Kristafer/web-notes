<template>
  <div class="users-container container-fluid">
    <p class="fs-1 fw-bold text-center">Пользователи</p>
    <div v-for="user in users" :key="user.id">
      <UserCard :user="user" @delete="onDelete" @reset="onReset" />
    </div>
  </div>
</template>

<script>
import UserCard from "@/components/UserCard.vue";
import { getUsers } from "../providers/userService.js";
export default {
  name: "Users",
  components: {
    UserCard,
  },
  data() {
    return {
      users: [],
    };
  },
  created() {
    getUsers(this.$store.state.Auth.user).then(({ data }) => {
      this.users = data;
    });
  },
  methods: {
    onDelete(id) {
      this.$emit("delete", user.id);
    },
    onReset(id) {
      this.$emit("reset", user.id);
    },
  },
};
</script>