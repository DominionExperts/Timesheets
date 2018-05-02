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
            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam cursus condimentum neque, non porttitor mi fermentum nec. Nulla gravida sapien vitae nunc aliquam sagittis. Nunc mattis condimentum massa ut suscipit. Etiam ac felis arcu. Integer iaculis nisl justo, sed sagittis mi congue in. Proin tincidunt tincidunt sagittis. Vestibulum rutrum massa mauris, et volutpat ex finibus gravida. Nulla eu massa in nulla viverra condimentum. Morbi vestibulum est dolor, et suscipit nibh efficitur nec. Nam ornare, velit nec iaculis consectetur, orci lorem mattis ante, sagittis commodo velit tortor in quam. Sed ornare velit felis, ut tempus mauris consequat vel. Curabitur vel fermentum turpis, in tempor tortor. Vivamus turpis ipsum, elementum ut blandit in, viverra non diam.</p>
        </div>;
    }
}

export default HomePage;