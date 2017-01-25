$(".Background").forEach(function(w) { w.removeFromParent() });
$("#MainLayer")[0].removeCSSClass("Light");

/* Create shadereffect and champagne */
plugins = ["experience.AwesomeBlue", "cornerstone.champagne"];
ids = ["DarkBackgroundShaderEffect", "DarkBackgroundChampagne"];

[0,1].forEach(function(i) {
  plugin = MultiWidgets.createPlugin(plugins[i]);
  $.app.mainLayer().addChild(plugin);
  plugin.setCSSId(ids[i]);
  plugin.addCSSClass("Background");
})
