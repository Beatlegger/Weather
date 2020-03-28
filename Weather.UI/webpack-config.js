module.exports = {
    devtool: 'source-map',
    entry: "./app.jsx",
    mode: "development",
    output: {
        filename: "./app-bundle.js"
    },
    resolve: {
        extensions: ['.Webpack.js', '.web.js', '.js', '.jsx', '.tsx', '.css']
    }
};