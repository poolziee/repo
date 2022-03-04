$(document).ready(function () {
  /*GLOBAL CONFIGURATION*/

  //Set interaciton mode
  Chart.defaults.interaction.mode = "nearest";

  // Do not show lines for all datasets by default
  Chart.defaults.datasets.line.showLine = false;

  /*RESPONSIVE DESIGN*/

  //beforeprint
  window.addEventListener("beforeprint", beforePrintHandler());
  window.onbeforeprint = beforePrintHandler();

  //event
  function beforePrintHandler() {
    for (var id in Chart.instances) {
      Chart.instances[id].resize();
    }
  }

  //afterprint
  window.addEventListener("beforeprint", () => {
    myChart.resize(600, 600);
  });
  window.addEventListener("afterprint", () => {
    myChart.resize();
  });
});
