<template>
  <div class="input-group p-2">
    <input
      class="form-control"
      type="text"
      id="title"
      v-model="search"
      placeholder="Поиск"
    />
    <div class="input-group-append">
      <button class="btn btn-secondary" v-on:click="onSearch">
        <i class="bi bi-search"></i>
      </button>
    </div>
  </div>
</template>

<script>
export default {
  name: "SearchNotes",
  emits: ["search"],
  data() {
    return {
      search: "",
    };
  },
  methods: {
    onSearch() {
      this.$emit("search", this.search);
    },
  },
};
</script>