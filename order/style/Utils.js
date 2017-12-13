
// Provide a default path to dwr.engine
if (dwr == null) var dwr = {};
if (dwr.engine == null) dwr.engine = {};
if (DWREngine == null) var DWREngine = dwr.engine;

if (Utils == null) var Utils = {};
Utils._path = '/dwr';
Utils.initLogin = function(p0, p1, callback) {
  dwr.engine._execute(Utils._path, 'Utils', 'initLogin', p0, p1, callback);
}
Utils.getRealIP = function(callback) {
  dwr.engine._execute(Utils._path, 'Utils', 'getRealIP', false, callback);
}
Utils.getRealIP = function(callback) {
  dwr.engine._execute(Utils._path, 'Utils', 'getRealIP', callback);
}
Utils.getIdentify = function(callback) {
  dwr.engine._execute(Utils._path, 'Utils', 'getIdentify', callback);
}
Utils.getUserService = function(callback) {
  dwr.engine._execute(Utils._path, 'Utils', 'getUserService', callback);
}
Utils.setUserService = function(p0, callback) {
  dwr.engine._execute(Utils._path, 'Utils', 'setUserService', p0, callback);
}
Utils.getRemoteAddr = function(callback) {
  dwr.engine._execute(Utils._path, 'Utils', 'getRemoteAddr', false, callback);
}
