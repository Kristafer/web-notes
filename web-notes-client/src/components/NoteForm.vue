<template>
  <h3 class="text-center">Заметка</h3>
  <hr />
  <form @submit.prevent="">
    <div class="form-group pb-1">
      <label for="title" class="form-label">Название</label>
      <input
        class="form-control"
        type="text"
        id="title"
        v-model="noteModel.title"
      />
    </div>
    <div class="pb-1">
      <label for="categories" class="form-label">Категории</label>
      <Multiselect
        id="categories"
        v-model="noteModel.categories"
        mode="tags"
        :closeOnSelect="false"
        :searchable="true"
        :createTag="true"
        :options="[
          { value: 'batman', label: 'Batman' },
          { value: 'robin', label: 'Robin' },
          { value: 'joker', label: 'Joker' },
        ]"
      />
    </div>
    <div class="form-group pb-1">
      <ckeditor
        :editor="editor"
        v-model="noteModel.noteDocument"
        :config="editorConfig"
      >
      </ckeditor>
    </div>
    <div class="pt-2 text-center">
      <button type="submit" class="btn btn-primary">Создать</button>
    </div>
    <hr />
  </form>
</template>

<script>
import ClassicEditor from "@ckeditor/ckeditor5-build-classic";
import Multiselect from "@vueform/multiselect";

export default {
  name: "NoteForm",
  props:{
    isNew: Boolean,
    noteId: Number 
  },
  components: {
    Multiselect,
  },
  data() {
    return {
      noteModel: {
        title: "",
        categories: [],
        noteDocument: "",
      },
      editor: ClassicEditor,
      editorData: "",
      editorConfig: {
        height: 500,
        toolbar: {
         removeItems: ["uploadImage"],
        },
      },
      options: ["Batman", "Robin", "Joker"],
    };
  },

  created() {
  },
};
</script>

<style>
.ck-editor__editable {
  height: 300px;
}
</style>
