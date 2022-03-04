<script>
$(document).ready(function() {
  function average(values) { 
    var total = 0;
for(var i = 0; i < values.length; i++) {
    total += values[i];
}
var  avg = total / values.length;
return avg;
}


  /*SALARIES*/
     var salaries = <?php echo $salaries ?>;
var depts = salaries.map(function(e) {
   return e.Department;
});
var sums = salaries.map(function(e) {
   return e.Average;
});

var avg = average(sums);
avg = String(avg).substr(0,5);
// <block:setup:1>


const data = {
  labels: depts,
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
          text: 'Average Salaries',
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
    scales: {
      y: {
        beginAtZero: true,
        ticks: {
                   // Include a dollar sign in the ticks
                    callback: function(value, index, values) {
                        return '€' + value;
                    }
        }
      }
    }
  },
};

  var salariesChart = new Chart(
    document.getElementById('salariesChart'),
    config
  );
    
})
</script>