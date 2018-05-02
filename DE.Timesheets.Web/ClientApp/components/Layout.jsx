import React from 'react';
import PropTypes from "prop-types";
import NavMenu from './NavMenu';

class Layout extends React.Component {
    constructor(props) {
        super(props);
    }

    // Hier de menu renderen
    render() {
        return (<div className='container'>
            <NavMenu />
                <div className='row paddingLayout'>
                    <div className='col-sm-12'>
                        {this.props.children}
                    </div>
                </div>
        </div>);
    }
}

Layout.propTypes = {
    children: PropTypes.object.isRequired
}

export default Layout;