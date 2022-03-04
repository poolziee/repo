<script>
$(document).ready(function() {

var result = <?php echo $hrsPerDeptM ?>;
     function GetHours(dept){
       var hours = [];
    for(var i = 0; i < result.length; i++) {
       var obj = result[i];
       var count = 0;
       if(obj.Department == dept){
        hours.push(obj.Hours);
       }
    }
    return hours;
}

// <block:setup:1>
const labels = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];
const data = {
  labels: labels,
  datasets: [
    {
      label: "Cashier",
      data: GetHours("Cashier"),
      fill: false,
      backgroundColor: 'rgba(255, 99, 132, 0.2)',
      borderColor: 'rgb(255, 99, 132)',
      tension: 0.1,
      borderWidth: 1
    },
    {
     label: "SalesAssistant",
      data: GetHours("SalesAssistant"),
      fill: false,
       backgroundColor: 'rgba(255, 205, 86, 0.2)',
      borderColor: "rgb(255, 205, 86)",
      tension: 0.1,
      borderWidth: 1
    },

    {
     label: "Security",
      data: GetHours("Security"),
      fill: false,
      backgroundColor: 'rgba(75, 192, 192, 0.2)',
      borderColor: "rgb(75, 192, 192)",
      tension: 0.1,
      borderWidth: 1
    },
    {
     label: "Stocker",
      data: GetHours("Stocker"),
      fill: false,
      backgroundColor: 'rgba(54, 162, 235, 0.2)',
      borderColor: "rgb(54, 162, 235)",
      tension: 0.1,
      borderWidth: 1
    },
    {
     label: "WarehouseManager",
      data: GetHours("WarehouseManager"),
      fill: false,
      backgroundColor: 'rgba(153, 102, 255, 0.2)',
      borderColor: "rgb(153, 102, 255)",
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
          text: 'Monthly Worked Hours Per Department',
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
                        return value + ' hrs.';
                    }
        }
      }
    }
  },
};


  var whDeptChartM = new Chart(
    document.getElementById('whDeptChartM'),
    config
  );
    
})
</script>