function MovieScript(id, currentUser){

    var result;
    var service = "http://localhost:59901/api";
    var tmdb = "https://image.tmdb.org/t/p/w500";
    var height = 45;
    var width = 32;
    var countItems = 10;
    var IsLiked;
    var IsWatching;

    this.init = function () {

        if (currentUser != null) {

            $.ajax({
                url: service + '/User/' + currentUser +
                    '/LikeOrWatch/' + id,
                type: 'GET',
                success: function (data) {
                    IsLiked = data.isLiked;
                    IsWatching = data.isWatching;
                    Watch();
                    Like();
                }
            });
        }
    }
    
    function LoadData() {
        $('.movie-name').text(result.title);
        $('.movie-picture').attr("src", tmdb + result.poster_path);
        LoadTable();
        LoadTableCasts();
    }
        
    function LoadTable() {
        LoadTr($('.tagline'), result.tagline);
        LoadTr($('.status'), result.status);
        LoadTr($('.releaseDate'), result.releaseDate);
        LoadTr($('.budget'), result.budget);
        LoadTr($('.releaseDate'), FormatMassive(result.productionCountries));
        LoadTr($('.revenue'), result.revenue);
        LoadTr($('.runtime'), result.runtime + " minutes");
        LoadTr($('.prodCountries'), FormatMassive(result.productionCountries));
        LoadTr($('.average'), result.vote_average);
        LoadTr($('.count'), result.vote_count);
    }

    function LoadTableCasts(){
        $.each(result.casts, function (i, cast) {
            var path = tmdb + cast.people.profile_path;
            if (cast.people.profile_path == null) {
                path = "~/Images/userIcon.png";
            }
            if (i++ == countItems) {
                return false;
            }
            var row = '<tr><td>' + i  +
                '</td><td><img src="' + path +
                '"height="' + height + '"width="' + width +
                '<a href="~/Person/' + cast.people.id + '">' + cast.name + "</a></td>" +
                '<td>' + cast.character + '</td></tr>'
            $('.table-casts').append(row);
        });
    }

    function LoadTr(td, data) {
        if (data == null) {
            td.remove();
        }
        else {
            td.text(data);
        }
    }

    function FormatMassive(massive) {
        var strFormat = "";
        $.each(massive, function (i, val) {
            strFormat += val.name;
        });
        return strFormat;
    }

    function Watch() {
        var element = $('#watchMovie');
        var color = IsWatching ? 'orange' : 'gray';
        element.append('<button type="submit" class="transparent" style="font-size:24px">' +
                       '<i class="fa fa-eye" style="font-size:24px;color:' + color +
                        '"></i></button>');
    }

    function Like() {
        var element = $('#likeMovie');
        var color = IsLiked ? 'red' : 'gray';
        element.append('<button type="submit" class="transparent" style="font-size:24px">' +
                       '<i class="fa fa-heart" style="font-size:24px;color:' + color +
                       '"></i></button>');
    }

    $('body').on('click', 'buttuon', function (e) {
        var sectionId = $(this).parent().attr('id');
        if (!IsWatching && sectionId == 'watchMovie') {
            $.ajax({
                url: service + '/User/' + currentUser + '/Watch/' + id,
                type: 'GET',
                success: function () {
                    $('.fa-eye').attr('color', 'orange');
                }
                      
            });
        }
        else if(!IsLiked && sectionId == 'sectionId'){
            $.ajax({
                url: service + '/User/' + currentUser + '/Like/' + id,
                type: 'GET',
                success: function () {
                    $('.fa-heart').attr('color', 'red');
                }
            })
        }
    });
        


}