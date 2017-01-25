$(".Background").forEach(function(w) { w.removeFromParent() });
$("#MainLayer")[0].removeCSSClass("Light");

plugins = ["cornerstone.shadereffect", "cornerstone.sparkles"];
ids = ["NebulaBackgroundShaderEffect", "NebulaSparkles"];

[0,1].forEach(function(i) {
  plugin = MultiWidgets.createPlugin(plugins[i]);
  $.app.mainLayer().addChild(plugin);
  plugin.setCSSId(ids[i]);
  plugin.addCSSClass("Background");
})
