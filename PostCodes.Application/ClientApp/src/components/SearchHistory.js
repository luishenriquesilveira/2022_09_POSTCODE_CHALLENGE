import React, { Component } from 'react';

export class SearchHistory extends Component {

    constructor(props) {
        super(props);
        this.state = {
            history: [],
            loading: true
        };
    }

    componentDidMount() {
        this.populateSearchHistoryData();
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : SearchHistory.renderHistoryTable(this.state.history);

        return (
            <div className="row justify-content-md-center">
                <div className="col-md-4 col-md-auto">
                    <h1 id="tabelLabel" >Search History</h1>
                    <li className="mb-4"><strong>Last 24h </strong>search history.</li>
                </div>
                {contents}
            </div>
        );
    }

    static renderHistoryTable(history) {
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

    async populateSearchHistoryData() {
        const response = await fetch('PostCode/GetFullSearchHistoryByDateLimit');
        const jsonResp = await response.json();

        this.setState({
            history: jsonResp.data,
            loading: false
        });
    }
}
