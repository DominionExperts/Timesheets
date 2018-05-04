import Axios, { AxiosRequestConfig, AxiosPromise } from "axios";

export default class TimesheetApi {
    static get(userId, month) {
        return Axios.get("api/timesheet/" + userId + "/month/" + month, {
            headers: {
                'accept': "application/json"
            }
        });
    }
    static update(userId, timesheetdag) {
        return Axios.put("api/timesheet/" + userId, timesheetdag);
    }
}