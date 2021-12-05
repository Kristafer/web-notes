<template>
  <div class="p-4">
      <p class="text-center fw-bold fs-4">Заметка</p>
    <div class="form-group pt-3 pb-2">
      <input
        class="form-control"
        type="text"
        id="title"
        v-model="note.title"
        placeholder="Название"
      />
    </div>
    <div class="form-group pb-2">
      <Multiselect
        id="noteTags"
        v-model="note.noteTags"
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
      <div id="editor">{{ note.noteDocument }}</div>
    </div>
  </div>
</template>

<script>
import { getNoteShared } from "../providers/noteService.js";
import Multiselect from "@vueform/multiselect";
export default {
  name: "SharedNote",
  components: {
    Multiselect,
  },
  data() {
    return {
      isNew: true,
      note: {},
    };
  },
  mounted() {
    ClassicEditor.create(document.querySelector("#editor"), {
      licenseKey: "",
    })
      .then((editor) => {
        window.editor = editor;
        editor.isReadOnly = true;
        debugger;
        getNoteShared(this.$route.query.id, this.$store.state.Auth.user).then(
          ({ data }) => {
            this.note = { ...data };
            window.editor.setData(this.note.noteDocument);
          }
        );
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
};
</script>