<script>
$(document).ready(function() {

    function numberWithCommas(x) {
    return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
}

    var result = <?php echo $marketSpendingPerMonth?>;

var total = 1834685;
var sums = result.map(function(e) {
   return e.MarketSpending;
});

// <block:setup:1>
const data = {
  labels: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"] ,
  datasets: [{
    data: sums,
    backgroundColor: [
      'rgba(153, 102, 255, 0.2)'
    ],
    borderColor: [
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
          text: ['Restock Expenses', 'Total: €' +numberWithCommas(total)],
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
    document.getElementById('MarketSpendingPerMonth'),
    config
  );
    
})

</script>