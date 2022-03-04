
<script>
$(document).ready(function() {
    

var revenue = <?php echo $revenuePerMonth?>;
var expenses = <?php echo $totalSpendingPerMonth?>;

function GetProfit(){
var profit = [];
for(i = 0; i <= 12;i++){
var rev = revenue[i][i];
var exp = expeneses[i][i];
 profit.push({i : (revenue.Revenue[i] - expenses[i].TotalSpending)});
}
return profit;
}


    function numberWithCommas(x) {
    return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
}

    var result = GetProfit();
   var sums = result.map(function(e) {
   return e.key;
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
  type: 'line',
  data: data,
  options: {
    plugins:{
      title:{
          display: true,
          text: ['Profit ', 'Total: €' ],
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
    document.getElementById('ProfitPerMonth'),
    config
  );
    
})

</script>