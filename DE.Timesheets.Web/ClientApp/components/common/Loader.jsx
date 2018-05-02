import React from "react";
import PropTypes from "prop-types";
import Spinner from "react-spinkit";

const Loader = (props) => {
    const loaderStyle = {
        float: "none",
        margin: "0 auto"
    };

    return (
        <div className="col-md-1" style={loaderStyle}>
            <Spinner name="chasing-dots" color="orange" />
        </div>
    );
};

Loader.propTypes = {
};

export default Loader;