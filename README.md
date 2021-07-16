# ZoomAndPan
Simple ZoomAndPan on Canvas WPF

A simple controler to use in WPF applications;

![N|Solid](https://github.com/xaotix/ZoomAndPan/blob/main/example.png)

`
Compile. Reference the dll and use in your WPF.
`


````xaml
xmlns:zoom="clr-namespace:ZoomAndPanSample;assembly=ZoomAndPan"

<zoom:ZoomAndPanControlView Name="pranchazoom"/>
````

/**/
the canvas to populate is:
````C#
this.pranchazoom.GetCanvas();
````

example:
````C#
this.pranchazoom.GetCanvas().Children.Add(UIObject);
````


Project based on Clifford Nelson code:
An Enhanced WPF Custom Control for Zooming and Panning

https://www.codeproject.com/Articles/1119476/An-Enhanced-WPF-Custom-Control-for-Zooming-and-Pan
