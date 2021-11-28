<template>
  <div class="card m-0 mb-1" :class="{ 'current-note': isCurrent}" v-on:click="cardClick">
    <div class="card-body">
        <p class="p-0 m-0 fw-bold fs-5">
        {{ note.title }}
      </p>
      <p class="p-0 m-0 fs-6">Теги: {{ categories }}</p>
      <p class="p-0 m-0 fs-6">Дата: {{ date }}</p>
    </div>
  </div>
</template>

<script>
export default {
  name: "ListCardNote",
  props: {
    note: Object,
  },
  emits: ["openNote"],
  computed: {
    categories() {
      return this.note.noteTags.join();
    },
    date() {
      let date = new Date(this.note.createdDateTime);
      return date.toLocaleDateString("en-US");
    },
    isCurrent(){
        return this.note.isCurrent;
    }
  },
  methods:{
      cardClick(){
          this.$emit("openNote", this.note.id);
      }
  }
};
</script>

<style scoped>
.current-note{
    background-color: #10b981;
    color: white;
}
.card:hover{
    border: solid 1px green;
}
</style>