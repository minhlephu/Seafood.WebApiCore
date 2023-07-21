import axios from "axios";
import UserModel from "../models/user.model";
import BaseAPI from "./BaseAPI";
import { Cookies } from "react-cookie";

interface SignUpModel {
  userName: string,
  password: string,
  email: string,
  displayName: string,
  mobile: string
}

class UserAPI extends BaseAPI<UserModel> {
  cookies = new Cookies();

  async signIn(username: string, password: string) {
    return axios
      .post(this.base_url + "/signin", {username, password})
      .then((res) => {
        this.cookies.set("token", res.data.token)
        if(res.data.token) {
          axios.defaults.headers.common['Authorization'] = `Bearer ${res.data.token}`;
        }
      });
  }

  signUp(signUpModel: SignUpModel) {
    return axios.post(this.base_url + "/signup", signUpModel);
  }
}

const userAPI = new UserAPI("users");
export default userAPI;
