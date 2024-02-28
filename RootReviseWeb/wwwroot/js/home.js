document.addEventListener("DOMContentLoaded", function () {
   // Access data attributes
   var highPrt = document.getElementById('test').getAttribute('data-high');
   var openIssues = document.getElementById('issueBarChart').getAttribute('data-open-issues');

   // Prepare your data
   var data = [
      { name: "Open Issues", value: openIssues },
      { name: "High Priority Issues", value: highPrt }
   ];

   // Set dimensions and margins for the graph
   var width = 550,
      height = 300,
      margin = { top: 20, right: 30, bottom: 40, left: 200 };

   // Append the svg object to the div
   var svg = d3.select("#issueBarChart")
      .append("svg")
      .attr("width", width + margin.left + margin.right)
      .attr("height", height + margin.top + margin.bottom)
      .append("g")
      .attr("transform",
         "translate(" + margin.left + "," + margin.top + ")");

   // X axis
   var x = d3.scaleLinear()
      .domain([0, Math.max(openIssues, highPrt)])
      .range([0, width - 150]);

   const maxIssueCount = Math.max(openIssues, highPrt);
   const tickValues = Array.from({ length: maxIssueCount + 1 }, (_, i) => i);

   svg.append("g")
      .attr("transform", "translate(0," + height + ")")
      .call(d3.axisBottom(x).tickValues(tickValues).tickFormat(d3.format('d')))
      .selectAll("text")
      .style("text-anchor", "end");

   // Y axis
   var y = d3.scaleBand()
      .range([0, height])
      .domain(data.map(function (d) { return d.name; }))
      .padding(.1);

   svg.append("g")
      .call(d3.axisLeft(y))

   // Bars
   svg.selectAll("myRect")
      .data(data)
      .enter()
      .append("rect")
      .attr("x", x(0))
      .attr("y", function (d) { return y(d.name); })
      .attr("width", function (d) { return x(d.value); })
      .attr("height", y.bandwidth())
      .attr("fill", "#69b3a2");
})