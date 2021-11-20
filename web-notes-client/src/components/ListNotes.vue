<template>
  <div class="h-100 overflow-auto">
    <ListCardNote :note="note" :v-for="note in notes"></ListCardNote>
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
};
</script>