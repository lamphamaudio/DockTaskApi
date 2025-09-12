window.userApi = {
  paths: {
    "/users": {
      get: {
        tags: ["User"],
        summary: "Lấy danh sách user",
        parameters: [
          { name: "page", in: "query", schema: { type: "integer" } },
          { name: "size", in: "query", schema: { type: "integer" } },
          {
            name: "q",
            in: "query",
            schema: { type: "string" },
            description: "search by name or username"
          }
        ],
        responses: {
          200: {
            description: "Danh sách user",
            content: {
              "application/json": {
                schema: {
                  type: "array",
                  items: { $ref: "#/components/schemas/User" }
                }
              }
            }
          }
        }
      },
      post: {
        tags: ["User"],
        summary: "Tạo user mới",
        requestBody: {
          required: true,
          content: {
            "application/json": {
              schema: { $ref: "#/components/schemas/UserCreate" }
            }
          }
        },
        responses: {
          201: {
            description: "User đã được tạo",
            content: {
              "application/json": {
                schema: { $ref: "#/components/schemas/User" }
              }
            }
          }
        }
      }
    },

    "/users/{userId}": {
      get: {
        tags: ["User"],
        summary: "Lấy thông tin user theo ID",
        parameters: [
          {
            name: "userId",
            in: "path",
            required: true,
            schema: { type: "integer" }
          }
        ],
        responses: {
          200: {
            description: "Thông tin user",
            content: {
              "application/json": {
                schema: { $ref: "#/components/schemas/User" }
              }
            }
          },
          404: { description: "Không tìm thấy user" }
        }
      },
      put: {
        tags: ["User"],
        summary: "Cập nhật user",
        parameters: [
          {
            name: "userId",
            in: "path",
            required: true,
            schema: { type: "integer" }
          }
        ],
        requestBody: {
          required: true,
          content: {
            "application/json": {
              schema: { $ref: "#/components/schemas/UserUpdate" }
            }
          }
        },
        responses: {
          200: {
            description: "Cập nhật thành công",
            content: {
              "application/json": {
                schema: { $ref: "#/components/schemas/User" }
              }
            }
          }
        }
      },
      delete: {
        tags: ["User"],
        summary: "Xóa user",
        parameters: [
          {
            name: "userId",
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

    "/users/{userId}/roles": {
      post: {
        tags: ["User"],
        summary: "Gán vai trò cho user",
        parameters: [
          {
            name: "userId",
            in: "path",
            required: true,
            schema: { type: "integer" }
          }
        ],
        requestBody: {
          required: true,
          content: {
            "application/json": {
              schema: { $ref: "#/components/schemas/UserRoleAssign" }
            }
          }
        },
        responses: {
          200: { description: "Đã gán role" }
        }
      }
    },

    "/users/{userId}/tasks": {
      get: {
        tags: ["User"],
        summary: "Danh sách task được gán cho user",
        parameters: [
          {
            name: "userId",
            in: "path",
            required: true,
            schema: { type: "integer" }
          }
        ],
        responses: {
          200: {
            description: "Danh sách task",
            content: {
              "application/json": {
                schema: {
                  type: "array",
                  items: { $ref: "#/components/schemas/Task" }
                }
              }
            }
          }
        }
      }
    }
  },

  components: {
    schemas: {
      User: {
        type: "object",
        properties: {
          userId: { type: "integer" },
          username: { type: "string" },
          fullName: { type: "string" },
          email: { type: "string" },
          phoneNumber: { type: "string" },
          position: { type: "string" },
          positionId: { type: "integer" },
          orgId: { type: "integer" },
          unitId: { type: "integer" },
          userParent: { type: "integer" },
          createdAt: { type: "string", format: "date-time" }
        }
      },
      UserCreate: {
        type: "object",
        required: ["username", "password", "fullName"],
        properties: {
          username: { type: "string" },
          password: { type: "string" },
          fullName: { type: "string" },
          email: { type: "string" },
          phoneNumber: { type: "string" },
          position: { type: "string" },
          orgId: { type: "integer" },
          unitId: { type: "integer" }
        }
      },
      UserUpdate: {
        type: "object",
        properties: {
          fullName: { type: "string" },
          email: { type: "string" },
          phoneNumber: { type: "string" },
          position: { type: "string" },
          orgId: { type: "integer" },
          unitId: { type: "integer" }
        }
      },
      UserRoleAssign: {
        type: "object",
        required: ["roleId"],
        properties: {
          roleId: { type: "integer" }
        }
      }
    }
  }
};
