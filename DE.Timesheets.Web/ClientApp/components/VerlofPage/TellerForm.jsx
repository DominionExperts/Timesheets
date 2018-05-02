import React from "react";
import PropTypes from "prop-types";
import BootstrapTable from "react-bootstrap-table-next";

const TellerForm = (props) => {
    const columns = [
        {
            dataField: "typeId",
            text: "TypeId",
            hidden: true
        }, {
            dataField: "typeText",
            text: "Type"
        }, {
            dataField: "beschikbaar",
            text: "Beschikbaar"
        }, {
            dataField: "genomen",
            text: "Genomen"
        }, {
            dataField: "inAanvraag",
            text: "In Aanvraag"
        }, {
            dataField: "totaal",
            text: "Totaal"
        }];

    const tableProps = {
        keyField: "id",
        data: props.tellers,
        columns: columns
    }

    return (
        <div className="col-md-12">
            <h2>Verlof tellers</h2>
            <BootstrapTable {...tableProps}  />
        </div>
    );
};

TellerForm.propTypes = {
    tellers: PropTypes.array.isRequired
};

export default TellerForm;