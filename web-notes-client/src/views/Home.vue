<template>
  <div class="home">
    <p class="text-center fs-1 fw-bold">Web-notes</p>

    <p class="text-center fw-bold fs-3 mb-4">
      Web-notes - это веб-приложение, для создания и хранения заметок.
    </p>
    <div class="row shadow-none p-3 mb-5 bg-light rounded">
      <div class="col-8">
        <figure class="figure">
          <img
            src="../assets/ListNotes.png"
            class="figure-img img-fluid rounded"
            alt="..."
          />
        </figure>
      </div>
      <div class="col-4">
        <p>
          Позволяет просматривать созданные заметки. Поддерживает возможности:
        </p>
        <ul>
          <li>Создание списков</li>
          <li>Добавление медиа контента</li>
          <li>Форматирование текста</li>
        </ul>
      </div>
      <div class="col-4">
        <p>
          Позволяет создавать заметки. С использованием тегов для быстрого поиска. Поддерживает вставки кода.
        </p>
      </div>
      
      <div class="col-8">
        <figure class="figure">
          <img
            src="../assets/CreateNote.png"
            class="figure-img img-fluid rounded"
            alt="..."
          />
        </figure>
      </div>
    </div>
  </div>
</template>

<script>
// // @ is an alias to /src
//  import Editor from "@/components/Editor.vue";

export default {
  name: "Home",
  // components: {
  //   Editor,
  // },
};
</script>


<style>
html,
body,
#app {
  height: auto !important;
  overflow: auto !important;
}

::-webkit-scrollbar-track {
  -webkit-box-shadow: inset 0 0 6px rgba(0, 0, 0, 0.3);
  box-shadow: inset 0 0 6px rgba(0, 0, 0, 0.3);
  border-radius: 10px;
  background-color: #f5f5f5;
}

::-webkit-scrollbar {
  width: 12px;
  background-color: #f5f5f5;
}

::-webkit-scrollbar-thumb {
  border-radius: 10px;
  -webkit-box-shadow: inset 0 0 6px rgba(0, 0, 0, 0.3);
  box-shadow: inset 0 0 6px rgba(0, 0, 0, 0.3);
  background-color: #555;
}
.sidebar {
  background-color: #10b981;
  color: white;
}
</style>

