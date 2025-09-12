window.frequencyApi = {
  paths: {
    "/frequencies": {
      get: {
        tags: ["Frequency"],
        summary: "Danh sách tần suất",
        responses: {
          200: {
            description: "OK",
            content: {
              "application/json": {
                schema: {
                  type: "array",
                  items: { $ref: "#/components/schemas/Frequency" }
                }
              }
            }
          }
        }
      },
      post: {
        tags: ["Frequency"],
        summary: "Tạo tần suất",
        requestBody: {
          required: true,
          content: {
            "application/json": {
              schema: { $ref: "#/components/schemas/FrequencyCreate" }
            }
          }
        },
        responses: { 201: { description: "Created" } }
      }
    },

    "/frequencies/{id}": {
      put: {
        tags: ["Frequency"],
        summary: "Cập nhật tần suất",
        parameters: [
          { name: "id", in: "path", required: true, schema: { type: "integer" } }
        ],
        requestBody: {
          required: true,
          content: {
            "application/json": {
              schema: { $ref: "#/components/schemas/FrequencyCreate" }
            }
          }
        },
        responses: { 200: { description: "Updated" } }
      },
      delete: {
        tags: ["Frequency"],
        summary: "Xóa tần suất",
        parameters: [
          { name: "id", in: "path", required: true, schema: { type: "integer" } }
        ],
        responses: { 204: { description: "Deleted" } }
      }
    }
  },

  components: {
    schemas: {
      Frequency: {
        type: "object",
        properties: {
          id: { type: "integer" },
          frequencyType: {
            type: "string",
            enum: ["daily", "weekly", "monthly", "quarter", "custom"]
          },
          frequencyDetail: { type: "string" },
          intervalValue: { type: "integer" },
          taskId: { type: "integer" },
          createdAt: { type: "string", format: "date-time" }
        }
      },
      FrequencyCreate: {
        type: "object",
        required: ["frequencyType", "intervalValue"],
        properties: {
          frequencyType: {
            type: "string",
            enum: ["daily", "weekly", "monthly", "quarter", "custom"]
          },
          frequencyDetail: { type: "string" },
          intervalValue: { type: "integer" },
          taskId: { type: "integer" }
        }
      }
    }
  }
};
