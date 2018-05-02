import React from "react";
import PropTypes from "prop-types";
import BootstrapTable from "react-bootstrap-table-next";

import { VerlofStatus, VerlofStatusColor } from "../../constants/verlofConstants";


const HistoriekForm = (props) => {
    const columns = [
        {
            dataField: "id",
            text: "Id",
            hidden: true
        }, {
            dataField: "datum",
            text: "Datum"
        }, {
            dataField: "typeText",
            text: "Type"
        }, {
            dataField: "eenheidsText",
            text: "Eenheid"
        }, {
            dataField: "eenheid",
            text: "", 
            hidden: true
        }, {
            dataField: "statusText",
            text: "Status"
        }, {
            dataField: "status",
            text: "",
            hidden: true
        }, {
            dataField: "opmerkingen",
            text: "Opmerkingen"
        }];

    const rowStyle = (row, rowIndex) => {
        let color = "";

        switch (row.status) {
            case VerlofStatus.InAanvraag:
                color = VerlofStatusColor.InAanvraag;
                break;            
            case VerlofStatus.Afgekeurd:
                color = VerlofStatusColor.Afgekeurd;
                break;            
            case VerlofStatus.Goedgekeurd:
                color = VerlofStatusColor.Goedgekeurd;
                break;            
            case VerlofStatus.Geannuleerd:
                color = VerlofStatusColor.Geannuleerd;
                break;            
            default:
                color = VerlofStatusColor.InAanvraag;
                break;
        }

        return { backgroundColor: color };
    };

    const tableProps = {
        keyField: "id",
        data: props.historiek,
        columns: columns,
        rowStyle: rowStyle
    }

    return (
        <div className="col-md-12">
            <h2>Historiek</h2>
            <BootstrapTable {...tableProps} />
        </div>
    );
};

HistoriekForm.propTypes = {
    historiek: PropTypes.array.isRequired
};

export default HistoriekForm;