import api from "../providers/api.js";

export const getUsers = (user) => {
  return api.get("/Users/GetAll", headers(user));
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
