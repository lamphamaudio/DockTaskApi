window.taskApi = {
  paths: {
    "/tasks": {
      get: {
        tags: ["Task"],
        summary: "Danh sách công việc",
        parameters: [
          { name: "status", in: "query", schema: { type: "string" } },
          { name: "assigneeId", in: "query", schema: { type: "integer" } }
        ],
        responses: {
          200: {
            description: "OK",
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
      },
      post: {
        tags: ["Task"],
        summary: "Tạo công việc",
        requestBody: {
          required: true,
          content: {
            "application/json": {
              schema: { $ref: "#/components/schemas/TaskCreate" }
            }
          }
        },
        responses: {
          201: {
            description: "Created",
            content: {
              "application/json": { schema: { $ref: "#/components/schemas/Task" } }
            }
          }
        }
      }
    },

    "/tasks/{taskId}": {
      get: {
        tags: ["Task"],
        summary: "Chi tiết task",
        parameters: [
          { name: "taskId", in: "path", required: true, schema: { type: "integer" } }
        ],
        responses: {
          200: {
            description: "OK",
            content: {
              "application/json": { schema: { $ref: "#/components/schemas/Task" } }
            }
          },
          404: { description: "Not found" }
        }
      },
      put: {
        tags: ["Task"],
        summary: "Cập nhật task",
        parameters: [
          { name: "taskId", in: "path", required: true, schema: { type: "integer" } }
        ],
        requestBody: {
          required: true,
          content: {
            "application/json": {
              schema: { $ref: "#/components/schemas/TaskUpdate" }
            }
          }
        },
        responses: { 200: { description: "Updated" } }
      },
      delete: {
        tags: ["Task"],
        summary: "Xóa task",
        parameters: [
          { name: "taskId", in: "path", required: true, schema: { type: "integer" } }
        ],
        responses: { 204: { description: "Deleted" } }
      }
    },

    "/tasks/{taskId}/assign": {
      post: {
        tags: ["Task"],
        summary: "Giao việc cho user hoặc unit",
        parameters: [
          { name: "taskId", in: "path", required: true, schema: { type: "integer" } }
        ],
        requestBody: {
          required: true,
          content: {
            "application/json": {
              schema: { $ref: "#/components/schemas/TaskAssign" }
            }
          }
        },
        responses: { 200: { description: "Assigned" } }
      }
    },

    "/tasks/{taskId}/progress": {
      get: {
        tags: ["Task"],
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
      }
    },

    "/users/{userId}/tasks": {
      get: {
        tags: ["Task"],
        summary: "Danh sách task của user",
        parameters: [
          { name: "userId", in: "path", required: true, schema: { type: "integer" } }
        ],
        responses: {
          200: {
            description: "OK",
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
      Task: {
        type: "object",
        properties: {
          taskId: { type: "integer" },
          title: { type: "string" },
          description: { type: "string" },
          assignerId: { type: "integer" },
          assigneeId: { type: "integer" },
          orgId: { type: "integer" },
          status: { type: "string" },
          priority: { type: "string" },
          startDate: { type: "string", format: "date" },
          dueDate: { type: "string", format: "date" },
          createdAt: { type: "string", format: "date-time" },
          periodId: { type: "integer" },
          taskParentId: { type: "integer" },
          attachedFile: { type: "integer" },
          frequencyId: { type: "integer" }
        }
      },
      TaskCreate: {
        type: "object",
        required: ["title"],
        properties: {
          title: { type: "string" },
          description: { type: "string" },
          assignerId: { type: "integer" },
          assigneeId: { type: "integer" },
          orgId: { type: "integer" },
          status: { type: "string" },
          priority: { type: "string" },
          startDate: { type: "string", format: "date" },
          dueDate: { type: "string", format: "date" },
          periodId: { type: "integer" },
          taskParentId: { type: "integer" },
          frequencyId: { type: "integer" }
        }
      },
      TaskUpdate: {
        type: "object",
        properties: {
          title: { type: "string" },
          description: { type: "string" },
          assigneeId: { type: "integer" },
          status: { type: "string" },
          priority: { type: "string" },
          startDate: { type: "string", format: "date" },
          dueDate: { type: "string", format: "date" }
        }
      },
      TaskAssign: {
        type: "object",
        properties: {
          assigneeId: { type: "integer" },
          unitId: { type: "integer" }
        }
      },
      Progress: {
        type: "object",
        properties: {
          progressId: { type: "integer" },
          taskId: { type: "integer" },
          status: { type: "string" },
          updatedAt: { type: "string", format: "date-time" }
        }
      }
    }
  }
};
