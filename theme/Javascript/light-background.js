$(".Background").forEach(function(w) { w.removeFromParent() });
$("#MainLayer")[0].addCSSClass("Light");

/* Create shadereffect and champagne */
plugins = ["cornerstone.shadereffect", "cornerstone.champagne"];
ids = ["LightBackgroundShaderEffect", "LightBackgroundChampagne"];

[0,1].forEach(function(i) {
  plugin = MultiWidgets.createPlugin(plugins[i]);
  $.app.mainLayer().addChild(plugin);
  plugin.setCSSId(ids[i]);
  plugin.addCSSClass("Background");
})
