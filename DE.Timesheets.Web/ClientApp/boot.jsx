import "./css/site.css";
import "bootstrap";
import "../node_modules/toastr/build/toastr.min.css";
import "../node_modules/react-bootstrap-table/dist/react-bootstrap-table-all.min.css";

import React from "react";
import { render } from "react-dom";
import { Switch, Route, BrowserRouter } from "react-router-dom";
import Routes from "./routes";

function renderApp() {
    const baseUrl = document.getElementsByTagName("base")[0].getAttribute("href");

    render(
        (<BrowserRouter>
                <Routes />
            </BrowserRouter>),
        document.getElementById("react-app")
    );
}

renderApp();