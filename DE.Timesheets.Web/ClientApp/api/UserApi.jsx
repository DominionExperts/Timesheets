import Axios, { AxiosRequestConfig, AxiosPromise } from "axios";

export default class UserApi {
    static get() {
        return Axios.get('api/user', {
            headers: {
                'accept': 'application/json'
            }
        });
    }
}