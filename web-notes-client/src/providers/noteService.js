import api from "../providers/api.js";
import store from "../store/index.js";

export const createNote = (title, noteData, user, tags) => {
  return api.post("/Notes/CreateNote",  {
    title: title,
    noteDocument: noteData,
    createdDateTine: new Date(),
    userId: user.id,
    tags: tags,
  }, headers(user));
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
