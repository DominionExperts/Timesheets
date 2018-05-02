import React from "react";
import PropTypes from "prop-types";

const Dropdown = (props) => {
    const sizeClassName = "col-md-" + props.size;
    const defaultItem = props.defaultItem ? <option key={0} value="">{props.defaultItem}</option> : null;

    const dropdownProps = {  
        value: props.value,
        onChange: props.onChange,
        disabled: props.disabled,
        name: props.name
    };

    const options = props.items.map((item) => {
        return (
            <option key={item.value} value={item.value}>
                {item.label}
            </option>);
    });

    return (
        <div className={sizeClassName}>
            <select {...dropdownProps} className="form-control">
                {defaultItem}
                {options}
            </select>
        </div>
    );
};

Dropdown.propTypes = {
    value: PropTypes.oneOfType([
        PropTypes.number,
        PropTypes.string
    ]),
    defaulItem: PropTypes.string,
    items: PropTypes.array.isRequired,
    size: PropTypes.number.isRequired,
    onChange: PropTypes.func.isRequired,
    name: PropTypes.string.isRequired
};

export default Dropdown;