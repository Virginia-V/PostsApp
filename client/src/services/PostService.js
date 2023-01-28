import axios from "axios";

const baseUrl = "http://localhost:5291/api";

export function getPosts() {
  return axios
    .get(`${baseUrl}/posts`, { params: { _sort: "title" } })
    .then((res) => {
      return res.data;
    });
}

export function getPostsPaginated(page) {
  return axios
    .get("http://localhost:3000/posts", {
      params: { _page: page, _sort: "title", _limit: 2 }, // ! The pagination should be set on the server side as well
      // ! It does not work, I see all the posts instead of 2
    })
    .then((res) => {
      const hasNext = page * 2 <= parseInt(res.headers["x-total-count"]);
      return {
        nextPage: hasNext ? page + 1 : undefined,
        previousPage: page > 1 ? page - 1 : undefined,
        posts: res.data,
      };
    });
}

export function getPost(id) {
  return axios.get(`${baseUrl}/posts/${id}`).then((res) => res.data);
}

export function createPost({ title, body }) {
  return axios
    .post(`${baseUrl}/posts`, {
      title,
      body,
      userId: 1,
      id: Date.now(),
    })
    .then((res) => res.data);
}
