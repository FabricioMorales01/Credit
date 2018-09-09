app.controller("DebtorController", function ($scope, $location, $routeParams, Util, DebtorService) {

    $scope.debtor = {};
    $scope.showHints = true;

    //si se envía id como parámetro obtiene el deudor solicitado
    $scope.get = function () {
        var vId = $routeParams.id;
        if (vId) {
            DebtorService.getById({
                id: vId,
                success: function (pDebtor) {
                    $scope.debtor = pDebtor;
                }
            });
        }
    }

    //obttiene el listado general de deudores
    $scope.getDeptors = function () {
        DebtorService.get({
            success: function (debtors) {
                $scope.debtors = debtors;
            }
        });
    };

    //permite guardar los datos del deudor
    $scope.save = function () {

        //si el deudor tiene un id asignado se asume que se quiere actualizar
        if ($scope.debtor.Id) {
            DebtorService.update({
                debtor: $scope.debtor,
                success: function () {
                    Util.showMessage("Deudor Actualizado");
                    $location.path("/");
                }
            });
        }
        else {
            DebtorService.insert({
                debtor: $scope.debtor,
                success: function () {
                    Util.showMessage("DeudorCreado");
                    $location.path("/");
                }
            });
        }
    }

    //elimina un deudor de la lista
    $scope.delete = function (pDebtor) {
        //es necesario la confirmación del usuario
        Util.showConfirm(
            "Desea eliminar a " + pDebtor.Name,
            function () {
                DebtorService.delete({
                    debtor: pDebtor,
                    success: function () {
                        var vIdx = $scope.debtors.indexOf(pDebtor);
                        $scope.debtors.splice(vIdx, 1);
                    }
                });
            }
        );
        
    }
    
});