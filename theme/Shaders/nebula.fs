#version 150

layout(std140, column_major) uniform BaseBlock
{
	mat4 projMatrix;
	mat4 modelMatrix;
	vec4 color;
	float depth;
};

uniform float time;
uniform vec2 resolution;

in vec2 fs_vertex_uv;
out vec4 frag_color;


float field(in vec3 p) {
	float strength = 7.;// + .03 * log(1.e-6 + fract(sin(time) * 4373.11));
	float accum = 0.;
	float prev = 0.1;
	float tw = 0.;
	for (int i = 0; i < 20; ++i) {
		float mag = dot(p, p);
		vec3 fieldAnim = 5e-4*vec3(sin(time/8.), sin(time/2.), sin(time/4.));
		p = abs(p) / mag + vec3(-.5, -.4, -1.45)+fieldAnim;
		float w = exp(-float(i) / 7.);
		accum += w * exp(-strength * pow(abs(mag - prev), 0.9));
		tw += w;
		prev = mag;
	}
	return max(0., 5. * accum / tw - .5);
}

float field2(in vec3 p) {
	float strength = 7.;// + .03 * log(1.e-6 + fract(sin(time) * 4373.11));
	float accum = 0.;
	float prev = 0.1;
	float tw = 0.;
	for (int i = 0; i < 17; ++i) {
		float mag = dot(p, p);
		vec3 fieldAnim = 5e-4*vec3(sin(time/8.), sin(time/2.), sin(time/4.));
		p = abs(p) / mag + vec3(-.5, -.4, -1.4)+fieldAnim;
		float w = exp(-float(i) / 7.);
		accum += w * exp(-strength * pow(abs(mag - prev), 1.4));
		tw += w;
		prev = mag;
	}
	return max(0., 5. * accum / tw - .4);
}

void main()
{
	vec2 uv = 2. * fs_vertex_uv - 1.;
	vec2 uvs = uv * resolution.xy / max(resolution.x, resolution.y);

	// Layer 1
	vec3 p1 = vec3(uvs / 4., 0) + vec3(0.8, -1.3, 0.);
	vec3 offset1 = vec3(sin(time / 16.), sin(time / 8.),  sin(time / 128.));
	p1 += (1./16.)*offset1;

	float t1 = field(p1);
	vec4 c1 = vec4(1.9* t1 * t1 * t1, 1.4 * t1 * t1, t1, 1.0);

	// Layer 2
	vec3 p2 = vec3(uvs / 2., 0) + vec3(-.5, -1.3, 0.);
	vec3 offset2 = offset1;
	p2 += (1./8.)*offset2;

	float t2 = field2(p2);
	vec4 c2 = vec4(3.9* t2 * t2 * t2, 1. * t2 * t2, 0.9*t2, 1.0);

	// Combine layers
	frag_color = c1+c2;
}
