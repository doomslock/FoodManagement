var express = require('express');
var path = require('path');
var app = express();
var rootPath = path.normalize(__dirname);
app.use(express.static(rootPath));
app.get('*', function (req, res) { res.sendFile(rootPath + '/index.html'); });
app.listen(8000);
console.log('Listening on port 8000...');
//# sourceMappingURL=entry.js.map