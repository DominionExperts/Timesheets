import Axios, { AxiosRequestConfig, AxiosPromise } from "axios";

export default class TimesheetApi {
    static get(userId, month) {
        return Axios.get("api/timesheet/" + userId + "/month/" + month, {
            headers: {
                'accept': "application/json"
            }
        });
    }
    static update(timesheetdag) {
        return Axios.put("api/timesheet", timesheetdag,
            {
                headers: {
                    'accept': "application/json"
                }
            });
    }
}