app.service("DebtorService", function ($http, Util) {

    return {
        get: function (pOptions) {

            $http({
                method: "GET",
                url: config.urlServer + "GetDebtors",
                headers: {
                    "Content-Type": "application/json"
                }
            }).then(function (pResponse) {

                if (Util.isValidResponse(pResponse)) {
                    pOptions.success(pResponse.data.DebtorsList);
                }

            }, function () {
                Util.showMessage("Error obteniendo lista de deudores");
            });
        },

        getById: function (pOptions) {

            var vData = { id: pOptions.id };

            $http({
                method: "GET",
                url: config.urlServer + "GetDebtor",
                dataType: 'json',
                headers: {
                    "Content-Type": "application/json"
                },
                params: vData
            }).then(function (pResponse) {

                if (Util.isValidResponse(pResponse)) {
                    pOptions.success(pResponse.data.Debtor);
                }

            }, function () {
                Util.showMessage("Error obteniendo deudor");
            });
        },

        insert: function (pOptions) {

            var vData = { Debtor: pOptions.debtor };

            $http({
                method: "POST",
                url: config.urlServer + "InsertDebtor",
                dataType: 'json',
                headers: {
                    "Content-Type": "application/json"
                },
                data: vData
            }).then(function (pResponse) {
                if (Util.isValidResponse(pResponse)) {
                    pOptions.success(pResponse.data.Debtor);
                }
            }, function () {
                Util.showMessage("Error Realizando request de creación");
            });
        },
        update: function (pOptions) {

            var vData = { Debtor: pOptions.debtor };

            $http({
                method: "POST",
                url: config.urlServer + "UpdateDebtor",
                dataType: 'json',
                headers: {
                    "Content-Type": "application/json"
                },
                data: vData
            }).then(function (pResponse) {
                if (Util.isValidResponse(pResponse)) {
                    pOptions.success();
                }
            }, function () {
                Util.showMessage("Error Realizando request de actualización");
            });
        },
        delete: function (pOptions) {

            var vData = {
                Debtor:  pOptions.debtor 
            };

            $http({
                method: "POST",
                url: config.urlServer + "DeleteDebtor",
                dataType: 'json',  
                headers: {
                    "Content-Type": "application/json"
                },
                data: vData
            }).then(function (pResponse) {
                if (Util.isValidResponse(pResponse)) {
                    pOptions.success();
                }
            }, function () {
                Util.showMessage("Error Realizando request de eliminación");
            });
        }
    };

});