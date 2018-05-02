import React from 'react';
import AutobindComponent from "./AutobindComponent";

class HomePage extends AutobindComponent {
    constructor(props) {
        super(props);
    }

    render() {
        return <div>
            <h1>Homepage</h1>
            <p>Hier kan informatie staan ivm verlof etc</p>
            <br />
            <p>TODO Lijstje non-technical</p>
            <ul>
                <li>Connection String in Secret steken</li>
                <li>Project op Github van DE zetten</li>
            </ul>
            <p>TODO Lijstje Technical</p>
            <ul>
                <li>.Net Core 2.0 => 2.1 upgrade</li>
                <li>Builders gebruiken in Service</li>
                <li>Recup vorig jaar berekenen</li>
                <li>Timesheets module helemaal</li>
                <li>Verlof aanvragen</li>
                <li>Admin module met overzicht aanvragen</li>
                <li>...</li>
                <li>Security implementeren</li>
            </ul>
        </div>;
    }
}

export default HomePage;