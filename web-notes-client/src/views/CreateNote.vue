<template>
  <div class="p-3">
    <NoteForm :isNew="isNew" @create="onCreate" />
  </div>
</template>

<script>
import { createNote } from "../providers/noteService.js";
import NoteForm from "@/components/NoteForm.vue";
export default {
  name: "CreateNote",
  components: {
    NoteForm,
  },
  data() {
    return {
      isNew: false,
    };
  },
  methods: {
    onCreate(note) {
      debugger;
      createNote(
        note.title,
        note.noteDocument,
        this.$store.state.Auth.user,
        note.noteTags
      ).then(({ data }) => {
        isNew = true;
        console.log(data);
      });
    },
  },
};
</script>