module.exports = {
    entry: "./entry.ts",
    output: {
        path: __dirname,
        filename: "bundle.js"
    },
    module: {
        loaders: [
            { test: /\.css$/, loader: "style!css" }
        ]
    }
};


// var path = require('path');

// module.exports = {
//   entry: './src/bootstrap.ts',
//   output: {
//     path: __dirname + '/dist',
//     filename: 'bundle.js'
//   },
//   resolve: {
//     root: path.resolve('./src'),
//     extensions: ['', '.webpack.js', '.web.js', '.ts', '.js'],
//     alias: {
//       decorators: path.resolve(__dirname, 'src', 'decorators', 'app.ts'),
//       app: path.resolve(__dirname, 'src', 'app', 'app.ts')
//     }
//   },
//   module: {
//     loaders: [
//       { test: /\.ts$/, loader: 'ts-loader' },
//       { test: /\.less$/, loader: 'style!css!less' },
//       { test: /\.css$/, loader: 'style!css' },
//       { test: /\.html$/, loader: 'html-loader' },
//       { test: /\.woff(2)?(\?v=[0-9]\.[0-9]\.[0-9])?$/, loader: "url-loader?limit=10000&minetype=application/font-woff" },
//       { test: /\.(ttf|eot|svg)(\?v=[0-9]\.[0-9]\.[0-9])?$/, loader: "file-loader" }
//     ]
//   }
// }
