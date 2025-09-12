window.unitApi = {
  paths: {
    "/units": {
      get: {
        tags: ["Unit"],
        summary: "Lấy danh sách đơn vị",
        responses: {
          200: {
            description: "Danh sách unit",
            content: {
              "application/json": {
                schema: {
                  type: "array",
                  items: { $ref: "#/components/schemas/Unit" }
                }
              }
            }
          }
        }
      },
      post: {
        tags: ["Unit"],
        summary: "Tạo đơn vị",
        requestBody: {
          required: true,
          content: {
            "application/json": {
              schema: { $ref: "#/components/schemas/UnitCreate" }
            }
          }
        },
        responses: {
          201: { description: "Tạo unit thành công" }
        }
      }
    },

    "/units/{unitId}": {
      put: {
        tags: ["Unit"],
        summary: "Cập nhật unit",
        parameters: [
          {
            name: "unitId",
            in: "path",
            required: true,
            schema: { type: "integer" }
          }
        ],
        requestBody: {
          required: true,
          content: {
            "application/json": {
              schema: { $ref: "#/components/schemas/UnitCreate" }
            }
          }
        },
        responses: {
          200: { description: "Cập nhật thành công" }
        }
      },
      delete: {
        tags: ["Unit"],
        summary: "Xóa unit",
        parameters: [
          {
            name: "unitId",
            in: "path",
            required: true,
            schema: { type: "integer" }
          }
        ],
        responses: {
          204: { description: "Xóa thành công" }
        }
      }
    },

    "/units/{unitId}/users": {
      post: {
        tags: ["Unit"],
        summary: "Gán user vào đơn vị",
        parameters: [
          {
            name: "unitId",
            in: "path",
            required: true,
            schema: { type: "integer" }
          }
        ],
        requestBody: {
          required: true,
          content: {
            "application/json": {
              schema: { $ref: "#/components/schemas/UnitUserCreate" }
            }
          }
        },
        responses: {
          201: { description: "Đã gán user" }
        }
      }
    },

    "/units/{unitId}/users/{userId}": {
      delete: {
        tags: ["Unit"],
        summary: "Xóa user khỏi đơn vị",
        parameters: [
          {
            name: "unitId",
            in: "path",
            required: true,
            schema: { type: "integer" }
          },
          {
            name: "userId",
            in: "path",
            required: true,
            schema: { type: "integer" }
          }
        ],
        responses: {
          204: { description: "Đã xóa" }
        }
      }
    }
  },

  components: {
    schemas: {
      Unit: {
        type: "object",
        properties: {
          unitId: { type: "integer" },
          orgId: { type: "integer" },
          unitName: { type: "string" },
          type: { type: "string" },
          unitParent: { type: "integer" },
          userId: { type: "integer" }
        }
      },
      UnitCreate: {
        type: "object",
        required: ["unitName", "orgId"],
        properties: {
          orgId: { type: "integer" },
          unitName: { type: "string" },
          type: { type: "string" },
          unitParent: { type: "integer" },
          userId: { type: "integer" }
        }
      },
      UnitUserCreate: {
        type: "object",
        required: ["userId"],
        properties: {
          userId: { type: "integer" },
          type: { type: "string", enum: ["official", "virtual"] },
          positionId: { type: "integer" }
        }
      }
    }
  }
};
