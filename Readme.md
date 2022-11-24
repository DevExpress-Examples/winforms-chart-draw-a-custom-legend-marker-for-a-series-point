<!-- default badges list -->
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T332652)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# Chart for WinForms - Draw a Custom Legend Marker for a Series Point

This example demonstrates how to use the `CustomDrawSeriesPoint` event to modify the legend markers of nested donut series points.

![Chart](./image/Chart.png)

<h3>Description</h3>

<p>A custom legend marker is set to the&nbsp;<a href="https://documentation.devexpress.com/#CoreLibraries/DevExpressXtraChartsCustomDrawSeriesEventArgs_LegendMarkerImagetopic">e.LegendMarkerImage</a>&nbsp;property. Note that in this case the&nbsp;<a href="https://documentation.devexpress.com/#CoreLibraries/DevExpressXtraChartsCustomDrawSeriesEventArgs_DisposeLegendMarkerImagetopic">e.DisposeLegendMarkerImage</a>&nbsp;property should be set to true to avoid memory leaks.<br>To customize options used to draw the series point, cast <a href="https://documentation.devexpress.com/#CoreLibraries/DevExpressXtraChartsCustomDrawSeriesEventArgs_SeriesDrawOptionstopic">e.SeriesDrawOptions</a>&nbsp;to the&nbsp;<a href="https://documentation.devexpress.com/#CoreLibraries/clsDevExpressXtraChartsDrawOptionstopic">DrawOptions&nbsp;</a>class descendant that stores draw options of the required series view type.</p>

<br/>

## Files to Review 

* **[Form1.cs](./CS/CustomSeriesPointDrawingSample/Form1.cs) (VB: [Form1.vb](./VB/CustomSeriesPointDrawingSample/Form1.vb))**
* [Employee.cs](./CS/CustomSeriesPointDrawingSample/Model/Employee.cs) (VB: [Employee.vb](./VB/CustomSeriesPointDrawingSample/Model/Employee.vb))
* [NwindDbContext.cs](./CS/CustomSeriesPointDrawingSample/Model/NwindDbContext.cs) (VB: [NwindDbContext.vb](./VB/CustomSeriesPointDrawingSample/Model/NwindDbContext.vb))
* [Order.cs](./CS/CustomSeriesPointDrawingSample/Model/Order.cs) (VB: [Order.vb](./VB/CustomSeriesPointDrawingSample/Model/Order.vb))

