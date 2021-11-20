<template>
  <div class="form-group pb-2">
    <!-- <label for="title" class="form-label">Название</label> -->
    <input
      class="form-control"
      type="text"
      id="title"
      v-model="noteModel.title"
      placeholder="Название"
    />
  </div>
  <div class="form-group pb-2">
    <Multiselect
      id="noteTags"
      v-model="noteModel.noteTags"
      mode="tags"
      placeholder="Категории"
      :closeOnSelect="false"
      :searchable="true"
      :createTag="true"
      :options="[
        { value: 'кино', label: 'кино' },
        { value: 'музыка', label: 'музыка' },
        { value: 'работа', label: 'работа' },
      ]"
    />
  </div>
  <div class="form-group pb-1">
    <div id="editor">{{noteModel.noteDocument}}</div>
  </div>

  <div class="d-md-flex justify-content-md-end py-2">
    <template v-if="isNew">
      <button class="btn btn-primary" v-on:click="onCreateNote()">
        Создать
      </button>
    </template>
    <template v-else>
      <button class="btn btn-danger me-md-2">Удалить</button>
      <button class="btn btn-primary">Обновить</button>
    </template>
  </div>
</template>

<script>
import Multiselect from "@vueform/multiselect";
import { createNote } from "../providers/noteService.js";

export default {
  name: "NoteForm",
  props: {
    isNew: Boolean,
    note: Object,
  },
  emits: ["create"],
  components: {
    Multiselect,
  },
  data() {
    return {
      editor: null,
      noteModel: {
        title: "",
        noteTags: [],
        noteDocument: ""
      },
      options: ["Batman", "Robin", "Joker"],
    };
  },

  created(){
    if(this.note){
    this.noteModel = {...this.note};
    }
  },

  mounted() {
    ClassicEditor.create(document.querySelector("#editor"), {
      licenseKey: "",
    })
      .then((editor) => {
        window.editor = editor;
      })
      .catch((error) => {
        console.error("Oops, something went wrong!");
        console.error(
          "Please, report the following error on https://github.com/ckeditor/ckeditor5/issues with the build id and the error stack trace:"
        );
        console.warn("Build id: qrazqcvdbgrw-9tyw1m90kmcf");
        console.error(error);
      });
  },

  methods: {
    onCreateNote() {
      this.$emit("create", {
        title: this.noteModel.title,
        noteTags: this.noteModel.noteTags,
        noteDocument:  window.editor.getData()
      });
    },
  },
};
</script>

<style>
.ck-editor__editable {
  height: 440px;
}
</style>
