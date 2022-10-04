import React, { Component } from 'react';
//import { SearchHistory } from './SearchHistory';

export class Home extends Component {

    constructor(props) {
        super(props);
        this.state = {
            postCode: null,
            history: [],
            loading: true,
            errorMessage: ''
        };
        this.searchPostcode = this.searchPostcode.bind(this);
    }

    componentDidMount() {
        this.populateSampleHistoryData();
    }

    async searchPostcode() {
        let inputPostCode = document.getElementById('inputPostCode');
        let postCode = inputPostCode.value.trim();

        if (postCode == '') {
            this.setState({
                errorMessage: 'Provide a postcode for search.',
                postCode: null
            });
        }
        else {
            const response = await fetch('PostCode/GetPostCode/' + postCode);
            const jsonResp = await response.json();

            this.setState({
                errorMessage: jsonResp.message,
                postCode: jsonResp.data
            });

            inputPostCode.value = '';

            this.populateSampleHistoryData();
        }
    }

    render() {
        let postCodeInfo = this.state.postCode == null
            ? ''
            : Home.renderPostCodeInfo(this.state.postCode);

        let sampleHistory = this.state.loading
            ? <p><em>Loading...</em></p>
            : Home.renderSampleHistoryTable(this.state.history);

        let errorMessage = this.state.errorMessage == ''
            ? ''
            : <span className="text-danger">{this.state.errorMessage}</span>;

        return (
            <div>
                <div className="row justify-content-md-center">
                    <div className="col-md-4 col-md-auto">
                        <h1>Postcode Search</h1>
                        <div className="input-group mb-3">
                            <input id="inputPostCode" type="text" className="form-control" />
                            <button id="btnSearchPostCode" className="btn btn-primary" onClick={this.searchPostcode}>Search</button>
                        </div>
                        {errorMessage}

                    </div>
                    {postCodeInfo}
                </div>

                <div className="row justify-content-md-center">
                    <div className='sample-history'>
                        <h4>Postcode Recently Searched</h4>
                    </div>
                </div>
                {sampleHistory}
            </div>
        );
    }

