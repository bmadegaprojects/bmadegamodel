"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
Object.defineProperty(exports, "__esModule", { value: true });
var base_1 = require("./base");
var EmployeeService = /** @class */ (function (_super) {
    __extends(EmployeeService, _super);
    function EmployeeService(http) {
        var _this = _super.call(this, http) || this;
        _this.http = http;
        _this.endpoint = '/employee';
        return _this;
    }
    return EmployeeService;
}(base_1.BaseService));
exports.EmployeeService = EmployeeService;
//# sourceMappingURL=employee.service.js.map