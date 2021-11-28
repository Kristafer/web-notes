import axios from "axios";

const apiProvider = axios.create({
  baseURL: "https://localhost:44325/api/",
});

apiProvider.interceptors.response.use(
  (response) => response,
  (error) => {
    let title = "Error";
    let errorMessage = error.response.data.message;

    if (errorMessage) {
      alert("Error message: " + errorMessage);
    }

    return Promise.reject(error);
  }
);

export default apiProvider;
