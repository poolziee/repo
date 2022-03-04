<script>
$(document).ready(function() {

var result = <?php echo $monthlySales ?>;

     function GetAmount(cat){
       var amount = [];
    for(var i = 0; i < result.length; i++) {
       var obj = result[i];
       var count = 0;
       if(obj.Category == cat){
        amount.push(obj.Amount);
       }
    }
    return amount;
}

// <block:setup:1>
const labels = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];
const data = {
  labels: labels,
  datasets: [
       {
     label: "Accessories",
      data: GetAmount("Accessories"),
      fill: false,
      backgroundColor: 'rgba(153, 102, 255, 0.2)',
      borderColor: "rgb(153, 102, 255)",
      tension: 0.1,
      borderWidth: 1
    },
    {
      label: "Electronics",
      data: GetAmount("Electronics"),
      fill: false,
      backgroundColor: 'rgba(255, 99, 132, 0.2)',
      borderColor: 'rgb(255, 99, 132)',
      tension: 0.1,
      borderWidth: 1
    },
    {
     label: "Furniture",
      data: GetAmount("Furniture"),
      fill: false,
      backgroundColor: 'rgba(54, 162, 235, 0.2)',
      borderColor: "rgb(54, 162, 235)",
      tension: 0.1,
      borderWidth: 1
    },
  ],
};

// <block:config:0>
const config = {
  type: "bar",
  data: data,
  options: {
    plugins:{
      title:{
          display: true,
          text: 'Monthly Sales Per Category',
          font: {
            size: 22
          }
      },
    },
    //fit the container
    responsive: true,
    maintainAspectRatio: false,
    showLine: true,
    scales: {
      y: {
        beginAtZero: true,
        ticks: {
                   // Include a dollar sign in the ticks
                    callback: function(value, index, values) {
                        return value + ' items';
                    }
        }
      }
    }
  },
};


  var whDeptChartM = new Chart(
    document.getElementById('monthlySales'),
    config
  );
    
})
</script>