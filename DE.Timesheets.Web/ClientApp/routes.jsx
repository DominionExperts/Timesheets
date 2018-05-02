import React from "react";
import { render } from "react-dom";
import { Switch, Route } from "react-router-dom";
import Layout from "./components/Layout";
import HomePage from "./components/HomePage";
import TimesheetPage from "./components/TimesheetPage/TimesheetPage";
import VerlofPage from "./components/VerlofPage/VerlofPage";

class Routes extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        return <Layout>
            <Switch>
                <Route exact path='/' component={HomePage} />
                <Route exact path='/timesheets' component={TimesheetPage} />
                <Route exact path='/verlof' component={VerlofPage} />
            </Switch>
        </Layout>;
    }
}

export default Routes;