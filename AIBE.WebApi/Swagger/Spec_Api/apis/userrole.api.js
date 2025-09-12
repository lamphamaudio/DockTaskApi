window.userroleApi = {
  paths: {
    "/userroles": {
      get: {
        tags: ["UserRole"],
        summary: "Danh sách user-role",
        responses: {
          200: {
            description: "OK",
            content: {
              "application/json": {
                schema: {
                  type: "array",
                  items: { $ref: "#/components/schemas/UserRole" }
                }
              }
            }
          }
        }
      },
      post: {
        tags: ["UserRole"],
        summary: "Gán role cho user",
        requestBody: {
          required: true,
          content: {
            "application/json": {
              schema: { $ref: "#/components/schemas/UserRoleCreate" }
            }
          }
        },
        responses: {
          201: { description: "Created" }
        }
      }
    },

    "/userroles/{id}": {
      delete: {
        tags: ["UserRole"],
        summary: "Xóa user-role",
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
      UserRole: {
        type: "object",
        properties: {
          userRoleId: { type: "integer" },
          userId: { type: "integer" },
          roleId: { type: "integer" },
          createdAt: { type: "string", format: "date-time" }
        }
      },
      UserRoleCreate: {
        type: "object",
        required: ["userId", "roleId"],
        properties: {
          userId: { type: "integer" },
          roleId: { type: "integer" }
        }
      }
    }
  }
};
