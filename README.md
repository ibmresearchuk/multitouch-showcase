# Multi-touch Showcase features.

The following document describes how to create folder structures that will work with the Multitouch 'Showcase' software. Current documentation about this can be found via the link below however a brief guide is contained in this file. 

https://cornerstone.multitouch.fi/sites/default/files/generated-content/application-guide/experience.html

## Top Level Structure

At the top level there must be three folders : 

1. [Configuration](Configuration/README.md)
   Definitions of databases and email sending functionality.
2. Content
   Content displayed by the application (e.g. Images, Videos, Widgets, etc.)
3. Theme
   Theme (looks) of the application
   
### 1. Configuration



##### Menu Text ( via init.js ) 

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



### 3. Theme


