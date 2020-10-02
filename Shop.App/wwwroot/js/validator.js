(function () {
    'use strict';
    window.addEventListener('load', function () {
        var forms = document.getElementsByClassName('needs-validation');
        var validation = Array.prototype.filter.call(forms, function (form) {
            form.addEventListener('submit', function (event) {
                if (form.checkValidity() === false) {
                    event.preventDefault();
                    event.stopPropagation();
                    var ele = form.getElementsByTagName("input")
                    for (var i = 0; i < ele.length; i++) {
                        var msg = "", reason = ele[i].validity;
                        if (reason.valueMissing) {
                            msg = ele[i].getAttribute("data-value-missing");
                        }
                        else if (reason.patternMismatch) {
                            msg = ele[i].getAttribute("data-pattern-mismatch");
                        }
                        else {
                        }
                        ele[i].nextElementSibling.innerText = msg;
                    }
                }
                form.classList.add('was-validated');
            }, false);
        });
    }, false);
})();