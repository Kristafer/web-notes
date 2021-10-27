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
      ></ckeditor>
    </div>
    <div class="pt-2 text-center">
      <button type="submit" class="btn btn-primary">Создать</button>
    </div>
    <hr />
  </form>
</template>

<script>
// import ClassicEditor from "@ckeditor/ckeditor5-editor-classic";
// import ClassicEditor from "@ckeditor/ckeditor5-build-classic";
import ClassicEditor from "@ckeditor/ckeditor5-build-classic/build/ckeditor.js";
import Multiselect from "@vueform/multiselect";

export default {
  name: "NoteForm",
  components: {
    Multiselect,
  },
  data() {
    return {
      noteModel: {
        title: "",
        categories: [],
        noteDocument: "<p>Content of the editor.</p>",
      },
      editor: ClassicEditor,
      editorData: "<p>Content of the editor.</p>",
      // editorConfig: {
      //   plugins: [
      //     EssentialsPlugin,
      //     BoldPlugin,
      //     ItalicPlugin,
      //     // LinkPlugin,
      //     ParagraphPlugin,
      //   ],

      //   toolbar: {
      //     items: ["bold", "italic",  "undo", "redo"],
      //   },
      // },
      editorConfig: {
        height: 500,
        toolbar: {
          items: ["todoList"],
          removeItems: ["uploadImage"],
        },
        // plugins: [TodoList]
        //   function (editor) {
        //     debugger;
        //     // Not recommended, but it works.
        //     editor.plugins
        //       .get("RestrictedEditingModeEditing")
        //       ._alwaysEnabled.add("todoListCheck");
        //     editor.plugins
        //       .get("RestrictedEditingModeEditing")
        //       ._allowedInException.add("todoListCheck");
        //     console.log(editor.plugins.get("RestrictedEditingModeEditing"));
        //   },
        // ],
      },
      options: ["Batman", "Robin", "Joker"],
    };
  },

  // created() {
  //   debugger;
  //   ClassicEditor.builtinPlugins.forEach((element) => {
  //     console.log(element.pluginName);
  //   });
  //   console.log(this.editor.plugins);
  //   // console.log(ClassicEditor.plugins.get( 'RestrictedEditingModeEditing' ).enableCommand('todoListCheck'));
  // },
};
</script>

<style>
.ck-editor__editable {
  height: 300px;
}
</style>
