// load các api.js (index.html phải import trước)
const spec = {
  openapi: "3.0.0",
  info: {
    title: "Doctask API",
    version: "1.0.0",
    description: "API cho hệ thống Doctask"
  },
  servers: [{ url: "http://localhost:8080/api/v1" }],
  paths: {
    ...authApi.paths,
    ...userApi.paths,
    ...orgApi.paths,
    ...unitApi.paths,
    ...frequencyApi.paths,
    ...taskApi.paths,
    ...progressApi.paths,
    ...taskunitassignmentApi.paths,
    ...roleApi.paths,
    ...periodApi.paths,
    ...uploadfileApi.paths,
    ...reportSummaryApi.paths,
  },
  components: {
    schemas: {
      ...authApi.components.schemas,
      ...userApi.components.schemas,
      ...orgApi.components.schemas,
      ...unitApi.components.schemas,
      ...frequencyApi.components.schemas,
      ...taskApi.components.schemas,
      ...progressApi.components.schemas,
      ...taskunitassignmentApi.components.schemas,
      ...roleApi.components.schemas,
      ...periodApi.components.schemas,
      ...uploadfileApi.components.schemas,
      ...reportSummaryApi.components.schemas,
    },
    securitySchemes: {
      bearerAuth: {
        type: "http",
        scheme: "bearer",
        bearerFormat: "JWT"
      }
    }
  },
  security: [{ bearerAuth: [] }]
};

window.onload = function () {
  window.ui = SwaggerUIBundle({
    spec: spec,
    dom_id: '#swagger-ui',
    deepLinking: true,
    presets: [SwaggerUIBundle.presets.apis, SwaggerUIStandalonePreset],
    plugins: [SwaggerUIBundle.plugins.DownloadUrl],
    layout: "StandaloneLayout"
  });
};
