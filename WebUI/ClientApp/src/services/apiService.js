import axios from "axios";
import authService from "../components/api-authorization/AuthorizeService";

const apiService = axios.create();

// Add an interceptor to inject the token into the request headers
apiService.interceptors.request.use(
  async (config) => {
    const token = await authService.getAccessToken();
    if (token) {
      config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
  },
  (error) => {
    return Promise.reject(error);
  }
);

export default apiService;
