<template>
  <div class="hello">
    <ckeditor
      :editor="editor"
      v-model="editorData"
      :config="editorConfig"
    ></ckeditor>
  </div>
</template>

<script>
import ClassicEditor from "@ckeditor/ckeditor5-build-classic";
export default {
  name: "Editor",
  data() {
    return {
      editor: ClassicEditor,
      editorData: "<p>Content of the editor.</p>",
      editorConfig: {
        height: 500,
        toolbar: {
          removeItems: [
            "uploadImage",
          ],
        },
      },
    };
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style>
.ck-editor__editable {
  height: 500px;
}
</style>
