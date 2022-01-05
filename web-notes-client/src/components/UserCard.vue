<template>
  <tr>
    <th>
      {{ fullName }}
    </th>
    <td>{{ user.userName }}</td>
    <td>{{ user.email }}</td>
    <td>{{ user.role }}</td>
    <td>
      <button type="button" class="btn btn-danger" v-on:click="onDelete">
        Удалить
      </button>
      <button type="button" class="btn btn-primary" v-on:click="onReset">
        Сбросить пароль
      </button>
    </td>
  </tr>
</template>


<script>
export default {
  name: "UserCard",
  props: {
    user: Object,
  },
  emits: ["delete", "reset"],
  computed: {
    fullName() {
      return `${this.user.firstName} ${this.user.lastName}`;
    },
  },
  methods: {
    onDelete() {
      this.$emit("delete", this.user.id);
    },
    onReset() {
      this.$emit("reset", this.user.id);
    },
  },
};
</script>