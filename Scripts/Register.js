function Register(redirectHref) {
    var service = "http://localhost:59901/api";
    var good = "Looks good";

    this.init = function () {

        $('.register-submit').click(function (e) {
            e.preventDefault();
            $('.validation').empty();
            var data = {
                UserName: $('#username').val(),
                Email: $('#email').val(),
                Password: $('#password').val(),
                ConfirmPassword: $('#confirm-password').val(),
                Country: $('#country').val(),
                City: $('#city').val(),
                Gender : $('#gender').val()
            };

            $.ajax({
                url : service + '/Account/Register',
                type : 'POST',
                contentType: 'application/json; charset=utf-8',
                data : JSON.stringify(data),
                success : function(data){
                    window.location.replace(redirectHref);
                },
                error : function(data){
                    var ModelState = data.responseJSON.modelState;
                    if (ModelState != null) {
                        $.each(ModelState, function (i, error) {
                            var errorHtml = '<h6 class="error">' + error + '</h6>'
                            $('.validation').append(errorHtml);
                        });
                    }
                }
             });
        });

        function ValidationUserName() {
            var username = $('#username');
            var sizeNameMore = "Maximum name length is 100";
            var maxSize = 100;

            username.focusout(function () {
                var value = username.val();
                $.ajax({
                    type : 'GET',
                    url: service + '/Account/IsBusyUserName',
                    data: { username: value },
                    success: function (data) {
                        if (data.busy) {
                            username.addClass("is-invalid").removeClass("is-valid");
                            username.siblings().text("This user name is busy");
                        }
                        else if (value.length > maxSize) {
                            username.addClass("is-invalid").removeClass("is-valid");
                            username.siblings().text(sizeNameMore);
                        }
                        else {
                            username.addClass("is-valid").removeClass("is-invalid");
                            username.siblings().text(good);
                        }
                    },
                    error : function() {
                    }
                })
            })
        }

        function ValidationEmail() {
            var email = $('#email');
            var emailBusy = 'This email is busy';

            email.focusout(function () {
                var value = email.val();

                $.ajax({
                    type: 'GET',
                    url: service + '/Account/IsBusyEmail',
                    data: { email: value },
                    success: function (data) {
                        if (data.busy) {
                            email.addClass("is-invalid").removeClass("is-valid");
                            email.siblings().text(emailBusy);
                        }
                        else {
                            email.addClass("is-valid").removeClass("is-invalid");
                            email.siblings().text(good);
                        }
                    },
                    error: function () {
                    }
                })
            })

        }

        function ValidatePassword() {
            var maxSize = 50;
            var minSize = 6;
            var sizeNameMore = "Maximum password length is 50";
            var sizeNameLess = "Minumum password length is 6"
            var compare = "Password must be equals";

            var confirm = $('#confirm-password');
            var password = $('#password');

            password.focusout(function () {
                var value = password.val();
                var confirm = confirm.val();

                if (value.length > maxSize) {
                    password.addClass("is-invalid").removeClass("is-valid");
                    password.siblings().text(sizeNameMore);
                }
                else if (value.length < minSize) {
                    password.addClass("is-invalid").removeClass("is-valid");
                    password.siblings().text(sizeNameMore);
                }
                else if (value != confirm) {
                    password.addClass("is-invalid").removeClass("is-valid");
                    password.siblings().text(compare);
                }
                else {
                    username.addClass("is-valid").removeClass("is-invalid");
                    username.siblings().text(good);
                }

                confirm.focusout(function () {
                    var value = password.val();
                    var confirm = confirm.val();
                    if (value != confirm) {
                        confirm.addClass("is-invalid").removeClass("is-valid");
                        confirm.siblings().text(compare);
                    }
                    else {
                        username.addClass("is-valid").removeClass("is-invalid");
                        username.siblings().text(good);
                    }
                })
            })
        }
    }
}