import { showToastrError, showToastrSuccess, showToastrWarning } from "../../util/toastr";
import UserApi from "../../api/UserApi";
import TimesheetApi from "../../api/TimesheetApi";
import * as toastrMessages from "../../constants/toastrConstants";
import update from 'immutability-helper';
import moment from "moment";

export default class TimesheetPageHelper {
    constructor(context) {
        this.context = context;
    }

    init() {
        //TODO use context for ajax counter https://www.youtube.com/watch?v=XLJN4JfniH4
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

                    const newTimesheet = this.transformDagen(response.data);

                    this.context.setState({
                        timesheet: newTimesheet,
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

    transformDagen(timesheet) {
        if (timesheet && timesheet.dagen && timesheet.dagen.length > 0) {
            this.dagTijd = timesheet.dagTijd;

            const dagen = timesheet.dagen.map((dag, index) => {
                return {
                    id: dag.id,
                    datum: dag.datum,
                    dagText: dag.dagText,
                    dagNr: dag.dagNr,
                    weekNr: dag.weekNr,
                    uren: dag.uren,
                    urenTijd: this.urenToTijd(dag.uren),
                    overuren: dag.overuren,
                    overurenTijd: this.urenToTijd(dag.overuren),
                    compensatie: this.calcCompensatie(dag.uren, dag.isWeekend || dag.isFeestdag),
                    wachtvergoeding: dag.wachtvergoeding,
                    opmerkingen: dag.opmerkingen,
                    isFeestdag: dag.isFeestdag,
                    isWeekend: dag.isWeekend,
                    verlof: dag.verlof
                }
            });

            timesheet.dagen = dagen;
        }

        return timesheet;
    }

    calcCompensatie(uren, weekendOrFeestdag) {
        if (weekendOrFeestdag) {
            return uren;
        } else if (this.dagTijd) {
            const comp = uren - this.dagTijd;
            return Number(Math.round(comp + "e2") + "e-2");;
        } else {
            return 0;
        }
    }

    beforeSaveCell(row, cellName, cellValue, callback, indexes) {
        const newRow = Object.assign({}, row);

        switch (cellName) {
            case "uren":
                {
                    newRow.uren = cellValue;

                    row.urenTijd = this.convertUren(cellValue);
                    row.compensatie = this.calcCompensatie(cellValue, row.isWeekend || row.isFeestdag);
                    break;
                }
            case "urenTijd":
                {
                    newRow.uren = this.convertTijd(cellValue);                    

                    row.uren = newRow.uren;
                    row.compensatie = this.calcCompensatie(uren, row.isWeekend || row.isFeestdag);
                    break;
                }
            case "overuren":
                {
                    newRow.overuren = cellValue;

                    row.overurenTijd = this.convertUren(cellValue);
                    break;
                }
            case "overurenTijd":
                {
                    newRow.overuren = this.convertTijd(cellValue);

                    row.overuren = newRow.overuren;
                    break;
                }
            default:
                break;
        }

        return this.updateTimesheetDag(this.context.state.selectedUser, newRow);
    }

    updateTimesheetDag(userId, row) {
        const dag = {
            id: row.id,
            userId: userId,
            datum: row.datum,
            uren: row.uren,
            overuren: row.overuren,
            wachtvergoeding: row.wachtvergoeding,
            opmerkingen: row.opmerkingen
        };

        TimesheetApi.update(dag)
            .then((response) => {
                if (response.status && response.status === 200) {
                    showToastrSuccess(toastrMessages.TIMESHEET_UPDATE_SUCCESS);
                    return true;
                } else {
                    showToastrError(toastrMessages.TIMESHEET_UPDATE_ERROR);
                    return false;
                }
            })
            .catch((error) => {
                showToastrError(toastrMessages.TIMESHEET_UPDATE_ERROR);
                return false;
            });
        return true;
    }

    convertUren(value) {
        return moment().startOf("day").add(value, "hours").format("HH:mm");
    }

    convertTijd(value) {
        return moment.duration(value).asHours();
    }

    urenToTijd(uren) {
        if (isNaN(uren)) return uren;
        return this.convertUren(uren);
    }

    handleError(error) {
        const loadCount = this.context.state.loadingCount;
        showToastrError(error);

        this.context.setState({
            loadingCount: loadCount - 1
        });

    }
}