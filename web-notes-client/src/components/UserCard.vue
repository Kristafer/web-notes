<template>
  <tr>
    <th>
      {{ fullName }}
    </th>
    <td>{{ user.userName }}</td>
    <td>{{ user.email }}</td>
    <td>{{ user.role }}</td>
    <td>
      <!-- <div
        class="btn-group"
        role="group"
        aria-label="Basic mixed styles example"
      > -->
      <button type="button" class="btn btn-danger" v-on:click="onDelete">
        Удалить
      </button>
      <button type="button" class="btn btn-primary" v-on:click="onReset">
        Сбросить пароль
      </button>
      <!-- </div> -->
    </td>
  </tr>
  <!-- <div class="card m-0 mb-1">
    <div class="card-body">
      <div class="row">
        <div class="col-md-6">
          <p class="p-0 m-0 fw-bold fs-4">
          </p>
          <p class="p-0 m-0 fs-6">Имя учетной записи: </p>
          <p class="p-0 m-0 fs-6">Email: </p>
          <p class="p-0 m-0 fs-6">Роль: </p>
        </div>
        <div class="col-md-6 text-end">
          
        </div>
      </div>
    </div>
  </div> -->
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
      this.$emit("delete", user.id);
    },
    onReset() {
      this.$emit("reset", user.id);
    },
  },
};
</script>