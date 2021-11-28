<template>
  <div class="card m-0 mb-1">
    <div class="card-body">
      <div class="row">
        <div class="col-md-6">
          <p class="p-0 m-0 fw-bold fs-4">
            {{ fullName }}
          </p>
          <p class="p-0 m-0 fs-6">Имя учетной записи: {{ user.userName }}</p>
          <p class="p-0 m-0 fs-6">Email: {{ user.email }}</p>
          <p class="p-0 m-0 fs-6">Роль: {{ user.role }}</p>
        </div>
        <div class="col-md-6 text-end">
          <div
            class="btn-group"
            role="group"
            aria-label="Basic mixed styles example"
          >
            <button type="button" class="btn btn-danger" v-on:click="onDelete">Удалить</button>
            <button type="button" class="btn btn-primary" v-on:click="onReset">
              Сбросить пароль
            </button>
          </div>
        </div>
      </div>
    </div>
  </div>
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