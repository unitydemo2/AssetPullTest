 

# Leave Feedback 

 The Audio Chorus Filter takes an Audio Clip and processes it creating a chorus effect. 

 A container for audio data. 

# The Audio Distortion Filter distorts the sound from an AudioSource or sounds reaching the AudioListener. 

 The Audio Echo Filter repeats a sound after a given Delay, attenuating the repetitions based on the Decay Ratio. 

 When Unity imports Model files that contain Humanoid Rigs and Animation, it needs to reconcile the bone structure of the Model to its Animation. It does this by mapping each bone in the file to a Humanoid Avatar so that it can play the Animation properly. For this reason, it is important to carefully prepare your Model file before importing into Unity. 

 Image1 

 &lt;dw-image&gt;5c680fcc6e886302f08b4456&lt;/dw-image&gt; 

 image2 

 &lt;dw-image&gt;5c53f98ae65ffa27d8d3ca5d&lt;/dw-image&gt; 

 Code block1 

 &lt;dw-code&gt;5c5a8713f671f31a643c7c86&lt;/dw-code&gt; 

 link1 

 &lt;dw-link&gt;project/5c680f8ff376b515d4ed62ac/distribution/5c680fadf376b515d4ed62d5/document/5c680fc7f376b515d4ed62ff&lt;/dw-link&gt; 

 This is new line 

 

 ```
using UnityEngine.Purchasing;public class MyStore : IStoreListener{    public void InitializeStore()    {        var module = StandardPurchasingModule.Instance();        var builder = ConfigurationBuilder.Instance(module);        // Configure CloudMoolah        builder.Configure&lt;IMoolahConfiguration&gt;().appKey = &quot;d93f4564c41d463ed3d3cd207594ee1b&quot;;        builder.Configure&lt;IMoolahConfiguration&gt;().hashKey = &quot;cc&quot;;        // For server-to-server (also called &quot;online&quot; games) transaction        // logging, set IMoolahConfiguration.notificationURL.        builder.Configure&lt;IMoolahConfiguration&gt;().notificationURL = &quot;https://gameserver.example.com/callback&quot;;        builder.Configure&lt;IMoolahConfiguration&gt;().SetMode(CloudMoolahMode.Production);        // Add purchasable products. The product must be defined in the store.        // Unity IAP provides the *ProductType* enumeration to specify the durability         // of a purchasable product. CloudMoolah limits the product type to Consumable.         builder.AddProduct(&quot;100.gold.coins&quot;, ProductType.Consumable);        // Start asynchronous IAP initialization.        UnityPurchasing.Initialize(this, builder);    }}
```