import api from "../providers/api.js";

export const createNote = (user, note) => {
  return api.post(
    "/Notes/CreateNote",
    {
      ...note,
      userId: user.id,
    },
    headers(user)
  );
};

export const updateNote = (user, note) => {
  return api.post(
    "/Notes/UpdateNote",
    {
      ...note,
      userId: user.id,
    },
    headers(user)
  );
};
export const deleteNote = (user, id) => {
  return api.delete(`/Notes/DeleteNote/${id}`, headers(user));
};

export const getNotes = (user, searchValue = "") => {
  return api.get(`/Notes/GetNotes?SearchValue=${searchValue}`, headers(user));
};

export const getNote = (id, user) => {
  return api.get(`/Notes/GetNote/${id}`, headers(user));
};

export const getNoteSharedId = (id, user) => {
  return api.get(`/Notes/GetNoteSharedId/${id}`, headers(user));
};

export const getNoteShared= (id, user) => {
  return api.get(`/Notes/GetNoteShared/${id}`, headers(user));
};

function headers(user) {
  const authHeader = user.token
    ? { Authorization: "Bearer " + user.token }
    : {};
  return {
    headers: {
      ...authHeader,
      "Content-Type": "application/json",
    },
  };
}
