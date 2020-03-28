import React, { Component } from 'react';

export class Weather extends Component {
    static displayName = Weather.name;

    constructor(props) {
        super(props);
        this.state = { srchLocation: '', city: '', country: '', today: {}, forecast: [], loading: true };
        this.onChangeCity = this.onChangeCity.bind(this);
        this.onClick = this.onClick.bind(this);
    }

    async componentDidMount() {
        await this.loadingWeatherData();
    }

    async onChangeCity(ev) {
        ev.preventDefault();
        var location = ev.target.value;
        this.setState({ ...this.state, srchLocation: location });
    };

    async onClick(ev) {
        ev.preventDefault();
        const data = await this.loadingWeatherByCity(this.state.srchLocation);
        this.applyData(data);
    }

    renderForecastsTable(weather) {
        var { today, forecast } = weather;
        return (
            <div>
                <div className="section">
                    <div className="section-header">
                        <label><i className="fas fa-map-marker-alt"></i> Location:</label>
                        <input type="text" name="citi" value={this.state.srchLocation} onChange={this.onChangeCity} />
                        <button className="icon" onClick={this.onClick}><i className="fas fa-search"></i></button>
                    </div>
                </div>
                {today && this.renderToday(today)}
                {forecast && forecast.length > 0 && this.renderForecast(forecast)}
            </div>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.renderForecastsTable(this.state);

        return (
            <div>
                {contents}
            </div>
        );
    }

    renderToday(today) {
        return (<div className="section">
            <div className="section-header">Today</div>
            <div className="section-content">
                <div className="today">
                    <table>
                        <thead>
                            <tr>
                                <th>Date</th>
                                <th>Temp (&deg;C)</th>
                                <th>Humidity</th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>{today.date.toLocaleString([], { month: '2-digit', day: '2-digit' })}</td>
                                <td>{today.temperature > 0 ? '+' + today.temperature : today.temperature}</td>
                                <td>{today.humidity}%</td>
                                <td>{today.description}</td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>)
    }

    renderForecast(forecast) {
        return (<div className="section">
            <div className="section-header">Forecast</div>
            <div className="section-content">
                <div className="forecast">
                    <table>
                        <thead>
                            <tr>
                                <th>Date</th>
                                <th>Temp (&deg;C)</th>
                                <th>Humidity</th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
                            {forecast.map((w, i) => {
                                return (<tr key={w.date}>
                                    <td>{w.date.toLocaleString([], { month: '2-digit', day: '2-digit' })}</td>
                                    <td>{w.temperature > 0 ? '+' + w.temperature : w.temperature}</td>
                                    <td>{w.humidity}%</td>
                                    <td>{w.description}</td>
                                </tr>)
                            })}
                        </tbody>
                    </table>
                </div>
            </div>
        </div>);
    }

    async location() {
        return new Promise((resolve, reject) => {
            navigator.geolocation.getCurrentPosition(resolve, reject);
        });

    }

    async loadingWeatherData() {
        const location = await this.location().catch(e => null);
        const data = location
            ? await this.loadingWeatherByLocation(location)
            : await this.loadingWeatherByCity("Moscow"); //default
        this.applyData(data);
    }

    applyData(data) {
        const isToday = (someDate) => {
            const today = new Date()
            return someDate.getDate() == today.getDate() &&
                someDate.getMonth() == today.getMonth() &&
                someDate.getFullYear() == today.getFullYear()
        }

        var today = {};
        const forecast = [];
        data.days.forEach(function (day) {
            day.date = new Date(day.dateTime);
            if (isToday(day.date))
                today = day;
            else
                forecast.push(day);
        });

        this.props.weatherHandler(today.description.toLowerCase());
        this.setState({ srchLocation: data.city + ', ' + data.country, city: data.city, country: data.country, today: today, forecast: forecast, loading: false })
    }

    async loadingWeatherByLocation(location) {
        var response = await fetch('weather?lat=' + location.coords.latitude + '&lon=' + location.coords.longitude);
        return await response.json();
    }

    async loadingWeatherByCity(city) {
        var response = await fetch('weather?city=' + city);
        return await response.json();
    }
}
