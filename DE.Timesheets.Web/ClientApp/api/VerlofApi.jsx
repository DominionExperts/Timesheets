import Axios, { AxiosRequestConfig, AxiosPromise } from "axios";

export default class VerlofApi {
    static get(userId) {
        return Axios.get('api/verlof/' + userId, {
            headers: {
                'accept': 'application/json'
            }
        });
    }

    static request(verlof, userId) {
        return Axios.post('api/verlof/' + userId, verlof);
    }

    static update(verlof, userId) {
        return Axios.put('api/verlof/' + userId, verlof);
    }
}