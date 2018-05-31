import React from 'react';
import { Link, NavLink } from 'react-router-dom';
import logo from '../resources/logo.png';

class NavMenu extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        const logoStyle = { "height": "40px", "paddingTop": "10px", "paddingLeft": "10px" };

        return <nav className="navbar navbar-inverse navbar-fixed-top">
            <div className="container">
                <div className="navbar-header">
                    <button type="button" className="navbar-toggle collapsed" data-toggle="collapse" data-target='.navbar-collapse' aria-expanded="false">
                        <span className="sr-only">Toggle navigation</span>
                        <span className="icon-bar"></span>
                        <span className="icon-bar"></span>
                        <span className="icon-bar"></span>
                    </button>                    
                    <NavLink to={'/'} activeClassName='className="navbar-brand"'>
                        <img alt="Dominion Experts" style={logoStyle} src={logo} />
                    </NavLink>
                </div>
                <div className="collapse navbar-collapse">
                    <ul className="nav navbar-nav">
                        <li>
                            <NavLink to={'/timesheets'} activeClassName='active'>
                                <span className='glyphicon glyphicon-list-alt'></span> Timesheets
                            </NavLink>
                        </li>
                        <li>
                            <NavLink to={'/verlof'} activeClassName='active'>
                                <span className='glyphicon glyphicon-calendar'></span> Verlof
                            </NavLink>
                        </li>
                    </ul>
                </div>  
            </div>
        </nav>;
    }
}

NavMenu.propTypes = {

}

export default NavMenu; 