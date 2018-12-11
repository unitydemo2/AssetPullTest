#AssetBundle run-time recompression

The [AssetBundle.RecompressAssetBundleAsync](ScriptRef:AssetBundle.RecompressAssetBundleAsync.html) API enables you to convert an AssetBundle from one compression method to a different compression method at run time. Any AssetBundle can be recompressed. Unity supports the [BuildCompression.UncompressedRuntime](ScriptRef:BuildCompression.UncompressedRuntime.html) and [BuildCompression.LZ4Runtime](ScriptRef:BuildCompression.LZ4Runtime.html) compression methods as targets.

Use this API when you’ve published an application with LZMA compressed AssetBundles instead of using the AssetBundle Cache (which recompresses to LZ4 automatically). Using LZMA compressed AssetBundles often leads to high memory pressure and/or significant overhead when loading single files from AssetBundles at run time. Allowing AssetBundles to be recompressed at run time to use the LZ4 compression method significantly reduces memory pressure and improves loading time when you need to load a small number of Assets from a bundle. This is because the LZ4 algorithm compresses Assets in your Bundle individually, so that it can retrieve and decompress them separately as needed. The downside of using LZ4 is that it increases bundle size on disk.

Compressing content using LZMA then recompressing it to use LZ4 at run time means that you can cut down on your application’s download size, reducing your Content Delivery Network price.


* <span class="page-edit">2018-09-06 <!-- include IncludeTextNewPageYesEdit --></span>

* <span class="page-history">Added AssetBundle run-time recompression API in 2018.3</span>
