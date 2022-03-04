$(document).ready(function () {
  $.ajax({
    url: "charts/charts_handler.php",
    type: "post",
    data: { append: true },
    success: function (categories) {
      cats = $.parseJSON(categories);
      //CHANGE SUBCATEGORIES
      console.log(cats);
      var $selectCats = $("#select-categories");
      $selectCats.empty();
      for (var i = 0; i < cats.length; i++) {
        $selectCats.append(
          "<option " + +"value=" + cats[i] + ">" + cats[i] + "</option>"
        );
      }
    },
  });
});
