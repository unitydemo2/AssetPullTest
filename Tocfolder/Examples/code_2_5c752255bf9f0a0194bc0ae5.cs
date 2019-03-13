@Code 
&lt; and &gt;
Dim db = Database.Open("SmallBakery") 
Dim query = "SELECT * FROM Product" 
Dim data = db.Query(query) 
Dim grid = new WebGrid(data) 
End Code
<html> 
<head> 
<title>Displaying Data Using the WebGrid Helper</title> 
</head> 
<body> 
<h1>Small Bakery Products</h1> 
<div id="grid"> 
@grid.GetHtml()
</div> 
</body> 
</html>

@Code 
Dim myChart as new Chart(600,400)
Dim xarr(4)
xarr(0)="Peter"
xarr(1)="Andrew"
xarr(2)="Julie"
xarr(3)="Mary"
xarr(4)="Dave"
Dim yarr(4)
yarr(0)="2"
yarr(1)="6"
yarr(2)="4"
yarr(3)="5"
yarr(4)="3"
myChart.AddTitle("Employees") 
myChart.AddSeries("Employees","column",,,,,xarr,,yarr,,) 
myChart.Write()
End Code