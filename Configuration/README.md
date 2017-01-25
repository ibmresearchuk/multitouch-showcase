## 1. Configuration

### Menu Text ( via init.js ) 

By default, the text shown below each icon is the folder name or filename of the content in question. This can be changed using word replacements. The replacements are setup in the init.js file:

```javascript 
var mainWidget = $("CESAsymmetricMainWidget")[0];
var replacements = ["root", "",
                    "tactionmodel", "MultiTaction 3D model",
                    "input visualizer", "Input Visualizer"];
var data = new Radiant.BinaryData();
replacements.forEach(function(s) { data.writeString(s); });
data.rewind();
mainWidget.eventProcess("word-replacements", data);
```

In the code above, the array replacements contains pairs of strings. For example, "root" is replaced by an empty string, "tactionmodel" will be replaced by "MultiTaction 3D Model", etc.

