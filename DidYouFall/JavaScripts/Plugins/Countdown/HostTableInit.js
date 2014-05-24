$("#Hosts > tr").each(
          function (i, el) {
              var $td = $(this).children().last().children();
              var plusminutes = parseInt($td.html());
              var now = new Date(Date.now());
              now = now.setMinutes(now.getMinutes() + plusminutes);
              setInterval(function () {
                  $td.html(countdown(now).toString());
                  if ($td.html() == "1 ") {
                      alert("UhUL!")

                      now = new Date(Date.now());
                      now = now.setMinutes(now.getMinutes() + plusminutes);
                      $td.html(countdown(now).toString());
                  }
              }, 1000);
          });