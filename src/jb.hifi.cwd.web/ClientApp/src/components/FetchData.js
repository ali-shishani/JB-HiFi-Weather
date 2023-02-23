import React, { Component } from 'react';

export class FetchData extends Component {
    static displayName = FetchData.name;

    constructor(props) {
        super(props);
        this.state = {
            filterCity: 'Melbourne',
            filterCountry: 'AU',
            weatherInfo: {},
            loading: true,
            hasError: false,
            errorMessage: ''
        };
    }

    componentDidMount() {
        this.populateWeatherData();
    }

    populateWeatherData() {
        this.getCurrentWeatherData(this.state.filterCity, this.state.filterCountry);
    }

    async getCurrentWeatherData(city, country) {
        this.setState({
            ...this.state,
            loading: true
        });
        debugger;
        var url = 'currentweatherdata?city=' + city + '&country=' + country;
        fetch(url, {
            method: 'GET',
            headers: {
                'X-ClientId': 'your-rate-limiting-key1',
            },
        }).then((response) => {
            if (response.ok) {
                return response.json();
            }

            // something went wrong. this line will handle unsuccessful requests including "rate limits""
            var message = 'Response Status: ' + response.status + ' | Message: ' + response.statusText;
            throw new Error(message);

        }).then((responseJson) => {
            if (responseJson) {
                if (responseJson.success) {
                    this.setState({
                        ...this.state,
                        weatherInfo: responseJson,
                        loading: false,
                        hasError: false,
                        errorMessage: ''
                    });
                } else {
                    var errorItem = responseJson.errors[0];
                    this.setState({
                        ...this.state,
                        weatherInfo: {},
                        loading: false,
                        hasError: true,
                        errorMessage: errorItem.message
                    });
                }
            }
        }).catch((error) => {
            console.log(error)
            this.setState({
                ...this.state,
                weatherInfo: {},
                loading: false,
                hasError: true,
                errorMessage: error.message
            });
        });
    }

    handleCityFilterChange(newValue) {
        this.setState({
            ...this.state,
            filterCity: newValue
        });

        return true;
    }

    handleCountryFilterChange(newValue) {
        this.setState({
            ...this.state,
            filterCountry: newValue
        });

        return true;
    }

    renderForecastsFilter() {
        return (
            <div>
                <div className="row">
                    <div className="col">
                        <input type="text" className="form-control" id="cityInput" aria-describedby="emailHelp" placeholder="Enter city" value={this.state.filterCity}
                            onChange={(event) => {
                                this.handleCityFilterChange(event.target.value);
                            }}
                        />
                    </div>
                    <div className="col">
                        <input type="text" className="form-control" id="countryInput" placeholder="Enter country" value={this.state.filterCountry}
                            onChange={(event) => {
                                this.handleCountryFilterChange(event.target.value);
                            }}
                        />
                    </div>
                </div>
                <br />
                <div className="row">
                    <div className="col">
                        <button type="button" className="btn btn-primary"
                            onClick={(event) => {
                                this.populateWeatherData();
                            }}>Refresh</button>
                    </div>
                </div>
                <br />
            </div>
        );
    }

    renderForecastsResult() {
        if (this.state.hasError) {
            return (
                <div>
                    <div className="row">
                        <div className="col">
                            <div className="col-sm-12">
                                <label htmlFor="staticError" className="col-sm-2 col-form-label text-danger"><strong>An error was handled!</strong></label>
                                <textarea readOnly className="form-control form-control-plaintext text-danger" id="staticError" value={this.state.errorMessage} />
                            </div>
                        </div>
                    </div>
                </div>
            );
        } else {
            return (
                <div>
                    <div className="row">
                        <div className="col">
                            <div className="col-sm-12">
                                <label htmlFor="staticDescription" className="col-sm-2 col-form-label .text-primary"><strong>Weather Description:</strong></label>
                                <textarea readOnly className="form-control form-control-plaintext .text-primary" id="staticDescription" value={this.state.weatherInfo.description} />
                            </div>
                        </div>
                    </div>
                </div>
            );
        }
    }

    render() {

        let filter = this.renderForecastsFilter();

        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.renderForecastsResult(this.state.forecasts);

        return (
            <div>
                <h1 id="tabelLabel" >Current Weather Data</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {filter}
                {contents}
            </div>
        );
    }
}
