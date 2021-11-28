<template>
  <div class="p-2">
    <div v-for="note in notes" :key="note.id">
    <ListCardNote :note="note"  @openNote="onOpenNote"></ListCardNote>
    </div>
  </div>
</template>

<script>
import ListCardNote from "@/components/ListCardNote.vue";
export default {
  name: "ListNotes",
  components: {
    ListCardNote,
  },
  props: {
    notes: Array,
  },
  emits: ["openNote"],
  methods:{
    onOpenNote(id){
      this.$emit("openNote", id);
    }
  }
};
</script>
