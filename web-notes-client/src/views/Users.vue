<template>
  <div class="users-container container-fluid">
    <p class="fs-1 fw-bold text-center">Пользователи</p>
    <table class="table">
      <thead>
        <tr>
          <th scope="col">Имя</th>
          <th scope="col">Имя учетной записи</th>
          <th scope="col">Email</th>
          <th scope="col">Роль</th>
          <th scope="col"></th>
        </tr>
      </thead>
      <tbody>
        <UserCard
          v-for="user in users"
          :key="user.id"
          :user="user"
          @delete="onDelete"
          @reset="onReset"
        />
      </tbody>
    </table>
    <!-- <div v-for="user in users" :key="user.id">
      <UserCard :user="user" @delete="onDelete" @reset="onReset" />
    </div> -->
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
    onDelete(id) {},
    onReset(id) {},
  },
};
</script>