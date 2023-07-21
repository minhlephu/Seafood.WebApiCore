import axios from "axios";
import authHeader from "../commons/auth-header.common";


class BaseAPI<T> {
    protected base_url = "http://10.1.27.114:1239/api/";

    constructor(path: string){
        this.base_url += path;
    }

    getAll(){
        return axios.get(this.base_url, authHeader());
    }

    getById(id : string){
        return axios.get(this.base_url + "/" + id, authHeader());
    }

    create(model: T) {
        return axios.post(this.base_url, model, authHeader());
    };

    update(id: string, model: T){
        return axios.patch(this.base_url + "/" + id, model, authHeader());
    };

    delete(id: string){
        return axios.delete(this.base_url + "/" + id, authHeader());
    };
}

export default BaseAPI;