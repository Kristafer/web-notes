<template>
<div class="p-3">
    <NoteForm :isNew="true"/>
</div>
</template>

<script>
import NoteForm from "@/components/NoteForm.vue"
export default {
    name: "CreateNote",
    components:{
        NoteForm
    }

}
</script>