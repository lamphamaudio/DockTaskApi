window.progressApi = {
  paths: {
    "/tasks/{taskId}/progress": {
      get: {
        tags: ["Progress"],
        summary: "Lấy tiến độ task",
        parameters: [
          { name: "taskId", in: "path", required: true, schema: { type: "integer" } }
        ],
        responses: {
          200: {
            description: "OK",
            content: {
              "application/json": {
                schema: {
                  type: "array",
                  items: { $ref: "#/components/schemas/Progress" }
                }
              }
            }
          }
        }
      },
      post: {
        tags: ["Progress"],
        summary: "Tạo báo cáo tiến độ",
        parameters: [
          { name: "taskId", in: "path", required: true, schema: { type: "integer" } }
        ],
        requestBody: {
          required: true,
          content: {
            "application/json": {
              schema: { $ref: "#/components/schemas/ProgressCreate" }
            }
          }
        },
        responses: {
          201: {
            description: "Created",
            content: {
              "application/json": { schema: { $ref: "#/components/schemas/Progress" } }
            }
          }
        }
      }
    },

    "/progress/{progressId}": {
      put: {
        tags: ["Progress"],
        summary: "Sửa báo cáo",
        parameters: [
          { name: "progressId", in: "path", required: true, schema: { type: "integer" } }
        ],
        requestBody: {
          required: true,
          content: {
            "application/json": {
              schema: { $ref: "#/components/schemas/ProgressUpdate" }
            }
          }
        },
        responses: { 200: { description: "Updated" } }
      }
    }
  },

  components: {
    schemas: {
      Progress: {
        type: "object",
        properties: {
          progressId: { type: "integer" },
          taskId: { type: "integer" },
          periodId: { type: "integer" },
          percentageComplete: { type: "integer" },
          comment: { type: "string" },
          status: { type: "string", enum: ["not_started", "in_progress", "completed"] },
          updatedBy: { type: "integer" },
          updatedAt: { type: "string", format: "date-time" }
        }
      },
      ProgressCreate: {
        type: "object",
        required: ["percentageComplete"],
        properties: {
          periodId: { type: "integer" },
          percentageComplete: { type: "integer" },
          comment: { type: "string" },
          status: { type: "string", enum: ["not_started", "in_progress", "completed"] },
          updatedBy: { type: "integer" }
        }
      },
      ProgressUpdate: {
        type: "object",
        properties: {
          percentageComplete: { type: "integer" },
          comment: { type: "string" },
          status: { type: "string", enum: ["not_started", "in_progress", "completed"] }
        }
      }
    }
  }
};