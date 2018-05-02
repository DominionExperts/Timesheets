import React from 'react';

import AutobindComponent from "../AutobindComponent";
import Dropdown from "../common/Dropdown";
import Loader from "../common/Loader"

import VerlofPageHelper from "./VerlofPageHelper";
import HistoriekForm from "./HistoriekForm";
import TellerForm from "./TellerForm";

class VerlofPage extends AutobindComponent {
    constructor(props) {
        super(props);

        this.state = {
            users: [],
            verlof: {
                userId: "",
                historiek: [],
                tellers: [],
            },
            loadingCount: 0,
            selectedUser: ""
        };

        this.pageHelper = new VerlofPageHelper(this);
    }

    componentWillMount() {
        this.pageHelper.init();
    }

    handleOnChangeUser(event) {
        this.pageHelper.changeUser(event);
    }

    render() {
        const userItems = this.state.users.map((user, index) => {
            return {
                value: user.id,
                label: user.naam
            };
        });

        const dropdownProps = {
            value: this.state.selectedUser,
            defaultItem: "Kies een optie",
            name: "users",
            items: userItems,
            onChange: this.handleOnChangeUser,
            size: 3
        };

        const historiekProps = {
            historiek: this.state.verlof.historiek
        };

        const tellerProps = {
            tellers: this.state.verlof.tellers
        }

        const page = this.state.loadingCount === 0 ?
            <div>
                <div className="row">
                    <Dropdown {...dropdownProps} />
                </div>
                <br />
                <div className="row">
                    <TellerForm {...tellerProps} />
                </div>
                <br/>
                <div className="row">
                    <HistoriekForm {...historiekProps} />
                </div>
            </div> : <Loader />;

        return <div>
            <h1>Verlof</h1>
            {page}
        </div>;
    }
}

export default VerlofPage;