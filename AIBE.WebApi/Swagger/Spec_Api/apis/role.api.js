window.roleApi = {
  paths: {
    "/roles": {
      get: {
        tags: ["Role"],
        summary: "Danh sách role",
        responses: {
          200: {
            description: "OK",
            content: {
              "application/json": {
                schema: {
                  type: "array",
                  items: { $ref: "#/components/schemas/Role" }
                }
              }
            }
          }
        }
      },
      post: {
        tags: ["Role"],
        summary: "Tạo role",
        requestBody: {
          required: true,
          content: {
            "application/json": {
              schema: { $ref: "#/components/schemas/RoleCreate" }
            }
          }
        },
        responses: {
          201: { description: "Created" }
        }
      }
    },

    "/roles/{id}": {
      put: {
        tags: ["Role"],
        summary: "Cập nhật role",
        parameters: [
          {
            name: "id",
            in: "path",
            required: true,
            schema: { type: "integer" }
          }
        ],
        requestBody: {
          required: true,
          content: {
            "application/json": {
              schema: { $ref: "#/components/schemas/RoleCreate" }
            }
          }
        },
        responses: {
          200: { description: "Updated" }
        }
      },
      delete: {
        tags: ["Role"],
        summary: "Xóa role",
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
      Role: {
        type: "object",
        properties: {
          roleId: { type: "integer" },
          roleName: { type: "string" },
          description: { type: "string" },
          createdAt: { type: "string", format: "date-time" }
        }
      },
      RoleCreate: {
        type: "object",
        required: ["roleName"],
        properties: {
          roleName: { type: "string" },
          description: { type: "string" }
        }
      }
    }
  }
};