    static renderPostCodeInfo(postCode) {
        return (
            <div className="d-flex justify-content-md-center mt-4">
                <div>
                    <div className="input-group mb-3">
                        <div >
                            <span className="input-group-text text-input-group">Postcode:</span>
                        </div>
                        <input type="text" className="input-group-text input-al-left" value={this.getValueForInput(postCode.postCodeNumber)} readOnly />
                    </div>

                    <div className="input-group mb-3">
                        <div >
                            <span className="input-group-text text-input-group">Outcode:</span>
                        </div>
                        <input type="text" className="input-group-text input-al-left" value={this.getValueForInput(postCode.outcode)} readOnly />
                    </div>

                    <div className="input-group mb-3">
                        <div >
                            <span className="input-group-text text-input-group">Incode:</span>
                        </div>
                        <input type="text" className="input-group-text input-al-left" value={this.getValueForInput(postCode.incode)} readOnly />
                    </div>

                    <div className="input-group mb-3">
                        <div >
                            <span className="input-group-text text-input-group">Quality:</span>
                        </div>
                        <input type="text" className="input-group-text input-al-left" value={this.getValueForInput(postCode.quality)} readOnly />
                    </div>

                    <div className="input-group mb-3">
                        <div >
                            <span className="input-group-text text-input-group">Eastings:</span>
                        </div>
                        <input type="text" className="input-group-text input-al-left" value={this.getValueForInput(postCode.eastings)} readOnly />
                    </div>

                    <div className="input-group mb-3">
                        <div >
                            <span className="input-group-text text-input-group">Northings:</span>
                        </div>
                        <input type="text" className="input-group-text input-al-left" value={this.getValueForInput(postCode.northings)} readOnly />
                    </div>

                    <div className="input-group mb-3">
                        <div >
                            <span className="input-group-text text-input-group">Country:</span>
                        </div>
                        <input type="text" className="input-group-text input-al-left" value={this.getValueForInput(postCode.country)} readOnly />
                    </div>

                    <div className="input-group mb-3">
                        <div >
                            <span className="input-group-text text-input-group">Nhs Ha:</span>
                        </div>
                        <input type="text" className="input-group-text input-al-left" value={this.getValueForInput(postCode.nhsHa)} readOnly />
                    </div>

                    <div className="input-group mb-3">
                        <div >
                            <span className="input-group-text text-input-group">Parl.y Constituency:</span>
                        </div>
                        <input type="text" className="input-group-text input-al-left" value={this.getValueForInput(postCode.parliamentaryConstituency)} readOnly />
                    </div>

                    <div className="input-group mb-3">
                        <div >
                            <span className="input-group-text text-input-group">Eu Electoral Region:</span>
                        </div>
                        <input type="text" className="input-group-text input-al-left" value={this.getValueForInput(postCode.europeanElectoralRegion)} readOnly />
                    </div>

                </div>

                <div className="mx-md-3">
                    <div className="input-group mb-3">
                        <div >
                            <span className="input-group-text text-input-group">Primary Care Trust:</span>
                        </div>
                        <input type="text" className="input-group-text input-al-left" value={this.getValueForInput(postCode.primaryCareTrust)} readOnly />
                    </div>

                    <div className="input-group mb-3">
                        <div >
                            <span className="input-group-text text-input-group">Region:</span>
                        </div>
                        <input type="text" className="input-group-text input-al-left" value={this.getValueForInput(postCode.region)} readOnly />
                    </div>

                    <div className="input-group mb-3">
                        <div >
                            <span className="input-group-text text-input-group">Parish:</span>
                        </div>
                        <input type="text" className="input-group-text input-al-left" value={this.getValueForInput(postCode.parish)} readOnly />
                    </div>

                    <div className="input-group mb-3">
                        <div >
                            <span className="input-group-text text-input-group">Lsoa:</span>
                        </div>
                        <input type="text" className="input-group-text input-al-left" value={this.getValueForInput(postCode.lsoa)} readOnly />
                    </div>

                    <div className="input-group mb-3">
                        <div >
                            <span className="input-group-text text-input-group">Msoa:</span>
                        </div>
                        <input type="text" className="input-group-text input-al-left" value={this.getValueForInput(postCode.msoa)} readOnly />
                    </div>

                    <div className="input-group mb-3">
                        <div >
                            <span className="input-group-text text-input-group">Ced:</span>
                        </div>
                        <input type="text" className="input-group-text input-al-left" value={this.getValueForInput(postCode.ced)} readOnly />
                    </div>

                    <div className="input-group mb-3">
                        <div >
                            <span className="input-group-text text-input-group">Ccg:</span>
                        </div>
                        <input type="text" className="input-group-text input-al-left" value={this.getValueForInput(postCode.ccg)} readOnly />
                    </div>

                    <div className="input-group mb-3">
                        <div >
                            <span className="input-group-text text-input-group">Nuts:</span>
                        </div>
                        <input type="text" className="input-group-text input-al-left" value={this.getValueForInput(postCode.nuts)} readOnly />
                    </div>
                </div>

                <div>
                    <div className="input-group mb-3">
                        <div >
                            <span className="input-group-text text-input-group">Longitude:</span>
                        </div>
                        <input type="text" className="input-group-text input-al-left" value={this.getValueForInput(postCode.longitude)} readOnly />
                    </div>

                    <div className="input-group mb-3">
                        <div >
                            <span className="input-group-text text-input-group">Latitude:</span>
                        </div>
                        <input type="text" className="input-group-text input-al-left" value={this.getValueForInput(postCode.latitude)} readOnly />
                    </div>

                    <div className="input-group mb-3">
                        <div >
                            <span className="input-group-text text-input-group">Dist. to Airport (Km):</span>
                        </div>
                        <input type="text" className="input-group-text input-al-left" value={this.getValueForInput(postCode.distanceToAirportKm)} readOnly />
                    </div>

                    <div className="input-group mb-3">
                        <div >
                            <span className="input-group-text text-input-group">Dist. to Airport (Mi):</span>
                        </div>
                        <input type="text" className="input-group-text input-al-left" value={this.getValueForInput(postCode.distanceToAirportMi)} readOnly />
                    </div>

                    <div className="input-group mb-3">
                        <div >
                            <span className="input-group-text text-input-group">Admin County:</span>
                        </div>
                        <input type="text" className="input-group-text input-al-left" value={this.getValueForInput(postCode.adminCounty)} readOnly />
                    </div>

                    <div className="input-group mb-3">
                        <div >
                            <span className="input-group-text text-input-group">Admin District:</span>
                        </div>
                        <input type="text" className="input-group-text input-al-left" value={this.getValueForInput(postCode.adminDistrict)} readOnly />
                    </div>

                    <div className="input-group mb-3">
                        <div >
                            <span className="input-group-text text-input-group">Admin Ward:</span>
                        </div>
                        <input type="text" className="input-group-text input-al-left" value={this.getValueForInput(postCode.adminWard)} readOnly />
                    </div>
                </div>
            </div>         
        );
    }

    static getValueForInput(val) {
        return val == null ? '' : val;
    }

    static renderSampleHistoryTable(history) {
        if (history == null) {
            return <p><em>No records.</em></p>
        }

        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>PostCode</th>
                        <th>Distance To Heathrow Airport (Km)</th>
                        <th>Distance To Heathrow Airport (Mi)</th>
                        <th>Date</th>
                    </tr>
                </thead>
                <tbody>
                    {history.map(item =>
                        <tr key={item.id}>
                            <td>{item.postCodeNumber}</td>
                            <td>{item.distanceToAirportKm}</td>
                            <td>{item.distanceToAirportMi}</td>
                            <td>{item.date}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    async populateSampleHistoryData() {
        const response = await fetch('PostCode/GetSearchHistory/3');
        const jsonResp = await response.json();

        this.setState({
            history: jsonResp.data,
            loading: false
        });
    }
}
