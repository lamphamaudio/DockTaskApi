window.unituserApi = {
  paths: {
    "/unitusers": {
      get: {
        tags: ["UnitUser"],
        summary: "Danh sách liên kết user-unit",
        responses: {
          200: {
            description: "Danh sách",
            content: {
              "application/json": {
                schema: {
                  type: "array",
                  items: { $ref: "#/components/schemas/UnitUser" }
                }
              }
            }
          }
        }
      },
      post: {
        tags: ["UnitUser"],
        summary: "Tạo liên kết user-unit",
        requestBody: {
          required: true,
          content: {
            "application/json": {
              schema: { $ref: "#/components/schemas/UnitUserCreate" }
            }
          }
        },
        responses: {
          201: { description: "Created" }
        }
      }
    },

    "/unitusers/{id}": {
      delete: {
        tags: ["UnitUser"],
        summary: "Xóa liên kết",
        parameters: [
          {
            name: "id",
            in: "path",
            required: true,
            schema: { type: "integer" }
          }
        ],
        responses: {
          204: { description: "Deleted" }
        }
      }
    }
  },

  components: {
    schemas: {
      UnitUser: {
        type: "object",
        properties: {
          unitUserId: { type: "integer" },
          userId: { type: "integer" },
          unitId: { type: "integer" },
          type: { type: "string" },
          positionId: { type: "integer" },
          createdAt: { type: "string", format: "date-time" }
        }
      },
      UnitUserCreate: {
        type: "object",
        required: ["userId", "unitId"],
        properties: {
          userId: { type: "integer" },
          unitId: { type: "integer" },
          type: { type: "string", enum: ["official", "virtual"] },
          positionId: { type: "integer" }
        }
      }
    }
  }
};
