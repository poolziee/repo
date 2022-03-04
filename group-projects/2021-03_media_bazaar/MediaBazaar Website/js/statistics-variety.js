$(document).ready(function () {
  function CreateChart(query, title) {
    var chartIdSeeder = "chart1";
    //CREATE CHARTS AND LOAD THEM IN STATISTICS-WRAPPER ======================================================
    var div = document.getElementById("charts-wrapper");
    var chart =
      "<div class='chart-container' style='position: relative; height:40vh; width:80vw'>" +
      " <canvas id= " +
      chartIdSeeder +
      "></canvas>" +
      " </div> ";
    div.innerHTML = chart;
    /*SALARIES*/
    var keys = query.map(function (e) {
      if (e.Subcategory == null) {
        return e.Brand;
      }
      return e.Subcategory;
    });
    var sums = query.map(function (e) {
      return e.Amount;
    });

    const datac = {
      labels: keys,
      datasets: [
        {
          data: sums,
          backgroundColor: [
            "rgba(255, 99, 132, 0.2)",
            "rgba(255, 205, 86, 0.2)",
            "rgba(75, 192, 192, 0.2)",
            "rgba(54, 162, 235, 0.2)",
            "rgba(153, 102, 255, 0.2)",
          ],
          borderColor: [
            "rgb(255, 99, 132)",
            "rgb(255, 205, 86)",
            "rgb(75, 192, 192)",
            "rgb(54, 162, 235)",
            "rgb(153, 102, 255)",
          ],
          borderWidth: 1,
        },
      ],
    };
    // </block:setup>

    // <block:config:0>
    const config = {
      type: "bar",
      data: datac,
      options: {
        plugins: {
          title: {
            display: true,
            text: title,
            font: {
              size: 22,
            },
          },
          legend: {
            display: false,
            onClick: (e) => e.stopPropagation(),
            labels: {
              boxWidth: 0,
              color: "rgb(0, 0, 0)",
            },
          },
        },

        //fit the container
        responsive: true,
        maintainAspectRatio: false,
        scales: {
          y: {
            beginAtZero: true,
            ticks: {
              // Include a dollar sign in the ticks
              callback: function (value, index, values) {
                return value + " items";
              },
            },
          },
        },
      },
    };
    new Chart(document.getElementById(chartIdSeeder), config);
  }

  /**CHANGED CATEGORY **/
  $(document).on("change", "#select-categories", function () {
    var category = $("#select-categories option:selected").val();
    var limit = $("#select-limit option:selected").val();

    //SEND POST
    $.ajax({
      url: "charts/charts_handler.php",
      type: "post",
      data: { top_subs: true, category: category, limit: limit },
      success: function (data) {
        //RECIEVE DATA FROM PHP
        var result = $.parseJSON(data);
        var query = $.parseJSON(result[0]);
        var subs = $.parseJSON(result[1]);

        //CHANGE SUBCATEGORIES
        var $selectSub = $("#select-subcategories");
        $selectSub.empty();
        $("#select-subcategories").empty();
        for (var i = 0; i < subs.length; i++) {
          $selectSub.append(
            "<option " + +"value=" + subs[i] + ">" + subs[i] + "</option>"
          );
        }
        $selectSub.val("");
        var title = "Subcategories Sold Amounts";
        CreateChart(query, title);
        document.getElementById("title").value = title;
      },
    });
  });

  /**CHANGED SUBCATEGORY **/
  $(document).on("change", "#select-subcategories", function () {
    var subcategory = $("#select-subcategories option:selected").val();
    var limit = $("#select-limit option:selected").val();

    //SEND POST
    $.ajax({
      url: "charts/charts_handler.php",
      type: "post",
      data: { top_brands: true, subcategory: subcategory, limit: limit },
      success: function (data) {
        // RECIEVE DATA FROM PHP
        var query = $.parseJSON(data);
        //REPLACE CHART
        var title = "Brands Sold Amounts";
        CreateChart(query, title);
        document.getElementById("title").value = title;
      },
    });
  });

  /**CHANGED LIMIT **/
  $(document).on("change", "#select-limit", function () {
    var category = $("#select-categories option:selected").val();
    var subcategory = "x";
    if ($("#select-subcategories option:selected").val()) {
      subcategory = $("#select-subcategories option:selected").val();
    }
    var limit = $("#select-limit option:selected").val();

    //SEND POST
    $.ajax({
      url: "charts/charts_handler.php",
      type: "post",
      data: {
        limit_change: true,
        category: category,
        subcategory: subcategory,
        limit: limit,
      },
      success: function (data) {
        // RECIEVE DATA FROM PHP
        var query = $.parseJSON(data);
        //REPLACE CHART
        var title = document.getElementById("title").value;
        CreateChart(query, title);
      },
    });
  });
});
