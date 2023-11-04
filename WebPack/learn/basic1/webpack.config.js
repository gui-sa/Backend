const path = require('path');

module.exports = {
    mode: 'production',
    entry: './src/index.js',
    output: {
    filename: 'bundle.js',
    path: path.resolve(__dirname, 'dist'),
    },
    module: {
        rules: [
            {
                test: /\.css$/,
                use: ['style-loader','css-loader',]
            },
            {
                test: /\.(?:js|mjs|cjs)$/,
                exclude: /node_modules/,
                use: {
                  loader: 'babel-loader',
                  options: {
                    presets: [
                      ['@babel/preset-env', { targets: "defaults" }]
                    ]
                  }
                }
            }
        ]
    }
};