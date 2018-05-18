import React from "react";
import PropTypes from "prop-types";
import { BootstrapTable, TableHeaderColumn } from "react-bootstrap-table";
import CheckboxFormatter from "../formatters/CheckboxFormatter";

const TimesheetForm = (props) => {
    const rowStyleClass = (row, rowIndex) => {
        if (row.isFeestdag) {
            return "timesheet-feestdag";
        } else if (row.isWeekend) {
            return "timesheet-weekend";
        };
    };

    const cellEdit = {
        mode: "click",
        blurToSave: true,
        beforeSaveCell: props.beforeSaveCell
    };

    const tableProps = {
        keyField: "id",
        data: props.timesheet.dagen,
        trClassName: rowStyleClass,
        cellEdit: cellEdit        
    }

    const numberValidator = (value) => {
        const nan = isNaN(value);
        if (nan) {
            return "Gelieve een numerieke waarde in te vullen";
        }
        return true;
    };

    const timeValidator = (value) => {
        const strArr = value.split(":");
        if (!strArr || strArr.length !== 2 || isNaN(parseInt(strArr[0], 10)) || isNaN(parseInt(strArr[1], 10))) {
            return "Gelieve een geldige tijd waarde in te vullen";
        }
        return true;
    };

    const border = (cell, row, ridx, cidx) => {
        return {
            borderRight: "2px solid" 
        };
    };

    const compensatieStyle = (cell, row, ridx, cidx) => {
        let color = "whitesmoke";

        if (row.isFeestdag) {
            color = "lightsalmon";
        } else if (row.isWeekend) {
            color = "lightgray";
        }

        return {
            backgroundColor: color,
            borderRight: "2px solid" 
        };
    };

    const edit = {
        type: "checkbox",
        options: { values: "true:false" }
    };

    function wachtFormatter(cell, row) {
        return (
            <CheckboxFormatter active={cell} />
        );
    }

    const table = props.timesheet.dagen.length > 0
        ? <BootstrapTable {...tableProps}>
            <TableHeaderColumn dataField="id" editable={ false } row="0" rowSpan="2" hidden>Id</TableHeaderColumn>
            <TableHeaderColumn dataField="isFeestdag" editable={false} row="0" rowSpan="2" hidden>Feestdag</TableHeaderColumn>
            <TableHeaderColumn dataField="isWeekend" editable={false} row="0" rowSpan="2" hidden>Weekend</TableHeaderColumn>

            <TableHeaderColumn dataField="weekNr" editable={false} tdStyle={border} row="0" rowSpan="2" width="60px" headerAlign="center">Week</TableHeaderColumn>

            <TableHeaderColumn row="0" colSpan="2" dataSort csvHeader="Dag" headerAlign="center">Dag</TableHeaderColumn>
            <TableHeaderColumn dataField="dagText" editable={false} row="1" width="50px" headerAlign="center"></TableHeaderColumn>
            <TableHeaderColumn dataField="dagNr" editable={false} tdStyle={border} row="1" width="50px" headerAlign="center"></TableHeaderColumn>

            <TableHeaderColumn row="0" colSpan="2" dataSort csvHeader="Uren" headerAlign="center">Uren</TableHeaderColumn>
            <TableHeaderColumn dataField="uren" editable={{validator: numberValidator}} row="1" width="70px" headerAlign="center">Getal</TableHeaderColumn>
            <TableHeaderColumn dataField="urenTijd" editable={{ validator: timeValidator}} tdStyle={border} row="1" width="90px" headerAlign="center">Tijd</TableHeaderColumn>

            <TableHeaderColumn row="0" colSpan="2" dataSort csvHeader="Overuren" headerAlign="center">Overuren</TableHeaderColumn>
            <TableHeaderColumn dataField="overuren" editable={{ validator: numberValidator }} row="1"width="70px" headerAlign="center">Getal</TableHeaderColumn>
            <TableHeaderColumn dataField="overurenTijd" editable={{ validator: timeValidator }} tdStyle={border} row="1" width="90px" headerAlign="center">Tijd</TableHeaderColumn>

            <TableHeaderColumn dataField="compensatie" editable={false} tdStyle={compensatieStyle} row="0" rowSpan="2" width="100px" dataAlign="center" headerAlign="center">Compensatie</TableHeaderColumn>

            <TableHeaderColumn dataField="wachtvergoeding" dataFormat={wachtFormatter} editable={edit} width="140px" dataAlign="center" row="0" rowSpan="2" headerAlign="center">Wachtvergoeding</TableHeaderColumn>
            <TableHeaderColumn dataField="verlof" row="0" editable={false} rowSpan="2" width="60px" headerAlign="center">Verlof</TableHeaderColumn>
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
    timesheet: PropTypes.array.isRequired,
    beforeSafeCell: PropTypes.func.isRequired
};

export default TimesheetForm;