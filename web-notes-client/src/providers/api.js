import axios from "axios";

const apiProvider = axios.create({
    baseURL: "https://localhost:44325/api/",
    // params: {
    //   timestamp: new Date().getTime(),
    // },
  });
  
//   apiProvider.interceptors.response.use(
//     (response) => response,
//     (error) => {
//       let title = "Error";
//       let errorMessage = error.response.data?.message;
  
//       if (error.response.status === 403) {
//         title = "Access denied";
//         errorMessage = "You don't have the permissions to perform the action";
//       }
  
//       if (errorMessage) {
//         Store.commit("notifications/createNotification", {
//           title: title,
//           message: errorMessage,
//           notificationType: Store.getters["notifications/types"].error,
//         });
//       }
  
//       return Promise.reject(error);
//     }
//   );
  
  export default apiProvider;