<template>
    
<div>
<h3>{{note.title}}</h3>
<p>Дата: {{note.createdDateTime}}</p>
<p>Теги: {{note.createdDateTime}}</p>
</div>
</template>

<script>
export default {
    name: "ListCardNote",
    props:{
        note: Object
    },
    computed:{
        categories(){
            return this.note.noteTags.join();
        }
    }
}
</script>