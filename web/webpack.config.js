const path = require('path');
const { DefinePlugin } = require('webpack');
const HtmlWebpackPlugin = require('html-webpack-plugin');

const is_prod = process.env.NODE_ENV == 'production';

/** @type {import('webpack').Configuration} */
const config = {
  mode: is_prod ? 'production' : 'development',
  entry: './src/index.tsx',
  output: {
    path: path.join(__dirname, 'build'),
  },
  resolve: {
    extensions: ['.js', '.ts', '.tsx'],
  },
  module: {
    rules: [
      {
        test: /\.tsx?$/,
        use: { loader: 'babel-loader' },
      },
    ],
  },
  plugins: [
    new DefinePlugin({
      'process.env': JSON.stringify(process.env),
    }),
    is_prod
      ? new HtmlWebpackPlugin({
          template: './src/index.html',
          baseUrl: process.env.BASE_URL,
          inject: true,
          minify: {
            removeComments: true,
            collapseWhitespace: true,
            removeRedundantAttributes: true,
            useShortDoctype: true,
            removeStyleLinkTypeAttributes: true,
            keepClosingSlash: true,
            minifyJS: true,
            minifyCSS: true,
            minifyURLs: true,
          },
        })
      : new HtmlWebpackPlugin({
          template: './src/index.html',
          baseUrl: process.env.BASE_URL,
        }),
  ],
  devServer: {
    port: parseInt(process.env.PORT),
    hot: true,
    open: true,
    historyApiFallback: true,
  },
};

if (is_prod) {
  config['optimization'] = {
    splitChunks: {
      chunks: 'all',
      name: false,
    },
    runtimeChunk: {
      name: entrypoint => `runtime-${entrypoint.name}`,
    },
  };
}

module.exports = config;
