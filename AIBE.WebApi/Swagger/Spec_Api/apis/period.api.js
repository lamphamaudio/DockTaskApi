window.periodApi = {
  paths: {
    "/periods": {
      get: {
        tags: ["Period"],
        summary: "Danh sách kỳ báo cáo",
        responses: {
          200: {
            description: "OK",
            content: {
              "application/json": {
                schema: {
                  type: "array",
                  items: { $ref: "#/components/schemas/Period" }
                }
              }
            }
          }
        }
      },
      post: {
        tags: ["Period"],
        summary: "Tạo kỳ báo cáo",
        requestBody: {
          required: true,
          content: {
            "application/json": {
              schema: { $ref: "#/components/schemas/PeriodCreate" }
            }
          }
        },
        responses: { 201: { description: "Created" } }
      }
    },

    "/periods/{id}": {
      put: {
        tags: ["Period"],
        summary: "Cập nhật kỳ báo cáo",
        parameters: [
          { name: "id", in: "path", required: true, schema: { type: "integer" } }
        ],
        requestBody: {
          required: true,
          content: {
            "application/json": {
              schema: { $ref: "#/components/schemas/PeriodCreate" }
            }
          }
        },
        responses: { 200: { description: "Updated" } }
      },
      delete: {
        tags: ["Period"],
        summary: "Xóa kỳ báo cáo",
        parameters: [
          { name: "id", in: "path", required: true, schema: { type: "integer" } }
        ],
        responses: { 204: { description: "Deleted" } }
      }
    }
  },

  components: {
    schemas: {
      Period: {
        type: "object",
        properties: {
          periodId: { type: "integer" },
          periodName: { type: "string" },
          frequencyId: { type: "integer" },
          startDate: { type: "string", format: "date" },
          endDate: { type: "string", format: "date" },
          createdAt: { type: "string", format: "date-time" }
        }
      },
      PeriodCreate: {
        type: "object",
        required: ["periodName", "startDate", "endDate"],
        properties: {
          periodName: { type: "string" },
          frequencyId: { type: "integer" },
          startDate: { type: "string", format: "date" },
          endDate: { type: "string", format: "date" }
        }
      }
    }
  }
};