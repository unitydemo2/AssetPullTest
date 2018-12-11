# Scriptable Brushes

The [GridBrushBase](ScriptRef:GridBrushBase.html) class has methods that you can override to handle changes in Z position. This allows you to have custom behaviours for your customised Scriptables Brushes. These methods are:

public virtual void [ChangeZPosition(int change)](ScriptRef:GridBrushBase.html):
<br/>Changes the Z Position of the Brush. The  `change` argument is the amount that is changed by using the Hotkeys or the Z Position Inspector. 

public virtual void [ResetZPosition()](ScriptRef:GridBrushBase.html):
<br/>Resets the Z Position of the Brush. You define what value to reset the Z Position to.

---


* <span class="page-history">Isometric Tilemaps added in [2018.3](https://docs.unity3d.com/2018.3/Documentation/Manual/30_search.html?q=newin20183) <span class="search-words">NewIn20183</span></span>
