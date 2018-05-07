import React from "react";
import PropTypes from "prop-types";
import { BootstrapTable, TableHeaderColumn } from "react-bootstrap-table";

/*
var ReactBsTable  = require('react-bootstrap-table');
var BootstrapTable = ReactBsTable.BootstrapTable;
var TableHeaderColumn = ReactBsTable.TableHeaderColumn;
 */

const TimesheetForm = (props) => {
    const rowStyleClass = (row, rowIndex) => {
        if (row.isFeestdag) {
            return "timesheet-feestdag";
        } else if (row.isWeekend) {
            return "timesheet-weekend";
        };
    };

    const tableProps = {
        keyField: "id",
        data: props.timesheet.dagen,
        trClassName: rowStyleClass
    }

    const border = {
        borderRight: "2px solid"
    };
    //tdStyle={{ whiteSpace: 'normal' }} 

    const table = props.timesheet.dagen.length > 0
        ? <BootstrapTable {...tableProps}>
            <TableHeaderColumn dataField="id" row="0" rowSpan="2" hidden>Id</TableHeaderColumn>
            <TableHeaderColumn dataField="isFeestdag" row="0" rowSpan="2" hidden>Feestdag</TableHeaderColumn>
            <TableHeaderColumn dataField="isWeekend" row="0" rowSpan="2" hidden>Weekend</TableHeaderColumn>
            <TableHeaderColumn dataField="weekNr" row="0" rowSpan="2" width="60px" headerAlign="center">Week</TableHeaderColumn>
            <TableHeaderColumn row="0" colSpan="2" dataSort csvHeader="Dag" headerAlign="center">Dag</TableHeaderColumn>
            <TableHeaderColumn dataField="dagText" row="1" width="50px" headerAlign="center"></TableHeaderColumn>
            <TableHeaderColumn dataField="dagNr" row="1" width="50px" headerAlign="center"></TableHeaderColumn>
            <TableHeaderColumn row="0" colSpan="2" dataSort csvHeader="Uren" headerAlign="center">Uren</TableHeaderColumn>
            <TableHeaderColumn dataField="uren" row="1" width="70px" headerAlign="center">Getal</TableHeaderColumn>
            <TableHeaderColumn dataField="urenTijd" row="1" width="70px" headerAlign="center">Tijd</TableHeaderColumn>
            <TableHeaderColumn dataField="overuren" row="0" rowSpan="2" headerAlign="center">Overuren</TableHeaderColumn>
            <TableHeaderColumn dataField="wachtvergoeding" row="0" rowSpan="2" headerAlign="center">Wachtvergoeding</TableHeaderColumn>
            <TableHeaderColumn dataField="verlof" row="0" rowSpan="2" headerAlign="center">Verlof</TableHeaderColumn>
            <TableHeaderColumn dataField="opmerkingen" row="0" rowSpan="2" headerAlign="center">Opmerkingen</TableHeaderColumn>
        </BootstrapTable>
        : null;

    return (
        <div className="col-md-12">
            <h2>{props.timesheet.maandText}</h2>
            {table}
        </div>
    );
};

TimesheetForm.propTypes = {
    timesheet: PropTypes.array.isRequired
};

export default TimesheetForm;