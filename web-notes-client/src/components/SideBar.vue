<template>
  <div class="h-100 me-2 sidebar pt-2">
    <ul class="nav nav-pills flex-column mb-auto">
      <li class="nav-item">
        <router-link class="nav-link text-white" :class="{'fw-bold': $route.name === 'CreateNote'}" to="/CreateNote"
          ><i class="bi bi-file-earmark-plus"></i> Создать заметку</router-link
        >
      </li>
      <li class="nav-item">
        <router-link class="nav-link text-white" :class="{'fw-bold': $route.name === 'Notes'}" to="/Notes"
          ><i class="bi bi-file-earmark-text"></i> Заметки</router-link
        >
      </li>
      <li class="nav-item">
        <router-link class="nav-link text-white" :class="{'fw-bold': $route.name === 'ImportantNotes'}" to="/ImportantNotes"
          ><i class="bi bi-bookmark-check"></i> Важные заметки</router-link
        >
      </li>
    </ul>
  </div>
</template>
