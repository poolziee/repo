<script>
$(document).ready(function() {

  /*WORKED HOURS*/
     var result = <?php echo $whPerMonth ?>;
var months = result.map(function(e) {
   return e.Department;
});
var hours = result.map(function(e) {
   return e.Hours;
});

// <block:setup:1>
const data = {
  labels: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"] ,
  datasets: [{
    data: hours,
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
          text: 'Total Monthly Worked Hours',
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
                        return value + ' hrs.';
                    }
        }
      }
    }
  },
};

  var whPerMonth = new Chart(
    document.getElementById('whPerMonth'),
    config
  );
    
})
</script>