app.controller("MainController", function($location) {

    this.goTo = function(pPath) {
        $location.path(pPath || "");
    }

});