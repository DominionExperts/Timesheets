import React from "react";
import PropTypes from "prop-types";

class CheckboxFormatter extends React.Component {
    render() {
        return (
            <input type="checkbox" checked={this.props.active} />
        );
    }
}

CheckboxFormatter.propTypes = {
    active: PropTypes.bool
};

export default CheckboxFormatter;