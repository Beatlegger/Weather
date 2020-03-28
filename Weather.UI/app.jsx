var React = require('react');
var ReactDOM = require('react-dom');

import './App.css'; 

export class App extends React.Component {
    render() {
        return (
            <div className={"App"}>
                <h1>Welcome to React222!!</h1>
            </div>
        );
    }
}

ReactDOM.render(<App />, document.getElementById('root'));