import axios from "axios";

const baseUrl = "http://localhost:5291/api";

export function getUser(id) {
  return axios.get(`${baseUrl}/users/${id}`).then((res) => res.data);
}
