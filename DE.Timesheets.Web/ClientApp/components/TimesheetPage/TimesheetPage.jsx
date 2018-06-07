import React from 'react';
import BootstrapTable from 'react-bootstrap-table-next';

import AutobindComponent from "../AutobindComponent";
import Dropdown from "../common/Dropdown";
import Loader from "../common/Loader"

import TimesheetPageHelper from "./TimesheetPageHelper";
import TimesheetForm from "./TimesheetForm";

class TimesheetPage extends AutobindComponent {
    constructor(props) {
        super(props);

        this.state = {
            users: [],
            maanden: [],
            timesheet: {
                userId: null,
                maand: null,
                maandText: null,
                jaar: null,
                dagen: []
            },
            loadingCount: 0,
            selectedUser: "",
            selectedMonth: "",
        };

        this.pageHelper = new TimesheetPageHelper(this);
    }

    componentWillMount() {
        this.pageHelper.init();
    }

    handleOnChangeUser(event) {
        this.pageHelper.changeUser(event);
    }

    handleOnChangeMonth(event) {
        this.pageHelper.changeMonth(event);
    }

    handleOnBeforeSaveCell(row, cellName, cellValue, callback, indexes) {
        this.pageHelper.beforeSaveCell(row, cellName, cellValue, callback, indexes);
    }

    render() {
        const userItems = this.state.users.map((user, index) => {
            return {
                value: user.id,
                label: user.naam
            };
        });

        const maandenItems = [
            { value: 1, label: "januari" },
            { value: 2, label: "februari" },
            { value: 3, label: "maart" },
            { value: 4, label: "april" },
            { value: 5, label: "mei" },
            { value: 6, label: "juni" },
            { value: 7, label: "juli" },
            { value: 8, label: "augustus" },
            { value: 9, label: "september" },
            { value: 10, label: "oktober" },
            { value: 11, label: "november" },
            { value: 12, label: "december" }];

        const userDropdownProps = {
            value: this.state.selectedUser,
            defaultItem: "Kies een optie",
            name: "users",
            items: userItems,
            onChange: this.handleOnChangeUser,
            size: 3
        };

        const maandDropdownProps = {
            value: this.state.selectedMonth,
            defaultItem: "Kies een optie",
            name: "maand",
            items: maandenItems,
            onChange: this.handleOnChangeMonth,
            size: 3
        };

        const timesheetProps = {
            timesheet: this.state.timesheet,
            beforeSaveCell: this.handleOnBeforeSaveCell
        };

        const page = this.state.loadingCount === 0 ?
            <div>
                <div className="row">
                    <Dropdown {...userDropdownProps} />
                    <Dropdown {...maandDropdownProps} />
                </div>
                <br />
                <div className="row">
                    <TimesheetForm {...timesheetProps} />
                </div>
            </div> : <Loader />;

        return <div>
            <h1>Timesheet</h1>
            {page}
        </div>;
    }
}

export default TimesheetPage;