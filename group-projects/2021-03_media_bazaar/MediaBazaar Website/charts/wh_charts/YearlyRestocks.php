<script>
$(document).ready(function() {

  /*WORKED HOURS*/
     var result = <?php echo $yearlyRestocks ?>;
var category = result.map(function(e) {
   return e.Category;
});
var amount = result.map(function(e) {
   return e.Amount;
});


// <block:setup:1>
const data = {
  labels: category,
  datasets: [{
    label: 'My First Dataset',
    data: amount,
    backgroundColor: [
     'rgb(153, 102, 255)',
      'rgb(255, 99, 132)',
      'rgb(54, 162, 235)',
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
          text: ['Yearly Restocks', 'Total: 11, 929 items '],
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


  var yearlyRestocks = new Chart(
    document.getElementById('yearlyRestocks'),
    config
  );
})
</script>