"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var environment_1 = require("../../../environments/environment");
var BaseService = /** @class */ (function () {
    function BaseService(http) {
        this.http = http;
    }
    BaseService.prototype.get = function () {
        return this.getRequest();
    };
    BaseService.prototype.getRequest = function () {
        return this.http.get("" + environment_1.environment.api + this.endpoint);
    };
    BaseService.prototype.getById = function (id) {
        return this.http.get("" + environment_1.environment.api + this.endpoint + "/" + id);
    };
    BaseService.prototype.post = function (model) {
        return this.http.post("" + environment_1.environment.api + this.endpoint, model, {});
    };
    BaseService.prototype.put = function (model) {
        return this.http.put("" + environment_1.environment.api + this.endpoint, model, {});
    };
    return BaseService;
}());
exports.BaseService = BaseService;
//# sourceMappingURL=base.js.map