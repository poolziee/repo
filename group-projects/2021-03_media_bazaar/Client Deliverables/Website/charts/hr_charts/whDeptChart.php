<script>
$(document).ready(function() {

  /*WORKED HOURS*/
     var result = <?php echo $hrsPerDeptY ?>;
var depts = result.map(function(e) {
   return e.Department;
});
var hours = result.map(function(e) {
   return e.Hours;
});

// <block:setup:1>
const data = {
  labels: depts,
  datasets: [{
    label: 'My First Dataset',
    data: hours,
    backgroundColor: [
     'rgb(255, 99, 132)',
      'rgb(255, 205, 86)',
      'rgb(75, 192, 192)',
      'rgb(54, 162, 235)',
      'rgb(153, 102, 255)'
    ],
    hoverOffset: 4
  }]
};
// </block:setup>

// <block:config:0>
const config = {
  type: 'pie',
  data: data,
  options:{
      //fit the container
       responsive:true,
       maintainAspectRatio: false,
       plugins:{
            title:{
          display: true,
          text: 'Yearly Worked Hours',
          font: {
            size: 22
          }
      },
       labels: {
      position: 'outside',
      render: (args) => {
        return `${args.label}: ${args.value}%`;
      }
    },

       }
  }
};


  var whDeptChart = new Chart(
    document.getElementById('whDeptChart'),
    config
  );
    
})
</script>