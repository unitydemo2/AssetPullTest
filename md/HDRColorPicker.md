# HDR color picker

The HDR Color picker looks similar to the ordinary [Color picker](PresetLibraries), but it contains additional controls for adjusting the color’s exposure.

![](../uploads/Main/HDRColorPicker1.png) 

|**Property:** |**Function:** |
|:---|:---|
|Mode <br/>(default: __RGB 0-255__)| When using __HSV__ or __RGB 0-255__ mode, the color picker treats exposure adjustments independently from color channel data. However, the color channel data displayed in __RBG (0-1.0)__ mode reflects the results of your exposure adjustment on the color data. <br/> Unlike the ordinary color picker, you can directly enter float values greater than 1.0 when editing color channels in __RGB 0-1.0__ mode. In this case, the color picker derives the __Intensity__ value automatically from the value you set. |
|__RGBA__| Use the slider or text box to define a RGBA value. The __Hexadecimal__ value automatically updates to reflect the RGBA values. |
|__Hexadecimal__ | Use the text box to define a hexadecimal value. The __RGBA__ values automatically update to reflect the hexadecimal value. |
|__Intensity__ | Use the __Intensity__ slider to overexpose or underexpose the color. Each positive step along the slider provides twice as much light as the previous slider position, and each negative step provides half as much light. |
|Swatches | Use the exposure swatches under the __Intensity__ slider to preview what the current color value looks like within a range of two steps in either direction. To quickly adjust the color’s exposure, click a preview swatch. |

Whenever you close the HDR Color window and reopen it, the window derives the color channel and intensity values from the color you are editing. Because of this, you might see slightly different values for the color channels in __HSV__ and __RGB 0-255__ mode or for the Intensity slider, even though the color channel values in __RGB 0-1.0__ mode are the same as the last time you edited the color.

----
* <span class="page-edit">2018-07-27 <!-- include IncludeTextAmendPageYesEdit --></span>

* <span class="page-history">HDR color picker updated in 2018.1</span>