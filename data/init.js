var mainWidget = $("CESAsymmetricMainWidget")[0];

replacements = ["root", "",
                "twitter", "IBM on Twitter",
                "1000", "FHE"
               ];

var data = new Radiant.BinaryData();
replacements.forEach(function (s) {
    data.writeString(s);
});
data.rewind();
mainWidget.eventProcess("word-replacements", data);

/*
Here we can create an additional top level menu for a specific part of the tree.

data = new Radiant.BinaryData();
data.writeVector2Float32($.app.mainLayer().size().toVector().scale(0.7, 0.9));
data.writeString("root/Technology");
data.rewind();
mainWidget.eventProcess("create-teaser", data);
*/

//var video = new MultiWidgets.VideoWidget();
//video.setCSSId("sign");
//$.app.overlayLayer().addChild(video);

//var dvi = MultiWidgets.createPlugin("Experience.DVICaptureMonitor");
//mainWidget.addChild(dvi);
