<template>
    <div class="row p-0 m-0 h-100">
        <div class="col-md-3 bg-info">
            Test
        </div>
        <div class="col-md-9">
            <NoteForm/>
        </div>
    </div>
</template>

<script>
import NoteForm from "@/components/NoteForm.vue"
export default {
    name: "Notes",
    components:{
        NoteForm
    }

}
</script>