var express = require('express');
var cors = require('cors');
var path = require('path');
var app = express();
var webpack = require('webpack');
var webpackMiddleware = require('webpack-dev-middleware');
var webpackHotMiddleware = require('webpack-hot-middleware');
var config = require('./webpack.config.js');
var rootPath = path.normalize(__dirname + '/src');


// var compiler = webpack(config);
//   var middleware = webpackMiddleware(compiler, {
//     publicPath: config.output.publicPath,
//     contentBase: 'src',
//     stats: {
//       colors: true,
//       hash: false,
//       timings: true,
//       chunks: false,
//       chunkModules: false,
//       modules: false
//     }
//   });

//   app.use(middleware);
//   app.use(webpackHotMiddleware(compiler));
//   app.get('*', function response(req, res) {
//     res.write(middleware.fileSystem.readFileSync(path.join(rootPath + '/index.html')));
//     res.end();
// });
var corsOptions = {
  origin: 'https://www.google.com/uds/',
  optionsSuccessStatus: 200 // some legacy browsers (IE11, various SmartTVs) choke on 204
};

app.use(cors(corsOptions));
app.use(express.static(rootPath));
app.get('*', function (req, res) { res.sendFile(rootPath + '/index.html'); });

app.listen(8000);
console.log('Listening on port 8000...');