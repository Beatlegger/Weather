import React, { Component } from 'react';
import { Weather } from './components/Weather';

import './App.css'

export default class App extends Component {
    static displayName = App.name;

    constructor(props) {
        super(props);
        this.state = { weather: 'sun' };
    }

    weatherHandler = (weather) => {
        this.setState({ weather: weather })
    }

    render() {
        return (
            <div>
                <div className={'overlay ' + this.state.weather}></div>
                <div className="header">
                    <div className="brand"><i className="fas fa-umbrella"></i> WTHR</div>
                </div>
                <div className="content">
                    <Weather weatherHandler={this.weatherHandler} />
                </div>
            </div>
        );
    }
}
