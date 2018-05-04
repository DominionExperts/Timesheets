import { showToastrError, showToastrSuccess, showToastrWarning } from "../../util/toastr";
import UserApi from "../../api/UserApi";
import TimesheetApi from "../../api/TimesheetApi";
import * as toastrMessages from "../../constants/toastrConstants";
import update from 'immutability-helper';

export default class TimesheetPageHelper {
    constructor(context) {
        this.context = context;
    }

    init() {
        //TODO use redux for ajax counter
        this.context.setState({
            loadingCount: 1
        });


        UserApi.get()
            .then((response) => {
                if (response.status && response.status === 200) {
                    const loadCount = this.context.state.loadingCount;

                    this.context.setState({
                        users: response.data,
                        loadingCount: loadCount - 1
                    });
                } else {
                    this.handleError(toastrMessages.USER_ERROR);
                }
            })
            .catch((error) => {
                this.handleError(toastrMessages.USER_ERROR);
            });
    }

    changeUser(event) {
        if (!event.target.value) return;
        const userId = event.target.value;

        this.changeDropDown(userId, this.context.state.selectedMonth);
    }

    changeMonth(event) {
        if (!event.target.value) return;
        const month = event.target.value;

        this.changeDropDown(this.context.state.selectedUser, month);
    }

    changeDropDown(userId, month) {
        if (!userId && !month) return;
        if (!userId) {
            this.context.setState({
                selectedMonth: month,
            });
            return;
        } else if (!month) {
            this.context.setState({
                selectedUser: userId
            });
            return;
        }

        this.context.setState({
            loadingCount: this.context.state.loadingCount + 1
        });

        TimesheetApi.get(userId, month)
            .then((response) => {
                if (response.status && response.status === 200) {
                    const loadCount = this.context.state.loadingCount;

                    this.context.setState({
                        timesheet: response.data,
                        loadingCount: loadCount - 1,
                        selectedUser: userId,
                        selectedMonth: month
                    });
                } else {
                    this.handleError(toastrMessages.TIMESHEET_ERROR);
                }
            })
            .catch((error) => {
                this.handleError(toastrMessages.TIMESHEET_ERROR);
            });
    }


    handleError(error) {
        const loadCount = this.context.state.loadingCount;
        showToastrError(error);

        this.context.setState({
            loadingCount: loadCount - 1
        });

    }
}