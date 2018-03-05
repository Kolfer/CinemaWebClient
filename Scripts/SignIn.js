function SignIn(redirectHref) {
    var service = "http://localhost:59901";
    var tokenInfo = "tokenInfo";
    var userName = "UserName";
    var dayExpiresCookie = 14;

    this.init = function(){

        $('.signin').click(function (e) {

            e.preventDefault();
            var validation = $('.validation');
            validation.empty();

            var loginData = {
                grant_type : 'password',
                UserName : $('#name').val(),
                Password : $('#password').val()
            }

            $.ajax({
                type: 'POST',
                url: service + '/Token',
                data: loginData,
                success: function (data) {
                    $.ajax({
                        url: '/Account/SignIn',
                        type: 'POST',
                        data: { token : data },
						dataType : 'json',
                        success : function(data){
                            window.location.replace(redirectHref);
                        },
                        error: function (data) {
                            var error = '<h6 class="error">Please, repeate request.</h6>';
							validation.append(error);
                        }
                    })
                },
                error: function (data) {
                    var error = '<h6 class="error">Name or password is invalid</h6>';
                    validation.append(error);
                }
            })
        });
    }

    function setCookie(key, value, exdays){
        var d = new Date();
        d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
        var expires = "expires="+ d.toUTCString();
        document.cookie = key + "=" + value + ";" + expires + ";path=/";
    }

}