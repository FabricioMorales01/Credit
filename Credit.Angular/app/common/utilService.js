app.service("Util", function () {
    var vUtil = {};

    vUtil.isValidResponse = function (pResponse) {
        var vIsValid = false;
        var vMessage = null;
        if (pResponse && pResponse.data) {
            vIsValid = pResponse.data.IsSuccessful;
            vMessage = pResponse.data.ErrorMessage;
        }

        if (!vIsValid) {
            vUtil.showMessage(vMessage || "Ha ocurrido un error en el servicio");
        }

        return vIsValid;
    };

    vUtil.showMessage = function (pMessage) {
        alert(pMessage);
    };

    vUtil.showConfirm = function (pMessage, pOk, pCancel) {

        if (confirm(pMessage)) {
            vUtil.isFunction(pOk) && pOk();
        } else {
            vUtil.isFunction(pCancel) && pCancel();
        }
    };

    vUtil.isFunction = function (pVal) {
        return typeof pVal === "function";
    };

    return vUtil;
});

