import React from "react";
//import AppContext from "./AppContext";
import PropTypes from "prop-types";

const AppContext = React.createContext();

class AppProvider extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            ajaxCounter: 0
        };
    }

    render() {
        const contextValue = {
            ajaxCounter: this.state.ajaxCounter,
            incrementAjaxCounter: () => {
                this.setState({
                    ajaxCounter: this.state.ajaxCounter + 1
                });
            },
            decrementAjaxCounter: () => {
                this.setState({
                    ajaxCounter: this.state.ajaxCounter - 1
                });
            }
        };

        return (
            <AppContext.Provider value={contextValue}>
                {this.props.children}
            </AppContext.Provider>
        );
    }
}

AppProvider.propTypes = {
    children: PropTypes.object.isRequired
}

export default AppProvider;