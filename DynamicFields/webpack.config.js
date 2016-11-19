/// <binding ProjectOpened='Watch - Development' />

var webpack = require('webpack');
var ExtractTextPlugin = require('extract-text-webpack-plugin');
var WebpackNotifierPlugin = require('webpack-notifier');

module.exports = {
    entry: {
        app: './app/app.ts'
    },
    output: {
        path: './bundle/',
        filename: '[name].min.js',
        chunkFilename: '[id].js'
    },

    devtool: 'source-map',

    resolve: {
        extensions: ['', '.webpack.js', '.ts', '.js', '.css', '.less']
    },

    plugins: [
        new webpack.NoErrorsPlugin(),
        new webpack.optimize.UglifyJsPlugin({ mangle: false, compress: { warnings: false } }),
        new ExtractTextPlugin('[name].css'),
        new WebpackNotifierPlugin()
    ],

    module: {
        loaders: [
            {
                test: /\.ts$/,
                exclude: /node_modules/,
                loader: 'ts-loader?silent=true'
            },
            {
                test: /\.less$/,
                exclude: /node_modules/,
                loader: ExtractTextPlugin.extract('style-loader', 'css-loader!less-loader')
            }
        ],

        preLoaders: [
            { test: /\.js$/, loader: 'source-map-loader' }
        ]
    }
};