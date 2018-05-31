import { showToastrError, showToastrSuccess, showToastrWarning } from "../../util/toastr";
import VerlofApi from "../../api/VerlofApi";
import UserApi from "../../api/UserApi";
import * as toastrMessages from "../../constants/toastrConstants";
import update from 'immutability-helper'; 

export default class VerlofPageHelper {
    constructor(context) {
        this.context = context;
    }

    init() {
        //TODO use redux for ajax counter
        this.context.setState({            
            loadingCount: 1
        });


        UserApi.get()
            .then((response) => {
                if (response.status && response.status === 200) {
                    const loadCount = this.context.state.loadingCount;

                    this.context.setState({
                        users: response.data,
                        loadingCount: loadCount - 1 
                    });
                } else {
                    this.handleError(toastrMessages.USER_ERROR);
                }
            })
            .catch((error) => {                
                this.handleError(toastrMessages.USER_ERROR);
            });
    }

    changeUser(event) {
        if (!event.target.value) return;
        const userId = event.target.value;

        this.context.setState({
            loadingCount: this.context.state.loadingCount + 1
        });

        
        VerlofApi.get(userId)
            .then((response) => {
                if (response.status && response.status === 200) {
                    const loadCount = this.context.state.loadingCount;

                    this.context.setState({
                        verlof: response.data,
                        loadingCount: loadCount - 1,
                        selectedUser: userId
                });
                } else {
                    this.handleError(toastrMessages.VERLOF_ERROR);
                }
            })
            .catch((error) => {
                this.handleError(toastrMessages.VERLOF_ERROR);
            });
    }

    handleError(error) {
        const loadCount = this.context.state.loadingCount;
        showToastrError(error);

        this.context.setState({
            loadingCount: loadCount - 1
        });

    }
}