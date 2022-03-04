<script>
$(document).ready(function() {

    function numberWithCommas(x) {
    return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
}

var result = <?php echo $revenuePerCategory?>;

var depts = result.map(function(e) {
   return e.Category;
});

var sums = result.map(function(e) {
   return e.Revenue;
});

// <block:setup:1>
const data = {
  labels: depts ,
  datasets: [{
    data: sums,
    backgroundColor: [
     'rgba(255, 99, 132, 0.2)',
      'rgba(255, 205, 86, 0.2)',
      'rgba(75, 192, 192, 0.2)',
      'rgba(54, 162, 235, 0.2)',
      'rgba(153, 102, 255, 0.2)'
    ],
    borderColor: [
      'rgb(255, 99, 132)',
      'rgb(255, 205, 86)',
      'rgb(75, 192, 192)',
      'rgb(54, 162, 235)',
      'rgb(153, 102, 255)'
    ],
    borderWidth: 1,
    

  }]

};
// </block:setup>

// <block:config:0>
const config = {
  type: 'bar',
  data: data,
  options: {
    plugins:{
      title:{
          display: true,
          text: ['Revenue Per Category'],
          font: {
            size: 22
          }
      },
       legend: {
                display: false,
                onClick: (e) => e.stopPropagation(),
                labels: {
                   boxWidth: 0,
                  color: 'rgb(0, 0, 0)',
                }
            }
    },
   
      //fit the container
       responsive:true,
       maintainAspectRatio: false,
        showLine: true,
    scales: {
      y: {
        beginAtZero: true,
        ticks: {
                   // Include a dollar sign in the ticks
                    callback: function(value, index, values) {
                        return '€' + numberWithCommas(value);
                    }
        }
      }
    }
  },
};

  var whPerMonth = new Chart(
    document.getElementById('RevenuePerCategory'),
    config
  );
    
})

</script>