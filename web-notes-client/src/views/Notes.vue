<template>
    <div class="row p-0 m-0">
        <div class="col-md-2 bg-">
            Test
        </div>
        <div class="col">
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