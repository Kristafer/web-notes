<template>
  <div class="col-md-2 p-0 m-0 sidebar">
    <SideBar />
  </div>

  <div class="col-md-10 p-0 m-0">
    <div class="row p-0 m-0 h-100">
      <div class="col-md-3 list-container">
        <p class="fw-bold fs-4 text-center">Заметки</p>
        <SearchNotes @search="onSearch" />
        <div class="overflow-auto list-notes">
          <ListNotes :notes="notes" @openNote="onOpenNote" />
        </div>
      </div>
      <div class="col-md-9">
        <NoteForm
          :isNew="isNew"
          :note="note"
          @update="onUpdate"
          @delete="onDelete"
        />
      </div>
    </div>
  </div>
</template>

<script>
import NoteForm from "@/components/NoteForm.vue";
import ListNotes from "@/components/ListNotes.vue";

import SideBar from "@/components/SideBar";
import SearchNotes from "@/components/SearchNotes.vue";
import { getNotes, deleteNote, updateNote } from "../providers/noteService.js";

export default {
  name: "Notes",
  components: {
    NoteForm,
    ListNotes,
    SearchNotes,
    SideBar,
  },
  data() {
    return {
      notes: [],
      note: null,
      isNew: false,
      searchValue: "",
    };
  },
  created() {
    getNotes(this.$store.state.Auth.user, this.searchValue).then(({ data }) => {
      this.notes = data;
      this.note = data[0];
      this.note.isCurrent = true;
    });
  },
  methods: {
    onOpenNote(id) {
      this.note.isCurrent = false;
      this.note = this.notes.find((x) => {
        return x.id === id;
      });

      this.note.isCurrent = true;
    },

    onSearch(searchValue) {
      this.searchValue = searchValue;
      this.updateListNotes();
    },
    onUpdate(note) {
      updateNote(this.$store.state.Auth.user, note).then(({ data }) => {
        console.log(data);

        this.updateListNotes().then(() => {
          this.onOpenNote(note.id);
        });
      });
    },
    onDelete(id) {
      deleteNote(this.$store.state.Auth.user, id).then(() => {
        getNotes(this.$store.state.Auth.user, this.searchValue).then(
          ({ data }) => {
            this.notes = data;
            this.note.isCurrent = false;
            this.note = data[0];
            this.note.isCurrent = true;
          }
        );
      });
    },
    updateListNotes() {
      return getNotes(this.$store.state.Auth.user, this.searchValue).then(
        ({ data }) => {
          this.notes = data;
          return data;
        }
      );
    },
  },
};
</script>

<style scoped>
.list-container {
  background-color: rgb(223, 223, 223);
  height: 92vh;
  padding-right: 0px;
}
.list-notes {
  height: 77vh;
}
</style>