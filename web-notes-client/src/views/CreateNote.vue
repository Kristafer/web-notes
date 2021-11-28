<template>
  <div class="col-md-2 p-0 m-0 sidebar">
    <SideBar />
  </div>

  <div class="col-md-10 p-0 m-0">
    <div class="p-3">
      <NoteForm
        :isNew="isNew"
        @create="onCreate"
        @update="onUpdate"
        @delete="onDelete"
      />
    </div>
  </div>
</template>

<script>
import { getNote, deleteNote, updateNote,createNote } from "../providers/noteService.js";
import NoteForm from "@/components/NoteForm.vue";
import SideBar from "@/components/SideBar";
export default {
  name: "CreateNote",
  components: {
    NoteForm,
    SideBar,
  },
  data() {
    return {
      isNew: true,
    };
  },
  methods: {
    onCreate(note) {
      createNote(this.$store.state.Auth.user, note).then(({ data }) => {
        this.isNew = false;
        console.log(data);
      });
    },
    onUpdate(note) {
      updateNote(this.$store.state.Auth.user, note).then(({ data }) => {
        console.log(data);
      });
    },
    onDelete(id) {
      deleteNote(this.$store.state.Auth.user, id).then(() => {
        this.$router.push("Notes");
      });
    },
  },
};
</script>