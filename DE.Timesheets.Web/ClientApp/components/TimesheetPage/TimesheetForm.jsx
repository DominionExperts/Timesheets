import React from "react";
import PropTypes from "prop-types";
import BootstrapTable from "react-bootstrap-table-next";

const TimesheetForm = (props) => {
    const columns = [
        {
            dataField: "id",
            text: "Id",
            hidden: true
        }, {
            dataField: "datum",
            text: "Datum",
            hidden: true
        }, {
            dataField: "isFeestdag",
            text: "Feestdag",
            hidden: true
        }, {
            dataField: "isWeekend",
            text: "Weekend",
            hidden: true
        }, {
            dataField: "weekNr",
            text: "WeekNr"
        }, {
            dataField: "dagText",
            text: "Dag"
        }, {
            dataField: "uren",
            text: "Uren"
        }, {
            dataField: "overuren",
            text: "Overuren"
        }, {
            dataField: "verlof",
            text: "Verlof"
        }, {
            dataField: "wachtvergoeding",
            text: "Wachtvergoeding"
        }, {
            dataField: "opmerkingen",
            text: "Opmerkingen"
        }];

    const rowStyle = (row, rowIndex) => {
        let color = "";

        if (row.isFeestdag) {
            color = "LightSalmon";
        } else if (row.isWeekend) {
            color = "LightGrey";
        };       

        return { backgroundColor: color };
    };

    const tableProps = {
        keyField: "id",
        data: props.timesheet.dagen,
        columns: columns,
        rowStyle: rowStyle
    }

    return (
        <div className="col-md-12">
            <h2>{props.timesheet.maandText}</h2>
            <BootstrapTable {...tableProps} />
        </div>
    );
};

TimesheetForm.propTypes = {
    timesheet: PropTypes.array.isRequired
};

export default TimesheetForm;